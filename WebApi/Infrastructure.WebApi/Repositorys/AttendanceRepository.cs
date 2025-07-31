using Application.WebApi.Interfaces.Handlers.Commands;
using Domain.WebApi.Interfaces.Repositorys;
using Dapper;
using Infrastructure.Core.Connections.SQLServer;
using AttendenceOrder = Domain.Wms.Models.AttendenceOrder;
using Domain.Wms.Models;

namespace Infrastructure.WebApi.Repositorys
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly ISQLServerConnection _conn;
        private readonly IAttendanceCommandHandler _attendanceCommandHandler;

        public AttendanceRepository(ISQLServerConnection conn, IAttendanceCommandHandler attendanceCommandHandler) =>
            (_conn, _attendanceCommandHandler) = (conn, attendanceCommandHandler);

        public async Task<IEnumerable<AttendenceOrder>> GetOrdersToContact(string serie, string doc_company)
        {
            var sql = _attendanceCommandHandler.CreateGetOrdersToContactQuery(serie, doc_company);

            try
            {
                using (var conn = _conn.GetIDbConnection())
                {
                    var result = await conn.QueryAsync<AttendenceOrder, Client, AttendenceProduct, AttendenceOrder>(sql, (pedido, cliente, produto) =>
                    {
                        pedido.client = cliente;
                        pedido.itens.Add(produto);
                        return pedido;
                    }, splitOn: "cod_client, cod_product");

                    var pedidos = result.GroupBy(p => p.number).Select(g =>
                    {
                        var groupedOrder = g.First();
                        groupedOrder.itens = g.Select(p => p.itens.Single()).ToList();
                        return groupedOrder;
                    });

                    return pedidos;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"MiniWms [Attendance] - GetOrders - Erro ao obter pedidos na tabela IT4_WMS_DOCUMENTO  - {ex.Message}");
            }
        }

        public async Task<bool> UpdateDateContacted(string number, string atendente, string obs)
        {
            var sql = _attendanceCommandHandler.CreateUpdateDateContactedQuery(number, atendente, obs);

            try
            {
                using (var conn = _conn.GetIDbConnection())
                {
                    var result = await conn.ExecuteAsync(sql);

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"MiniWms [Attendance] - UpdateDateContacted - Erro ao atualizar data de contato do pedido {number} na tabela TB_NB_CANCELAMENTO_PEDIDOS  - {ex.Message}");
            }
        }
    }
}
