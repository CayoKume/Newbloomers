using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Application.IntegrationsCore.Interfaces;
using Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce;

namespace Application.LinxMicrovix.Outbound.WebService.Interfaces.Cache.LinxCommerce
{
    public interface IB2CConsultaProdutosDimensoesServiceCache : ICacheService<B2CConsultaProdutosDimensoes>
    {
        
    }
}
