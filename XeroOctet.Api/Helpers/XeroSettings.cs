using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using Xero.NetStandard.OAuth2.Client;
using Xero.NetStandard.OAuth2.Config;

namespace XeroOctet.Api.Helpers
{
    public class XeroSettings : IXeroSettings
    {
        private readonly IConfiguration _config;
        public XeroSettings(IConfiguration config)
        {
            _config = config;
        }

        public async Task<string> GetXeroAccessToken()
        {
            XeroConfiguration XeroConfig = new XeroConfiguration
            {
                ClientId = _config["Xero:Client_Id"],
                ClientSecret = _config["Xero:Client_Secret"]

            };

            var client = new XeroClient(XeroConfig);
            var result = await client.RequestClientCredentialsTokenAsync();
            return result.AccessToken;
        }
    }
  }
