using Dapper;
using Domain.Dootax.Entities;
using Domain.Dootax.Interfaces.Repositorys;
using Domain.Core.Enums;
using Domain.Core.Entities.Exceptions;
using Infrastructure.Core.Connections.SQLServer;
using Application.Dootax.Interfaces.Handlers.Commands;
using Domain.Core.Interfaces;

namespace Infrastructure.Dootax.Repositorys
{
    public class DootaxRepository : IDootaxRepository
    {
        private readonly ICoreRepository _coreRepository;
        private readonly IDootaxCommandHandler _dootaxCommandHandler;

        public DootaxRepository(ICoreRepository coreRepository, IDootaxCommandHandler dootaxCommandHandler) =>
            (_coreRepository, _dootaxCommandHandler) = (coreRepository, dootaxCommandHandler);

        public async Task<IEnumerable<XML>> GetXMLs()
        {
            var sql = _dootaxCommandHandler.CreateGetXMLsQuery();
            return await _coreRepository.GetRecords<XML>(sql);
        }

        public async Task InsertSendFilesSuccessfulLog(string cnpjcpf, string documento, string serie, string chavenfe)
        {
            var sql = _dootaxCommandHandler.CreateSuccessfulLogQuery();
            
            await _coreRepository.ExecuteCommand(sql, new
            {
                cnpj_emp = cnpjcpf,
                documento = documento,
                serie = serie,
                chave_nfe = chavenfe,
                dt_insert = DateTime.Now
            });
        }
    }
}
