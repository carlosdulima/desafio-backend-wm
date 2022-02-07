using System.Collections.Generic;
using System.Threading.Tasks;
using Webmotors.ApplicationCore.Domains;
using Webmotors.ApplicationCore.Gateways;
using Webmotors.ApplicationCore.Queries;
using Webmotors.ApplicationCore.UseCases.Interfaces;

namespace Webmotors.ApplicationCore.UseCases
{
    public class GetVersion : IGetVersion
    {
        private readonly IVersionGateway _gateway;

        public GetVersion(IVersionGateway gateway)
        {
            _gateway = gateway;
        }

        public Task<IEnumerable<Version>> Execute(VersionQuery versionQuery)
        {
            return _gateway.Get(versionQuery.ModelId.Value);
        }
    }
}
