
namespace Domain.IntegrationsCore.Interfaces
{
    public interface ILogMsgsDetail
    {
         int? IdLogMsgDetail { get; set; }
         int? IdLogMsg { get; set; }
         string FieldKeyValue { get; set; } 
         string? RegText { get; set; }
         DateTime LastUpdateOn { get; set; }
    }
}
