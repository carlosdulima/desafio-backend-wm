using System.Collections.Generic;
using System.Threading.Tasks;
using Webmotors.ApplicationCore.Domains;
using Webmotors.ApplicationCore.Queries;

namespace Webmotors.ApplicationCore.UseCases.Interfaces
{
    public interface IGetModel
    {
        Task<IEnumerable<Model>> Execute(ModelQuery modelQuery);
    }
}
