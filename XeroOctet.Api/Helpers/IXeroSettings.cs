using System.Threading.Tasks;

namespace XeroOctet.Api.Helpers
{
    public interface IXeroSettings
    {
        Task<string> GetXeroAccessToken();
    }
}
