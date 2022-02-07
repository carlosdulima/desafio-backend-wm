using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webmotors.ApplicationCore.Domains;
using Webmotors.ApplicationCore.Gateways;
using Webmotors.Infra.Gateway.External;

namespace Webmotors.Infra.Gateways
{
    public class MakeGateway : IMakeGateway
    {
        private readonly IDesafioOnlineWebmotorsGateway _desafioOnlineWebmotorsGateway;

        public MakeGateway(IDesafioOnlineWebmotorsGateway desafioOnlineWebmotorsGateway)
        {
            _desafioOnlineWebmotorsGateway = desafioOnlineWebmotorsGateway;
        }

        public async Task<IEnumerable<Make>> GetAll()
        {
            var result = await _desafioOnlineWebmotorsGateway.GetMake();

            return result.Select(x => new Make
            {
                Id = x.Id,
                Name = x.Name
            });
        }
    }
}
