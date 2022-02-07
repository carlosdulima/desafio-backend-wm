using System.Collections.Generic;
using System.Threading.Tasks;
using Webmotors.ApplicationCore.Domains;

namespace Webmotors.ApplicationCore.Gateways
{
    public interface IMakeGateway
    {
        Task<IEnumerable<Make>> GetAll();
    }
}
