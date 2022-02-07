using System.Threading.Tasks;
using Webmotors.ApplicationCore.Domains;
using Webmotors.ApplicationCore.Gateways;
using Webmotors.ApplicationCore.UseCases.Interfaces;

namespace Webmotors.ApplicationCore.UseCases
{
    public class CreateAd : ICreateAd
    {
        private readonly IAdGateway _adGateway;

        public CreateAd(IAdGateway adGateway)
        {
            _adGateway = adGateway;
        }

        public Task Execute(Ad ad)
        {
            return _adGateway.Create(ad);
        }
    }
}
