using System.Collections.Generic;
using System.Threading.Tasks;
using Webmotors.ApplicationCore.Domains;
using Webmotors.ApplicationCore.Gateways;
using Webmotors.ApplicationCore.UseCases.Interfaces;

namespace Webmotors.ApplicationCore.UseCases
{
    public class GetMake : IGetMake
    {
        private readonly IMakeGateway _gateway;

        public GetMake(IMakeGateway gateway)
        {
            _gateway = gateway;
        }

        public Task<IEnumerable<Make>> Execute()
        {
            return _gateway.GetAll();
        }
    }
}
