using System.Collections.Generic;
using System.Threading.Tasks;
using Webmotors.ApplicationCore.Domains;

namespace Webmotors.ApplicationCore.Gateways
{
    public interface IVersionGateway
    {
        Task<IEnumerable<Version>> Get(int modelId);
    }
}
