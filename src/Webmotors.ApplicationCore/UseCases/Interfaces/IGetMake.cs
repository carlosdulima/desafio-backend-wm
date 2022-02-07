using System.Collections.Generic;
using System.Threading.Tasks;
using Webmotors.ApplicationCore.Domains;

namespace Webmotors.ApplicationCore.UseCases.Interfaces
{
    public interface IGetMake
    {
        Task<IEnumerable<Make>> Execute();
    }
}
