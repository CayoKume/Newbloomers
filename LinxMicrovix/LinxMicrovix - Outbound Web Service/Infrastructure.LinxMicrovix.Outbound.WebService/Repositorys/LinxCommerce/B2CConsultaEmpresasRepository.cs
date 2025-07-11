using Domain.IntegrationsCore.Entities.Exceptions;
using Domain.IntegrationsCore.Enums;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxCommerce
{
    public class B2CConsultaEmpresasRepository : IB2CConsultaEmpresasRepository
    {
        private readonly ILinxMicrovixRepositoryBase<B2CConsultaEmpresas> _linxMicrovixRepositoryBase;

        public B2CConsultaEmpresasRepository(ILinxMicrovixRepositoryBase<B2CConsultaEmpresas> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<B2CConsultaEmpresas> records)
        {
            var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter.tableName, new B2CConsultaEmpresas());

            for (int i = 0; i < records.Count(); i++)
            {
                table.Rows.Add(records[i].lastupdateon, records[i].empresa, records[i].nome_emp, records[i].cnpj_emp, records[i].end_unidade, records[i].complemento_end_unidade,
                    records[i].nr_rua_unidade, records[i].bairro_unidade, records[i].cep_unidade, records[i].cidade_unidade, records[i].uf_unidade, records[i].email_unidade, records[i].timestamp,
                    records[i].data_criacao, records[i].centro_distribuicao, records[i].portal);
            }

            _linxMicrovixRepositoryBase.BulkInsertIntoTableRaw(
                dataTable: table
            );

            return true;
        }

        public async Task<IEnumerable<string?>> GetRegistersExists(LinxAPIParam jobParameter, List<string?> registros)
        {
            var identificadores = String.Empty;
            for (int i = 0; i < registros.Count(); i++)
            {
                if (i == registros.Count() - 1)
                    identificadores += $"'{registros[i]}'";
                else
                    identificadores += $"'{registros[i]}', ";
            }

            string sql = $"SELECT CONCAT('[', EMPRESA, ']', '|', '[', CNPJ_EMP, ']', '|', '[', [TIMESTAMP], ']') FROM [linx_microvix_commerce].[B2CCONSULTAEMPRESAS] WHERE CNPJ_EMP IN ({identificadores})";

            return await _linxMicrovixRepositoryBase.GetKeyRegistersAlreadyExists(sql);
        }
    }
}
