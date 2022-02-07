using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webmotors.ApplicationCore.Domains;
using Webmotors.ApplicationCore.Gateways;
using Webmotors.Infra.Gateway.External;

namespace Webmotors.Infra.Gateways
{
    public class ModelGateway : IModelGateway
    {
        private readonly IDesafioOnlineWebmotorsGateway _desafioOnlineWebmotorsGateway;

        public ModelGateway(IDesafioOnlineWebmotorsGateway desafioOnlineWebmotorsGateway)
        {
            _desafioOnlineWebmotorsGateway = desafioOnlineWebmotorsGateway;
        }

        public async Task<IEnumerable<Model>> Get(int makeId)
        {
            var result = await _desafioOnlineWebmotorsGateway.GetModel(makeId);

            return result.Select(x => new Model
            {
                Id = x.Id,
                Name = x.Name
            });
        }
    }
}
