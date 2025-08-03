﻿namespace Application.Movidesk.Interfaces.Services
{
    public interface IMovideskService
    {
        public Task<bool> GetTicket();
        public Task<bool> GetTickets();

        public Task<bool> GetService();
        public Task<bool> GetServices();

        public Task<bool> GetPerson();
        public Task<bool> GetPersons();
    }
}
