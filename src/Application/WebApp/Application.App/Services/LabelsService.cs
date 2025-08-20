using Order = Application.WebApp.ViewModels.Labels.Order;
using Newtonsoft.Json;
using System.Text;
using Application.WebApp.Interfaces.Api;
using Application.WebApp.Interfaces.Services;
using Domain.WebApp.Entities;

namespace Services
{
    public class LabelsService : ILabelsService
    {
        private readonly IAPICall _apiCall;

        public LabelsService(IAPICall apiCall) =>
            _apiCall = apiCall;

        public async Task<IEnumerable<Order>?> GetOrders(string? cnpj_emp, string? serie_pedido, string? data_inicial, string? data_final)
        {
            try
            {
                var parameters = new Dictionary<string, string>
                {
                    { "cnpj_emp", cnpj_emp },
                    { "serie", serie_pedido },
                    { "data_inicial", data_inicial },
                    { "data_final", data_final }
                };
                var encodedParameters = await new FormUrlEncodedContent(parameters).ReadAsStringAsync();
                var result = await _apiCall.GetAsync($"GetOrdersToPrint", encodedParameters);

                return System.Text.Json.JsonSerializer.Deserialize<IEnumerable<Order>?>(result);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Order> PrintLabel(string cnpj_emp, string serie_pedido, string nr_pedido)
        {
            try
            {
                var parameters = new Dictionary<string, string>
                {
                    { "cnpj_emp", cnpj_emp },
                    { "serie", serie_pedido },
                    { "nr_pedido", nr_pedido }
                };
                var encodedParameters = await new FormUrlEncodedContent(parameters).ReadAsStringAsync();
                var result = await _apiCall.GetAsync($"GetOrderToPrint", encodedParameters);
                var pedido = System.Text.Json.JsonSerializer.Deserialize<Order>(result);

                //Refatorar Aqui
                if (!string.IsNullOrEmpty(pedido.returnShippingCompany) && pedido.shippingCompany.cod_shippingCompany == "7601" || string.IsNullOrEmpty(pedido.returnShippingCompany) && pedido.shippingCompany.cod_shippingCompany != "7601")
                {
                    pedido.client.reason_client = RemoveInvalidCharactersForZebra(pedido.client.reason_client);
                    pedido.client.address_client = RemoveInvalidCharactersForZebra(pedido.client.address_client);
                    pedido.client.neighborhood_client = RemoveInvalidCharactersForZebra(pedido.client.neighborhood_client);
                    pedido.client.city_client = RemoveInvalidCharactersForZebra(pedido.client.city_client);
                    pedido.company.reason_company = RemoveInvalidCharactersForZebra(pedido.company.reason_company);
                    pedido.company.address_company = RemoveInvalidCharactersForZebra(pedido.company.address_company);
                    pedido.company.neighborhood_company = RemoveInvalidCharactersForZebra(pedido.company.neighborhood_company);
                    pedido.company.city_company = RemoveInvalidCharactersForZebra(pedido.company.city_company);

                    if (pedido.shippingCompany.cod_shippingCompany == "7601" && pedido.shippingCompany.metodo_shippingCompany == "ESTD" || pedido.shippingCompany.cod_shippingCompany == "7601" && pedido.shippingCompany.metodo_shippingCompany == "NORM")
                        pedido.shippingCompany.metodo_shippingCompany = "STD";

                    else if (pedido.shippingCompany.cod_shippingCompany == "7601" && pedido.shippingCompany.metodo_shippingCompany == "ETUR")
                        pedido.shippingCompany.metodo_shippingCompany = "EXP";

                    if (pedido.client.doc_client == "38367316000946" || pedido.client.doc_client == "38367316000270" || pedido.client.doc_client == "38367316000431" || pedido.client.doc_client == "38367316000512" || pedido.client.doc_client == "38367316000601" || pedido.client.doc_client == "38367316000350" || pedido.client.doc_client == "38367316000784")
                        pedido.complementAddressStore = $"{pedido.client.complement_address_client}";
                    else
                        pedido.complementAddressStore = $"{pedido.client.reason_client} - {pedido.client.address_client}, {pedido.client.street_number_client}";

                    if (pedido.client.doc_client.Length == 14 && !pedido.client.doc_client.Contains("."))
                        pedido.client.doc_client = Convert.ToInt64(pedido.client.doc_client).ToString(@"00\.000\.000\/0000\-00");

                    if (pedido.client.doc_client.Length == 11 && !pedido.client.doc_client.Contains("."))
                        pedido.client.doc_client = Convert.ToInt64(pedido.client.doc_client).ToString(@"000\.000\.000\-00");

                    if (pedido.client.state_registration_client != "" && pedido.client.state_registration_client != "ISENTO")
                        pedido.client.state_registration_client = Convert.ToUInt64(pedido.client.state_registration_client).ToString(@"00\.000\.00\-0");

                    List<string> requests = new List<string>();

                    if (!string.IsNullOrEmpty(pedido.returnShippingCompany) && pedido.shippingCompany.cod_shippingCompany == "7601")
                    {
                        var total_infos = JsonConvert.DeserializeObject<Root>(pedido.returnShippingCompany);
                        for (int i = 0; i < total_infos.retorno.encomendas.First().volumes.Count(); i++)
                        {
                            pedido.awb.Add(total_infos.retorno.encomendas.First().volumes[i].awb);
                        }
                        pedido.roteShippingCompany = total_infos.retorno.encomendas.First().volumes.First().rota;

                        requests.AddRange(GenerateAWBTotalBodyRequest(pedido));
                    }
                    else if (pedido.shippingCompany.cod_shippingCompany == "3535")
                    {
                        requests.AddRange(GenerateAWBAWRBodyRequest(pedido));
                    }
                    else if (pedido.shippingCompany.cod_shippingCompany == "101988")
                    {
                        requests.AddRange(GenerateAWBJadlogBodyRequest(pedido));
                    }
                    requests.AddRange(GenerateDanfeBodyRequest(pedido));

                    for (int i = 0; i < requests.Count(); i++)
                    {
                        await _apiCall.PostAsync($"SendZPLToAPI", JsonConvert.SerializeObject(new { zpl = requests[i], nr_pedido = $"{pedido.number} - {i + 1}", volumes = $"{i + 1}" }));
                    }
                }

                return pedido;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task PrintLabels(Order pedido)
        {
            try
            {
                //Refatorar Aqui
                if (!string.IsNullOrEmpty(pedido.returnShippingCompany) && pedido.shippingCompany.cod_shippingCompany == "7601" || string.IsNullOrEmpty(pedido.returnShippingCompany) && pedido.shippingCompany.cod_shippingCompany != "7601")
                {
                    pedido.client.reason_client = RemoveInvalidCharactersForZebra(pedido.client.reason_client);
                    pedido.client.address_client = RemoveInvalidCharactersForZebra(pedido.client.address_client);
                    pedido.client.neighborhood_client = RemoveInvalidCharactersForZebra(pedido.client.neighborhood_client);
                    pedido.client.city_client = RemoveInvalidCharactersForZebra(pedido.client.city_client);
                    pedido.company.reason_company = RemoveInvalidCharactersForZebra(pedido.company.reason_company);
                    pedido.company.address_company = RemoveInvalidCharactersForZebra(pedido.company.address_company);
                    pedido.company.neighborhood_company = RemoveInvalidCharactersForZebra(pedido.company.neighborhood_company);
                    pedido.company.city_company = RemoveInvalidCharactersForZebra(pedido.company.city_company);

                    if (pedido.shippingCompany.cod_shippingCompany == "7601" && pedido.shippingCompany.metodo_shippingCompany == "ESTD" || pedido.shippingCompany.cod_shippingCompany == "7601" && pedido.shippingCompany.metodo_shippingCompany == "NORM")
                        pedido.shippingCompany.metodo_shippingCompany = "STD";

                    else if (pedido.shippingCompany.cod_shippingCompany == "7601" && pedido.shippingCompany.metodo_shippingCompany == "ETUR")
                        pedido.shippingCompany.metodo_shippingCompany = "EXP";

                    if (pedido.client.doc_client == "38367316000946" || pedido.client.doc_client == "38367316000270" || pedido.client.doc_client == "38367316000431" || pedido.client.doc_client == "38367316000512" || pedido.client.doc_client == "38367316000601" || pedido.client.doc_client == "38367316000350" || pedido.client.doc_client == "38367316000784")
                        pedido.complementAddressStore = $"{pedido.client.complement_address_client}";
                    else
                        pedido.complementAddressStore = $"{pedido.client.reason_client} - {pedido.client.address_client}, {pedido.client.street_number_client}";

                    if (pedido.client.doc_client.Length == 14 && !pedido.client.doc_client.Contains("."))
                        pedido.client.doc_client = Convert.ToInt64(pedido.client.doc_client).ToString(@"00\.000\.000\/0000\-00");

                    if (pedido.client.doc_client.Length == 11 && !pedido.client.doc_client.Contains("."))
                        pedido.client.doc_client = Convert.ToInt64(pedido.client.doc_client).ToString(@"000\.000\.000\-00");

                    if (pedido.client.state_registration_client != "" && pedido.client.state_registration_client != "ISENTO")
                        pedido.client.state_registration_client = Convert.ToUInt64(pedido.client.state_registration_client).ToString(@"00\.000\.00\-0");

                    List<string> requests = new List<string>();
                    if (!string.IsNullOrEmpty(pedido.returnShippingCompany) && pedido.shippingCompany.cod_shippingCompany == "7601")
                    {
                        var total_infos = JsonConvert.DeserializeObject<Root>(pedido.returnShippingCompany);
                        for (int i = 0; i < total_infos.retorno.encomendas.First().volumes.Count(); i++)
                        {
                            pedido.awb.Add(total_infos.retorno.encomendas.First().volumes[i].awb);
                        }
                        pedido.roteShippingCompany = total_infos.retorno.encomendas.First().volumes.First().rota;

                        requests.AddRange(GenerateAWBTotalBodyRequest(pedido));
                    }
                    else if (pedido.shippingCompany.cod_shippingCompany == "101988")
                    {
                        requests.AddRange(GenerateAWBJadlogBodyRequest(pedido));
                    }
                    else if (pedido.shippingCompany.cod_shippingCompany == "3535")
                    {
                        requests.AddRange(GenerateAWBAWRBodyRequest(pedido));
                    }
                    requests.AddRange(GenerateDanfeBodyRequest(pedido));

                    for (int i = 0; i < requests.Count(); i++)
                    {
                        await _apiCall.PostAsync($"SendZPLToAPI", JsonConvert.SerializeObject(new { zpl = requests[i], nr_pedido = $"{pedido.number} - {i + 1}", volumes = $"{i + 1}" }));
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private List<string> GenerateDanfeBodyRequest(Order pedido)
        {
            try
            {
                string logo = string.Empty;
                string empresa = string.Empty;
                List<string> requests = new List<string>();

                if (pedido.serie == "MI-")
                {
                    empresa = "MISHA";
                    logo = "FO25,114^GFA,1321,7128,44,:Z64:eJztWEuu4jAQ7FggWVkFadhHs3rKKXIEkOA+LVaIU6BZRTnluH+2CTEEDWg29JM/cZtKpV67bRlg3s4IWHD9m7lx+dxqv3QmAoy4HPi4cJ4LpVsOC9uF8zy8xncpLtkrfDev4OLyuUv5tvAZvoT7CX0J9618feo+1XeVuk/5KlgLC/hmJJ/ijgn3qb7H/mVcslf4PtVXdfDwZn1daj6y3vBD+QHfwdcjVef0zN2gr4114xCdfawym+HbQU3UHNSE7q5cXCsOR2Okdk1tRbQqsKoUv+wMMiIhBTziNGobynhC6YO8K9ghcqXeNvR2wHHBuL8MeMe49L8fLAC6K8NQv6Ngq20uv4C3scaqjVJrlHplc3nGSBoKRuBXX+XbQzDQK3jMg75U+DKtNZWeG9rcmO+6V1ye0bUlXGrp+wUXTcZNxE06C98mF57DlH8VMKnUissON5gTQbfdyG3Kt9qJ5kKcf8Xf7BRXP7uLuFd9qRARbj0XC4mN4W56dQotZlMPia+fxRW+Rsn4wjxfMFzjizKXHRG3i3wFQ8otrum7jvrWub66tiQ/DOq8EO7hju9uwpct8b3RVw9mUQfmPadvOphFfcGcM/pqMuiML5lP+q4zvtXx8JBvrq8baTFn+gJnjyvk8VupjNtNxrcxvlHGXF8YRx6L+rKbce/0hfWRd7kl+hLhAXJ9zXEfv+Fpv7vRtyrqGyomnPQdoRS/NEaEE99dUV/QPB71Zc6Jbx6/VG+bZfHLg5YfIH7DvL70fCivtxt9WQnM1rG99D5+ubvP84M55/SFlCd544i4d/HLFgSOfA9xxpy+/AFRX15/hfhVOWP8/jLnvL7URn0T31l9qS3xnepL/ahv4jsTv5DycMCVpfFA34CX9I24c/HLMMa3eqavS/q6Cd9J/HJr8Sspohy/hJv0jbjz+lav6IsTfdN+MY1famP87s1Z0LfOcalzKeu7UkdlC2/CV3WwY8jNenOT+F1bUoDsvNOotCl+OZPXskfyuSSG7SjvGyQeeqvWmguo39vYQbToia9jSNlyByk/IrW8a+SbCIc0Uu3p55Jwd1JUYRnb69cQOO9mIeGCJjHuXAZ1hIyJ2k0n4K997Wtf+9rXvvZZ8w5/uOPOCKD3RgVbxYuX1YNZYrUhOb75cw8nVw+9ap7v0WqPHjB0nA8jPtS4ELfE+Tezc4KDdIN2AnT+AeOqkpsnPvgW2f+BM534EL0n4u4MJ8RQn2fm9hOWxrW5nxoEbQn3ii1Ai6Sv8G0fECagBiYXZxM7B1nDme+CP470rU/h8ezCXxn3vxq+F+4vgfk6hA==:9633";
                }
                else
                {
                    empresa = "OPEN ERA";
                    logo = "FO25,160^GFA,1321,7128,44,:Z64:eJztlbGO00AURZ9ltF5tkN0gQWHi1f4AlBECx8VuT5OeT3CDlGIlT4lSwA8gCqrVUvABK7H+ie0oXKJUadBGEGWY++Y9x4ZFckokRsrYnrk+ub7zPKYjQ4Pbw3q49no4N/g+HBt+G66N6uHaxAzXjodLKd9Dm+6hneyhLffQrokO9+A+wPG0+Ivg3ikfMP2KaGrc0VrXT611iWuQobVrjDXy/+BmuKeqXJ9VlVtJDSeoqhITpT6Xu2mEe5afXWHky6WhpBZtuFxeEP243CoXzHP3q2lF9AijkWqD2gPhKPgq9nPmzyXspJHFDI3XJjj/ItqIuc9FG5W/cTEdvBctaq1ptfFa/dbeKKbDt8o14KbqN72DG0WiDZk7Vm6u+YpfHJNEtEGBPFruWLmFaLtchNzhvjN9v+DG/k84hK7f6A6/qb9Q7kS5ofkz3zxUbQHuU6IXs5eOG9TCvZkV0GYtN1Yu19QGA434tSix9SGWbAIN3Re/gauHDNqISuFa6yZezzbspNlxf1677tnJMQbmku/HE9dXXL/zllugTEnrgSbdfHnCccsd126N5mDyXr6fDMnj0IEPksd9vpT28uVDjZJFeiHnoB5iSnr5YtbHj1UJjHDFb9RftxWfpv7ukelzRx+6fuHUnY793f692PmVl0u55wxkbqNRtNxw2/WLt8+dxv4i9RG3XH6xd/Wb8hgX8NZsWq4xyJeEW+NyjYHE+A9AdrZSv49nsy73BmXH9Xsg3Ce2Ue4Uu1qsm73fz0oxy+4DS+o3u7XMkHxv7QrawG2WhN61S3T8zEeLhevaHXmxeEN0jLNDVfxv/1a7uroYrJWv3KDGJfcLH9fWKQ==:626F";
                }

                for (int i = 0; i < pedido.volumes; i++)
                {
                    string zpl = @$"^XA
                                    ~TA000
                                    ~JSN
                                    ^LT0
                                    ^MNW
                                    ^MTT
                                    ^PON
                                    ^PMN
                                    ^LH0,0
                                    ^JMA
                                    ^PR4,4
                                    ~SD30
                                    ^JUS
                                    ^LRN
                                    ^CI27
                                    ^PA0,1,1,0
                                    ^XZ
                                    ^XA
                                    ^MMT
                                    ^PW799
                                    ^LL1180
                                    ^LS0

                                    ^FX DRAWLINES
                                    ^FO25,90^GB751,0,3^FS
                                    ^FO31,451^GB745,0,3^FS
                                    ^FO151,453^GB0,57,3^FS
                                    ^FO31,508^GB745,0,3^FS
                                    ^FO272,453^GB0,60,3^FS
                                    ^FO413,453^GB0,57,3^FS
                                    ^FO592,453^GB0,57,3^FS
                                    ^FO31,584^GB745,0,3^FS
                                    ^FO31,840^GB745,0,3^FS
                                    ^FO31,1085^GB745,0,3^FS
                                    ^FO25,292^GB751,0,3^FS
                                    ^FO31,925^GB745,0,3^FS

                                    ^FX HEADER
                                    ^FT209,59^A0N,25,25^FH\^CI28^FDDANFE SIMPLIFICADO - MISHA^FS^CI27
                                    ^FO25,114^GFA,1321,7128,44,:Z64:eJztWEuu4jAQ7FggWVkFadhHs3rKKXIEkOA+LVaIU6BZRTnluH+2CTEEDWg29JM/cZtKpV67bRlg3s4IWHD9m7lx+dxqv3QmAoy4HPi4cJ4LpVsOC9uF8zy8xncpLtkrfDev4OLyuUv5tvAZvoT7CX0J9618feo+1XeVuk/5KlgLC/hmJJ/ijgn3qb7H/mVcslf4PtVXdfDwZn1daj6y3vBD+QHfwdcjVef0zN2gr4114xCdfawym+HbQU3UHNSE7q5cXCsOR2Okdk1tRbQqsKoUv+wMMiIhBTziNGobynhC6YO8K9ghcqXeNvR2wHHBuL8MeMe49L8fLAC6K8NQv6Ngq20uv4C3scaqjVJrlHplc3nGSBoKRuBXX+XbQzDQK3jMg75U+DKtNZWeG9rcmO+6V1ye0bUlXGrp+wUXTcZNxE06C98mF57DlH8VMKnUissON5gTQbfdyG3Kt9qJ5kKcf8Xf7BRXP7uLuFd9qRARbj0XC4mN4W56dQotZlMPia+fxRW+Rsn4wjxfMFzjizKXHRG3i3wFQ8otrum7jvrWub66tiQ/DOq8EO7hju9uwpct8b3RVw9mUQfmPadvOphFfcGcM/pqMuiML5lP+q4zvtXx8JBvrq8baTFn+gJnjyvk8VupjNtNxrcxvlHGXF8YRx6L+rKbce/0hfWRd7kl+hLhAXJ9zXEfv+Fpv7vRtyrqGyomnPQdoRS/NEaEE99dUV/QPB71Zc6Jbx6/VG+bZfHLg5YfIH7DvL70fCivtxt9WQnM1rG99D5+ubvP84M55/SFlCd544i4d/HLFgSOfA9xxpy+/AFRX15/hfhVOWP8/jLnvL7URn0T31l9qS3xnepL/ahv4jsTv5DycMCVpfFA34CX9I24c/HLMMa3eqavS/q6Cd9J/HJr8Sspohy/hJv0jbjz+lav6IsTfdN+MY1famP87s1Z0LfOcalzKeu7UkdlC2/CV3WwY8jNenOT+F1bUoDsvNOotCl+OZPXskfyuSSG7SjvGyQeeqvWmguo39vYQbToia9jSNlyByk/IrW8a+SbCIc0Uu3p55Jwd1JUYRnb69cQOO9mIeGCJjHuXAZ1hIyJ2k0n4K997Wtf+9rXvvZZ8w5/uOPOCKD3RgVbxYuX1YNZYrUhOb75cw8nVw+9ap7v0WqPHjB0nA8jPtS4ELfE+Tezc4KDdIN2AnT+AeOqkpsnPvgW2f+BM534EL0n4u4MJ8RQn2fm9hOWxrW5nxoEbQn3ii1Ai6Sv8G0fECagBiYXZxM7B1nDme+CP470rU/h8ezCXxn3vxq+F+4vgfk6hA==:9633
                                    ^FT379,137^A0N,23,15^FH\^CI28^FD{pedido.company.reason_company.ToUpper()}^FS^CI27
                                    ^FT379,166^A0N,23,15^FH\^CI28^FDCNPJ: {Convert.ToUInt64(pedido.company.doc_company)}^FS^CI27
                                    ^FT379,195^A0N,23,15^FH\^CI28^FDI.E: {Convert.ToUInt64(pedido.company.state_registration_company).ToString(@"00\.000\.00\-0")}^FS^CI27
                                    ^FT379,224^A0N,23,15^FH\^CI28^FD{pedido.company.address_company.ToUpper()}, {pedido.company.street_number_company.ToUpper()} - {pedido.company.complement_address_company.ToUpper()} - {pedido.company.neighborhood_company.ToUpper()}^FS^CI27
                                    ^FT379,253^A0N,23,15^FH\^CI28^FDCEP: {pedido.company.zip_code_company} - {pedido.company.city_company.ToUpper()} - {pedido.company.uf_company.ToUpper()}^FS^CI27
                                    ^FX
                                    ^BY2,3,10
                                    ^FO115,315,0^BCN,100,Y,N,N,A^FD{pedido.invoice.key_nfe_nf}^FS

                                    ^FX
                                    ^FT39,472^A0N,14,15^FH\^CI28^FDOPERAÇÃO^FS^CI27
                                    ^FT44,499^A0N,23,23^FH\^CI28^FD 1-SAÍDA ^FS^CI27

                                    ^FX
                                    ^FT160,472^A0N,14,15^FH\^CI28^FDSÉRIE^FS^CI27
                                    ^FT213,499^A0N,23,23^FH\^CI28^FD{pedido.invoice.serie_nf}^FS^CI27

                                    ^FX
                                    ^FT283,472^A0N,14,15^FH\^CI28^FDNÚMERO^FS^CI27
                                    ^FT315,499^A0N,23,23^FH\^CI28^FD{pedido.invoice.number_nf}^FS^CI27

                                    ^FX
                                    ^FT603,472^A0N,14,15^FH\^CI28^FDVALOR TOTAL^FS^CI27
                                    ^FT636,499^A0N,23,23^FH\^CI28^FD{pedido.invoice.amount_nf.ToString("C")}^FS^CI27

                                    ^FX
                                    ^FT39,533^A0N,14,15^FH\^CI28^FDPROTOCOLO DE AUTORIZAÇÃO DE USO^FS^CI27
                                    ^FT445,499^A0N,23,23^FH\^CI28^FD{pedido.dateProt.Date.ToString("dd/MM/yyyy")}^FS^CI27
                                    ^FT160,567^A0N,23,23^FH\^CI28^FD{pedido.nProt}^FS^CI27
                                    ^FT518,567^A0N,23,23^FH\^CI28^FD{pedido.dateProt.TimeOfDay}^FS^CI27

                                    ^FX
                                    ^FT39,606^A0N,14,15^FH\^CI28^FDDESTINATÁRIO^FS^CI27
                                    ^FT39,639^A0N,23,23^FH\^CI28^FD{pedido.client.reason_client.ToUpper()}^FS^CI27
                                    ^FT39,668^A0N,23,23^FH\^CI28^FDCNPJ/CPF: {pedido.client.doc_client}^FS^CI27
                                    ^FT39,697^A0N,23,23^FH\^CI28^FDI.E: {pedido.client.state_registration_client}^FS^CI27
                                    ^FT39,726^A0N,23,23^FH\^CI28^FD{pedido.client.address_client.ToUpper()}, {pedido.client.street_number_client} - {pedido.client.complement_address_client.ToUpper()}^FS^CI27
                                    ^FT39,755^A0N,23,23^FH\^CI28^FD{pedido.client.neighborhood_client.ToUpper()}^FS^CI27
                                    ^FT39,784^A0N,23,23^FH\^CI28^FDCEP: {Convert.ToInt64(pedido.client.zip_code_client).ToString(@"00000\-000")}^FS^CI27
                                    ^FT39,813^A0N,23,23^FH\^CI28^FD{pedido.client.city_client.ToUpper()} - {pedido.client.uf_client.ToUpper()}^FS^CI27

                                    ^FX
                                    ^FT39,866^A0N,14,15^FH\^CI28^FDTRANSPORTADORA^FS^CI27
                                    ^FT39,904^A0N,23,25^FH\^CI28^FD{pedido.shippingCompany.reason_shippingCompany.ToUpper()}^FS^CI27

                                    ^FX
                                    ^FT39,953^A0N,14,15^FH\^CI28^FDDADOS ADICIONAIS^FS^CI27
                                    ^FT39,993^A0N,25,25^FH\^CI28^FDPedido: {pedido.number.ToUpper()}^FS^CI27
                                    ^FT39,1024^A0N,25,25^FH\^CI28^FDVolume: {i + 1}/{pedido.volumes}^FS^CI27
                                    ^FT39,1055^A0N,25,25^FH\^CI28^FDContato: {pedido.client.reason_client} - Telefone: {pedido.client.fone_client}^FS^CI27

                                    ^FT424,472^A0N,14,15^FH\^CI28^FDEMISSÃO^FS^CI27
                                    ^FT369,567^A0N,23,23^FH\^CI28^FD{pedido.dateProt.Date.ToString("dd/MM/yyyy")}^FS^CI27

                                    ^PQ1,0,1,Y
                                    ^XZ";

                    requests.Add(zpl);
                }

                return requests;
            }
            catch (Exception ex)
            {
                throw new Exception($@"{pedido.number.Trim()} - GenerateDanfeBodyRequest - Erro ao gerar etiqueta danfe atraves do zpl - {ex.Message}");
            }
        }

        private List<string> GenerateAWBTotalBodyRequest(Order pedido)
        {
            try
            {
                List<string> requests = new List<string>();

                for (int i = 0; i < pedido.awb.Count(); i++)
                {
                    string zpl = @$"^XA
                                    ~TA000
                                    ~JSN
                                    ^LT0
                                    ^MNW
                                    ^MTT
                                    ^PON
                                    ^PMN
                                    ^LH0,0
                                    ^JMA
                                    ^PR4,4
                                    ~SD30
                                    ^JUS
                                    ^LRN
                                    ^CI27
                                    ^PA0,1,1,0
                                    ^XZ
                                    ^XA
                                    ^MMT
                                    ^PW799
                                    ^LL1180
                                    ^LS0

                                    ^FX DRAWLINES
                                    ^FO589,64^GB174,67,2^FS
                                    ^FO13,462^GB769,0,3^FS
                                    ^FO13,696^GB769,0,3^FS
                                    ^FO13,973^GB769,0,3^FS
                                    ^FO589,195^GB174,67,2^FS

                                    ^FX HEADER
                                    ^FT589,49^A0N,25,25^FH\^CI28^FDTOTAL EXPRESS^FS^CI27
                                    ^FT633,115^A0N,51,51^FH\^CI28^FD^FS^CI27
                                    ^FT633,115^A0N,51,51^FH\^CI28^FD{pedido.shippingCompany.metodo_shippingCompany}^FS^CI27

                                    ^FT18,47^A0N,23,23^FH\^CI28^FDRemetente^FS^CI27
                                    ^FT30,93^A0N,23,20^FH\^CI28^FD{pedido.company.reason_company.ToUpper()}^FS^CI27
                                    ^FT30,122^A0N,23,20^FH\^CI28^FDCNPJ: {Convert.ToUInt64(pedido.company.doc_company).ToString(@"00\.000\.000\/0000\-00")}^FS^CI27
                                    ^FT30,151^A0N,23,20^FH\^CI28^FDI.E: {Convert.ToUInt64(pedido.company.state_registration_company).ToString(@"00\.000\.00\-0")}^FS^CI27
                                    ^FT30,180^A0N,23,20^FH\^CI28^FD{pedido.company.address_company.ToUpper()}, {pedido.company.street_number_company.ToUpper()} - {pedido.company.complement_address_company.ToUpper()} - {pedido.company.neighborhood_company.ToUpper()}^FS^CI27
                                    ^FT30,209^A0N,23,20^FH\^CI28^FD{pedido.company.zip_code_company} - {pedido.company.city_company.ToUpper()} - {pedido.company.uf_company.ToUpper()}^FS^CI27

                                    ^FT18,259^A0N,23,23^FH\^CI28^FDDestinatário^FS^CI27
                                    ^FT30,300^A0N,23,20^FH\^CI28^FD{pedido.client.reason_client.ToUpper()}^FS^CI27
                                    ^FT30,329^A0N,23,20^FH\^CI28^FDCNPJ/CPF: {pedido.client.doc_client}^FS^CI27
                                    ^FT30,358^A0N,23,20^FH\^CI28^FDI.E: {pedido.client.state_registration_client}^FS^CI27
                                    ^FT30,387^A0N,23,20^FH\^CI28^FD{pedido.client.address_client.ToUpper()}, {pedido.client.street_number_client} - {pedido.client.complement_address_client.ToUpper()}^FS^CI27
                                    ^FT30,416^A0N,23,20^FH\^CI28^FD{pedido.client.neighborhood_client.ToUpper()}^FS^CI27
                                    ^FT30,445^A0N,23,20^FH\^CI28^FDCEP: {Convert.ToInt64(pedido.client.zip_code_client).ToString(@"00000\-000")} - {pedido.client.city_client.ToUpper()} - {pedido.client.uf_client.ToUpper()}^FS^CI27

                                    ^FX
                                    ^BY3,3,139^FT30,628^BCN,,N,N
                                    ^FH\^FD>;{Convert.ToInt64(pedido.client.zip_code_client).ToString(@"00000\-000").Substring(0, 4)}>6{Convert.ToInt64(pedido.client.zip_code_client).ToString(@"00000\-000").Substring(5)}^FS
                                    ^FT111,675^A0N,42,43^FH\^CI28^FD{Convert.ToInt64(pedido.client.zip_code_client).ToString(@"00000\-000")}^FS^CI27
                                    ^FT473,673^A0N,34,23^FH\^CI28^FD{pedido.roteShippingCompany}^FS^CI27

                                    ^FX
                                    ^BY4,3,10
                                    ^FO42,715,0^BCN,200,Y,N,N,A^FD{pedido.awb[i]}^FS

                                    ^FX
                                    ^BY3,4,10
                                    ^FO190,1005,0^BCN,100,Y,N,N,A^FD{pedido.number.ToUpper()}^FS

                                    ^FX
                                    ^FT589,176^A0N,25,25^FH\^CI28^FDVOLUMES^FS^CI27
                                    ^FT629,246^A0N,51,51^FH\^CI28^FD{i + 1}/{pedido.awb.Count()}^FS^CI27

                                    ^FT553,649^BQN,2,7
                                    ^FH\^FDLA,{pedido.awb[i]}^FS

                                    ^PQ1,0,1,Y
                                    ^XZ";

                    requests.Add(zpl.Replace("'", ""));
                }

                return requests;
            }
            catch (Exception ex)
            {
                throw new Exception(@$"{pedido.number.Trim()} - GenerateAWBBodyRequest - Erro ao gerar etiqueta awb atraves do zpl - {ex.Message}");
            }
        }

        private List<string> GenerateAWBAWRBodyRequest(Order pedido)
        {
            try
            {
                List<string> requests = new List<string>();

                for (int i = 0; i < pedido.volumes; i++)
                {
                    string zpl = @$"^XA
                                    ~TA000
                                    ~JSN
                                    ^LT0
                                    ^MNW
                                    ^MTT
                                    ^PON
                                    ^PMN
                                    ^LH0,0
                                    ^JMA
                                    ^PR4,4
                                    ~SD30
                                    ^JUS
                                    ^LRN
                                    ^CI27
                                    ^PA0,1,1,0
                                    ^XZ
                                    ^XA
                                    ^MMT
                                    ^PW799
                                    ^LL1180
                                    ^LS0

                                    ^FX DRAWLINES
                                    ^FO589,64^GB174,67,2^FS
                                    ^FO13,462^GB769,0,3^FS
                                    ^FO13,696^GB769,0,3^FS
                                    ^FO13,973^GB769,0,3^FS
                                    ^FO589,195^GB174,67,2^FS

                                    ^FX HEADER
                                    ^FT589,49^A0N,25,25^FH\^CI28^FDAWR^FS^CI27
                                    ^FT633,115^A0N,51,51^FH\^CI28^FD^FS^CI27
                                    ^FT620,115^A0N,51,51^FH\^CI28^FD{pedido.shippingCompany.metodo_shippingCompany}^FS^CI27

                                    ^FT18,47^A0N,23,23^FH\^CI28^FDRemetente^FS^CI27
                                    ^FT30,93^A0N,23,20^FH\^CI28^FD{pedido.company.reason_company.ToUpper()}^FS^CI27
                                    ^FT30,122^A0N,23,20^FH\^CI28^FDCNPJ: {Convert.ToUInt64(pedido.company.doc_company).ToString(@"00\.000\.000\/0000\-00")}^FS^CI27
                                    ^FT30,151^A0N,23,20^FH\^CI28^FDI.E: {Convert.ToUInt64(pedido.company.state_registration_company).ToString(@"00\.000\.00\-0")}^FS^CI27
                                    ^FT30,180^A0N,23,20^FH\^CI28^FD{pedido.company.address_company.ToUpper()}, {pedido.company.street_number_company.ToUpper()} - {pedido.company.complement_address_company.ToUpper()} - {pedido.company.neighborhood_company.ToUpper()}^FS^CI27
                                    ^FT30,209^A0N,23,20^FH\^CI28^FD{pedido.company.zip_code_company} - {pedido.company.city_company.ToUpper()} - {pedido.company.uf_company.ToUpper()}^FS^CI27

                                    ^FT18,259^A0N,23,23^FH\^CI28^FDDestinatário^FS^CI27
                                    ^FT30,300^A0N,23,20^FH\^CI28^FD{pedido.client.reason_client.ToUpper()}^FS^CI27
                                    ^FT30,329^A0N,23,20^FH\^CI28^FDCNPJ/CPF: {pedido.client.doc_client}^FS^CI27
                                    ^FT30,358^A0N,23,20^FH\^CI28^FDI.E: {pedido.client.state_registration_client}^FS^CI27
                                    ^FT30,387^A0N,23,20^FH\^CI28^FD{pedido.client.address_client.ToUpper()}, {pedido.client.street_number_client} - {pedido.client.complement_address_client.ToUpper()}^FS^CI27
                                    ^FT30,416^A0N,23,20^FH\^CI28^FD{pedido.client.neighborhood_client.ToUpper()}^FS^CI27
                                    ^FT30,445^A0N,23,20^FH\^CI28^FDCEP: {Convert.ToInt64(pedido.client.zip_code_client).ToString(@"00000\-000")} - {pedido.client.city_client.ToUpper()} - {pedido.client.uf_client.ToUpper()}^FS^CI27

                                    ^FX
                                    ^BY3,3,139^FT30,628^BCN,,N,N
                                    ^FH\^FD>;{Convert.ToInt64(pedido.client.zip_code_client).ToString(@"00000\-000").Substring(0, 4)}>6{Convert.ToInt64(pedido.client.zip_code_client).ToString(@"00000\-000").Substring(5)}^FS
                                    ^FT111,675^A0N,42,43^FH\^CI28^FD{Convert.ToInt64(pedido.client.zip_code_client).ToString(@"00000\-000")}^FS^CI27

                                    ^FX
                                    ^BY4,3,10
                                    ^FO120,715,0^BCN,200,Y,N,N,A^FD000000000000000^FS

                                    ^FX
                                    ^BY3,4,10
                                    ^FO190,1005,0^BCN,100,Y,N,N,A^FD{pedido.number.ToUpper()}^FS

                                    ^FX
                                    ^FT589,176^A0N,25,25^FH\^CI28^FDVOLUMES^FS^CI27
                                    ^FT629,246^A0N,51,51^FH\^CI28^FD{i + 1}/{pedido.volumes}^FS^CI27

                                    ^FT553,715^BQN,2,7
                                    ^FH\^FDLA,(0)00-000-00-000-[000]^FS

                                    ^PQ1,0,1,Y
                                    ^XZ";

                    requests.Add(zpl.Replace("'", ""));
                }
                return requests;
            }
            catch (Exception ex)
            {
                throw new Exception($"{pedido.number.Trim()} - GenerateAWBAWRBodyRequest - Erro ao gerar etiqueta awb atraves do zpl - {ex.Message}");
            }
        }

        private List<string> GenerateAWBJadlogBodyRequest(Order pedido)
        {
            try
            {
                List<string> requests = new List<string>();

                for (int i = 0; i < pedido.volumes; i++)
                {
                    string zpl = @$"^XA
                                    ~TA000
                                    ~JSN
                                    ^LT0
                                    ^MNW
                                    ^MTT
                                    ^PON
                                    ^PMN
                                    ^LH0,0
                                    ^JMA
                                    ^PR4,4
                                    ~SD10
                                    ^JUS
                                    ^LRN
                                    ^CI0
                                    ^XZ
                                    ^XA
                                    ^MMT
                                    ^PW831
                                    ^LL1180
                                    ^LS0

                                    ^FO416,992^GFA,07680,07680,00048,:Z64:
                                    eJztWLFu4zgQFYUTELCKgBXUBi71FQqQ9DJgQs36H3KABVaHuDzsVwipBH5F7g+2sLrVX+zC7c0MKYm0aa1ZbKcBIjLU5OXN48yIUhStttpqq622mt9SEfgHXZh7MpRB/lwdQ9xZLbdB+EoFBZAMwxDiHyul3JXHR5+fWWX1+XyuAvA54B+dldcXn1+y08N+EMPJuVN8+PxjZQbF3QCyWpTX7qxuaMxlk8t3OwB+yU+bAeWgvusg+v7TQ7/vadwPP9jgBFB48UfSivCtHWZSSo++uZQ4ZFIe2Pn8y9qiK31tfK7xLY9ECJ8+sEqD5j98n27Eqo2v3SGq2ARH+O2ML7epx79uMropZcPe5Xtj4Xu8AbjVNw3+7JScvP6CGAugTvznGl7ELyb8KYD8kKK4KexBGqU4TzNRRbQnuDfAHyrg/HPCv67OB5C7OOJMTfiTV7LLMNNRblHSXmRC7CLaE7YH0/x/zPhFR0IA2rFAokha8489+PkhbyhPKiafga7A1GmYzV/CBvwz42MD4whM+B3hH2/zP4m+xCI4MeDfQ9rjpRSfiD9M+tv8NedO4yvCb5f4yzcmG+T5DIOs6kbIauZ/cPXn3QNCdN8U4sNw5BBJu6B/InZM7IRA/i+vcKkiUU36D18v+WOuq2NM+DAg9WKJP8ubRJYJsH+WJQhfv0X5347+8t3WH8SPaXdJdYLmC/xP0GuSPmLiWaDq4jukPlxu6w80Cb8FfEN9kT8kD6QQk1vgX0X5G+r/5vAH/X/N+gM0FkGh+fOOd/8u5c8OWhA2e+IP2Q87IWhm8v9a/1jhPylag6/zc4E/m/mXlE+SIrH0txoQUlffbP66CBb0Zz02IfGf5g/1gPX7W/0LrT9sLRXxffxR/7xx+s8Brk7+I3435Q9vOULb/Itr/YXJH6jkKkNoS3/dRa/zZ8xPjW/xjx3+TWTlPzShCoOx+w82J+nkP7aGER/qF7Cc/Ilc/V/ECeu3R/6nV/GZ9eXr3H96aP17m7/aoMQfBdUvDFDCT4WVP9isbf5GYt1/8GGcS6v/NDXMMmnlv1IX/S22+2cX6wBm/pDtFT5ud4z6v9BP5FH/XbKHvdnb/BF/7s9KP/FH/i09GQqXf4nXqf/DiXPO/4p+4BQ0+htuinZAn1XgzDPyJ+6tnkz8oXgZUKb+j7xhxfCHg0+Cp59kP/GP4s0TXp/o+fWB82gzxdaa82cxP0VTYZ6/yH+LZ+V0+xjRgQezCOOrWD3lv2Wj6vaKOX9yzxmaGdXtFV0CEMDXe/DjzqSQ9yWDUf8xltHKlnIfxGe+lxgbn9NM08cAHvz8P8dftP4l1S7uwBc/fjvOxxnB+98wmMkaMp0/mj4E4H1HsPmbmaZ/+YYx8y8d/nj+1Fb6/sCDXxj81uN+rb9uQHoHfoM/LqnbAjn8/9L0h9F8AWyizQX+SN8bAOSIuHgTqEf+vlcEj/EJ/y53qFtj/X3+i/p7jNVB9OcAjnf6J1p9OKHeaQv577O0DqIfTfV7ryW3099rccDuotEOhHxB4UH0dQmUAf7X3x+WLb1RvDct8PsMtKAyyP/GC+ZNS0K/X4Va+YfxV1tttdX+gP0PFFRN0w==:4C2B
                                    ^FT375,1138^A0I,23,21^FH\^FDPedido: ^FS
                                    ^FT375,1103^A0I,23,21^FH\^FDNota Fiscal: ^FS
                                    ^FT375,1067^A0I,23,21^FH\^FDShipmentID: ^FS
                                    ^FT375,1028^A0I,23,21^FH\^FDVolume: ^FS
                                    ^FO32,962^GB767,0,4^FS
                                    ^FT799,919^A0I,28,28^FB177,1,0,C^FH\^FDDESTINAT\B5RIO^FS
                                    ^FT799,684^A0I,28,28^FB161,1,0,C^FH\^FDSHIPMENT ID^FS
                                    ^FT799,879^A0I,23,24^FH\^FD{pedido.client.reason_client}^FS
                                    ^FT799,845^A0I,23,24^FH\^FD{pedido.client.address_client}^FS
                                    ^FT799,811^A0I,23,24^FH\^FD{pedido.client.street_number_client}, {pedido.client.neighborhood_client}^FS
                                    ^FT799,772^A0I,23,24^FH\^FD{pedido.client.city_client}, {pedido.client.uf_client}, {pedido.client.zip_code_client}^FS
                                    ^BY5,3,115^FT680,536^BCI,,N,N
                                    ^FD>:{pedido.returnShippingCompany}^FS
                                    ^FO34,487^GB765,0,4^FS
                                    ^FT799,459^A0I,28,28^FB147,1,0,C^FH\^FDREMETENTE^FS
                                    ^FT799,421^A0I,23,24^FH\^FD{pedido.company.reason_company}^FS
                                    ^FT799,373^A0I,23,24^FH\^FD{pedido.company.address_company}^FS
                                    ^FT799,324^A0I,23,24^FH\^FD{pedido.company.street_number_company}, {pedido.company.neighborhood_company}^FS
                                    ^FT799,274^A0I,23,24^FH\^FD{pedido.company.city_company}, {pedido.company.uf_company}, {pedido.company.zip_code_company}^FS
                                    ^FT292,1138^A0I,23,24^FH\^FD{pedido.number}^FS
                                    ^FT252,1103^A0I,23,24^FH\^FD{pedido.invoice.number_nf}^FS
                                    ^FT248,1067^A0I,23,24^FH\^FD{pedido.returnShippingCompany}^FS
                                    ^FT289,1028^A0I,23,24^FH\^FD{pedido.volumes}^FS
                                    ^BY4,3,99^FT688,129^BCI,,Y,N
                                    ^FD>:{pedido.number}^FS
                                    ^FO32,731^GB767,0,4^FS
                                    ^PQ1,0,1,Y
                                    ^XZ";

                    requests.Add(zpl.Replace("'", ""));
                }
                return requests;
            }
            catch (Exception ex)
            {
                throw new Exception($"{pedido.number.Trim()} - GenerateAWBAWRBodyRequest - Erro ao gerar etiqueta awb atraves do zpl - {ex.Message}");
            }
        }

        private string RemoveInvalidCharactersForZebra(string text)
        {
            try
            {
                if (string.IsNullOrEmpty(text))
                    return string.Empty;

                Encoding iso = Encoding.GetEncoding("ISO-8859-1");
                Encoding utf8 = Encoding.UTF8;
                byte[] utfBytes = utf8.GetBytes(text);
                byte[] isoBytes = Encoding.Convert(utf8, iso, utfBytes);
                return iso.GetString(isoBytes);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<string> GetLabelToPrint(string fileName)
        {
            try
            {
                var parameters = new Dictionary<string, string>
                {
                    { "fileName",  fileName}
                };
                var encodedParameters = await new FormUrlEncodedContent(parameters).ReadAsStringAsync();
                return await _apiCall.GetAsync($"GetLabelToPrint", encodedParameters);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<string> PrintCoupon(string cnpj_emp, string serie, string nr_pedido)
        {
            var parameters = new Dictionary<string, string>
            {
                { "cnpj_emp", cnpj_emp },
                { "serie", serie },
                { "nr_pedido", nr_pedido }
            };
            var encodedParameters = await new FormUrlEncodedContent(parameters).ReadAsStringAsync();
            var result = await _apiCall.GetAsync("GetOrderToPresent", encodedParameters);
            var pedido = System.Text.Json.JsonSerializer.Deserialize<Order>(result);

            return await _apiCall.PostAsync($"PrintExchangeCupoun", System.Text.Json.JsonSerializer.Serialize(new { serializePedido = pedido }));
        }

        public async Task<bool> UpdateFlagPrinted(string nr_pedido)
        {
            try
            {
                return await _apiCall.PutAsync("UpdateFlagPrinted", System.Text.Json.JsonSerializer.Serialize(new { number = nr_pedido }));
            }
            catch
            {
                throw;
            }
        }
    }
}
