using Application.Jadlog.Interfaces;
using Domain.Jadlog.Interfaces.Api;
using Domain.Jadlog.Interfaces.Repositorys;

namespace Application.Jadlog.Services
{
    public class JadlogService : IJadlogService
    {
        private readonly IAPICall _apiCall;
        private readonly IJadlogRepository _jadlogRepository;

        public JadlogService(IJadlogRepository jadlogRepository, IAPICall apiCall) =>
            (_jadlogRepository, _apiCall) = (jadlogRepository, apiCall);

        public Task<bool?> CancelOrder()
        {
            throw new NotImplementedException();
        }

        public Task<bool?> InsertOrder()
        {
            throw new NotImplementedException();
        }

        public Task<bool?> InsertTreatment()
        {
            throw new NotImplementedException();
        }

        public Task<bool?> SearchDACTEXml()
        {
            throw new NotImplementedException();
        }

        public Task<bool?> SearchPickupPoints()
        {
            throw new NotImplementedException();
        }

        public Task<bool?> SearchQRCodePickupDropoff()
        {
            throw new NotImplementedException();
        }

        public Task<bool?> SearchShippingValue()
        {
            throw new NotImplementedException();
        }

        public Task<bool?> TrackingHistory()
        {
            throw new NotImplementedException();
        }
    }
}
