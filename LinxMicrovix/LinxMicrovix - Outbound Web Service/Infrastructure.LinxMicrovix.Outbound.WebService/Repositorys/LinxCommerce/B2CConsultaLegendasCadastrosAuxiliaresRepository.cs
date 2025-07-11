﻿using Domain.IntegrationsCore.Entities.Exceptions;
using Domain.IntegrationsCore.Enums;
using Domain.LinxMicrovix.Outbound.WebService.Entities.LinxCommerce;
using Domain.LinxMicrovix.Outbound.WebService.Entities.Parameters;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.Base;
using Domain.LinxMicrovix.Outbound.WebService.Interfaces.Repositorys.LinxCommerce;

namespace Infrastructure.LinxMicrovix.Outbound.WebService.Repository.LinxCommerce
{
    public class B2CConsultaLegendasCadastrosAuxiliaresRepository : IB2CConsultaLegendasCadastrosAuxiliaresRepository
    {
        private readonly ILinxMicrovixRepositoryBase<B2CConsultaLegendasCadastrosAuxiliares> _linxMicrovixRepositoryBase;


        public B2CConsultaLegendasCadastrosAuxiliaresRepository(ILinxMicrovixRepositoryBase<B2CConsultaLegendasCadastrosAuxiliares> linxMicrovixRepositoryBase) =>
            (_linxMicrovixRepositoryBase) = (linxMicrovixRepositoryBase);

        public bool BulkInsertIntoTableRaw(LinxAPIParam jobParameter, IList<B2CConsultaLegendasCadastrosAuxiliares> records)
        {
            var table = _linxMicrovixRepositoryBase.CreateSystemDataTable(jobParameter.tableName, new B2CConsultaLegendasCadastrosAuxiliares());

            for (int i = 0; i < records.Count(); i++)
            {
                table.Rows.Add(records[i].lastupdateon, records[i].empresa, records[i].legenda_setor, records[i].legenda_linha, records[i].legenda_marca, records[i].legenda_colecao, records[i].legenda_grade1, records[i].legenda_grade2,
                    records[i].legenda_espessura, records[i].legenda_classificacao, records[i].timestamp);
            }

            _linxMicrovixRepositoryBase.BulkInsertIntoTableRaw(
                dataTable: table
            );

            return true;
        }

        public async Task<IEnumerable<string?>> GetRegistersExists(LinxAPIParam jobParameter, List<B2CConsultaLegendasCadastrosAuxiliares> registros)
        {
            var identificadores = String.Empty;
            for (int i = 0; i < registros.Count(); i++)
            {
                if (i == registros.Count() - 1)
                    identificadores += $"'{registros[i].empresa}'";
                else
                    identificadores += $"'{registros[i].empresa}', ";
            }

            string sql = $"SELECT CONCAT('[', EMPRESA, ']', '|', '[', [TIMESTAMP], ']') FROM [linx_microvix_commerce].[B2CCONSULTALEGENDASCADASTROSAUXILIARES] WHERE EMPRESA IN ({identificadores})";

            return await _linxMicrovixRepositoryBase.GetKeyRegistersAlreadyExists(sql);
        }
    }
}
