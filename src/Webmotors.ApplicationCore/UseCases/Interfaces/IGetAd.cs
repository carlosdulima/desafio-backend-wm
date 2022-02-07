using System.Collections.Generic;
using System.Threading.Tasks;
using Webmotors.ApplicationCore.Domains;
using Webmotors.ApplicationCore.Queries;

namespace Webmotors.ApplicationCore.UseCases.Interfaces
{
    public interface IGetAd
    {
        Task<IEnumerable<Ad>> Execute();
        Task<IEnumerable<Ad>> Execute(AdQuery adQuery);
    }
}
