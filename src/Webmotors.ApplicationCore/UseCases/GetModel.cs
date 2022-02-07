using System.Collections.Generic;
using System.Threading.Tasks;
using Webmotors.ApplicationCore.Domains;
using Webmotors.ApplicationCore.Gateways;
using Webmotors.ApplicationCore.Queries;
using Webmotors.ApplicationCore.UseCases.Interfaces;

namespace Webmotors.ApplicationCore.UseCases
{
    public class GetModel : IGetModel
    {
        private readonly IModelGateway _gateway;

        public GetModel(IModelGateway gateway)
        {
            _gateway = gateway;
        }

        public Task<IEnumerable<Model>> Execute(ModelQuery modelQuery)
        {
            return _gateway.Get(modelQuery.MakeId.Value);
        }
    }
}
