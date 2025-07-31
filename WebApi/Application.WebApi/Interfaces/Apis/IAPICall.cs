namespace Application.WebApi.Interfaces.Apis
{
    public interface IAPICall
    {
        public bool CallAPI(byte[] zpl, string path, string number, bool typeLabel);
    }
}
