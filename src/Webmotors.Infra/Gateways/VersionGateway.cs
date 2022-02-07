using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webmotors.ApplicationCore.Domains;
using Webmotors.ApplicationCore.Gateways;
using Webmotors.Infra.Gateway.External;

namespace Webmotors.Infra.Gateways
{
    public class VersionGateway : IVersionGateway
    {
        private readonly IDesafioOnlineWebmotorsGateway _desafioOnlineWebmotorsGateway;

        public VersionGateway(IDesafioOnlineWebmotorsGateway desafioOnlineWebmotorsGateway)
        {
            _desafioOnlineWebmotorsGateway = desafioOnlineWebmotorsGateway;
        }

        public async Task<IEnumerable<Version>> Get(int modelId)
        {
            var result = await _desafioOnlineWebmotorsGateway.GetVersion(modelId);

            return result.Select(x => new Version
            {
                Id = x.Id,
                Name = x.Name
            });
        }
    }
}
