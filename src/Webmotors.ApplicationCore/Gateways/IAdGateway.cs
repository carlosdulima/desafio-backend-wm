using System.Collections.Generic;
using System.Threading.Tasks;
using Webmotors.ApplicationCore.Domains;
using Webmotors.ApplicationCore.Queries;

namespace Webmotors.ApplicationCore.Gateways
{
    public interface IAdGateway
    {
        Task<Ad> Get(int id);
        Task<IEnumerable<Ad>> GetAll();
        Task<IEnumerable<Ad>> GetAll(AdQuery adQuery);
        Task<Ad> Create(Ad ad);
        Task<Ad> Upsert(Ad ad);
        Task Delete(Ad ad);
    }
}
