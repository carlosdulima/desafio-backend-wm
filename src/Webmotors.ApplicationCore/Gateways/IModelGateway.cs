using System.Collections.Generic;
using System.Threading.Tasks;
using Webmotors.ApplicationCore.Domains;

namespace Webmotors.ApplicationCore.Gateways
{
    public interface IModelGateway
    {
        Task<IEnumerable<Model>> Get(int makeId);
    }
}
