﻿using Domain.LinxCommerce.Entities.Parameters;

namespace Domain.LinxCommerce.Interfaces.Api
{
    public interface IAPICall
    {
        public Task<bool> PostRequest(LinxCommerceJobParameter jobParameter, string? route, object objRequest);
        public Task<string> PostRequest(LinxCommerceJobParameter jobParameter, object objRequest, string? route);
        public Task<string> PostRequest(LinxCommerceJobParameter jobParameter, string stringIdentifier, string? route);
        public Task<string> PostRequest(LinxCommerceJobParameter jobParameter, int intIdentifier, string? route);
    }
}
