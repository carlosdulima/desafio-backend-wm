using System.Threading.Tasks;
using Webmotors.ApplicationCore.Gateways;
using Webmotors.ApplicationCore.UseCases.Interfaces;

namespace Webmotors.ApplicationCore.UseCases
{
    public class DeleteAd : IDeleteAd
    {
        private readonly IAdGateway _gateway;

        public DeleteAd(IAdGateway adGateway)
        {
            _gateway = adGateway;
        }

        public async Task Execute(int id)
        {
            var ad = await _gateway.Get(id);
            await _gateway.Delete(ad);
            return;
        }
    }
}
