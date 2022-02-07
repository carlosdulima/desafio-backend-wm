using System.Collections.Generic;
using System.Threading.Tasks;
using Webmotors.ApplicationCore.Domains;
using Webmotors.ApplicationCore.Gateways;
using Webmotors.ApplicationCore.Queries;
using Webmotors.ApplicationCore.UseCases.Interfaces;

namespace Webmotors.ApplicationCore.UseCases
{
    public class GetAd : IGetAd
    {
        private readonly IAdGateway _adGateway;

        public GetAd(IAdGateway adGateway)
        {
            _adGateway = adGateway;
        }

        public Task<IEnumerable<Ad>> Execute()
        { 
            return _adGateway.GetAll();
        }
        public Task<IEnumerable<Ad>> Execute(AdQuery adQuery)
        {
            return _adGateway.GetAll(adQuery);
        }
    }
}
