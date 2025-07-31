using Application.WebApi.Interfaces.Handlers.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.WebApi.Handlers.Commands
{
    public class CompanyCommandHandler : ICompanyCommandHandler
    {
        public string CreateGetCompanysQuery()
        {
            return $@"SELECT 
                         EMPRESA AS COD_COMPANY,
                         CNPJ_EMP AS DOC_COMPANY,
                         RAZAO_EMP AS REASON_COMPANY,
                         NOME_EMP AS NAME_COMPANY,
                         EMAIL_EMP AS EMAIL_COMPANY,
                         ENDERECO_EMP AS ADDRESS_COMPANY,
                         NUM_EMP AS STREET_NUMBER_COMPANY,
                         COMPLEMENT_EMP AS COMPLEMENT_ADDRESS_COMPANY,
                         BAIRRO_EMP AS NEIGHBORHOOD_COMPANY,
                         CIDADE_EMP AS CITY_COMPANY,
                         ESTADO_EMP AS UF_COMPANY,
                         CEP_EMP AS ZIP_CODE_COMPANY,
                         FONE_EMP AS FONE_COMPANY,
                         INSCRICAO_EMP AS STATE_REGISTRATION_COMPANY,
                         INSCRICAO_MUNICIPAL_EMP AS MUNICIPAL_REGISTRATION_COMPANY
                         FROM BLOOMERS_LINX..LINXLOJAS_TRUSTED (NOLOCK)
                         WHERE EMPRESA != 0
                         ORDER BY EMPRESA ASC";
        }

        public string CreateGetUsersQuery()
        {
            throw new NotImplementedException();
        }
    }
}
