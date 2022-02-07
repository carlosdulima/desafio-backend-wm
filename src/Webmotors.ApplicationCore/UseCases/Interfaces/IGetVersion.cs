using System.Collections.Generic;
using System.Threading.Tasks;
using Webmotors.ApplicationCore.Domains;
using Webmotors.ApplicationCore.Queries;

namespace Webmotors.ApplicationCore.UseCases.Interfaces
{
    public interface IGetVersion
    {
        Task<IEnumerable<Version>> Execute(VersionQuery versionQuery);
    }
}
