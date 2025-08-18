using Domain.WebApi.Models;

namespace Domain.WebApi.Interfaces.Repositorys
{
    public interface IAttendanceRepository
    {
        public Task<IEnumerable<AttendenceOrder>> GetOrdersToContact(string serie, string doc_company);
        public Task<bool> UpdateDateContacted(string number, string atendente, string obs);
    }
}
