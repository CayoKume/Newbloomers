﻿using Domain.Jadlog.Entities;

namespace Domain.Jadlog.Interfaces.Repositorys
{
    public interface IJadlogRepository
    {
        public Task<bool> BulkInsertIntoTableRaw(List<Consulta> records, Guid? parentExecutionGUID);
        public Task InsertResponse(string pedido, string request, InsertResponse response);
        public Task<List<ShipmentId>> GetShipmentIds();
        public Task<Order> GetInvoicedOrder(string orderNumber);
        public Task<List<Order>> GetInvoicedOrders();
        public Task<IEnumerable<Parameters>> GetParameters();
        public Task<Parameters> GetParameters(string doc_company, string tipo_servico);
    }
}
