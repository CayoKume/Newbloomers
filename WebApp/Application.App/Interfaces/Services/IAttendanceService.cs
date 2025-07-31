using Application.App.ViewModels.Attendance;

namespace Application.App.Interfaces.Services
{
    public interface IAttendanceService
    {
        public Task<List<Order>> GetOrdersToContact(string serie, string doc_company);
        public Task<bool> UpdateDateContacted(string number, string atendente, string inputObs);
    }
}
