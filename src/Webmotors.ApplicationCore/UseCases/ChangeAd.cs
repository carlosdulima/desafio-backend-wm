using System.Threading.Tasks;
using Webmotors.ApplicationCore.Domains;
using Webmotors.ApplicationCore.Gateways;
using Webmotors.ApplicationCore.UseCases.Interfaces;

namespace Webmotors.ApplicationCore.UseCases
{
    public class ChangeAd : IChangeAd
    {
        private readonly IAdGateway _gateway;

        public ChangeAd(IAdGateway adGateway)
        {
            _gateway = adGateway;
        }

        public async Task Execute(Ad ad)
        {
            var result = await _gateway.Get(ad.Id);

            result.Make = ad.Make;
            result.Model = ad.Model;
            result.Version = ad.Version;
            result.YearModel = ad.YearModel;
            result.KM = ad.KM;
            result.Note = ad.Note;

            await _gateway.Upsert(ad);
            return;
        }
    }
}
