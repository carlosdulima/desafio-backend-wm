using Webmotors.ApplicationCore.Domains;
using Webmotors.Infra.Repositories.Context;
using Webmotors.Infra.Repositories.Interfaces;

namespace Webmotors.Infra.Repositories
{
    public class AdRepository : Repository<Ad>, IAdRepository
    {
        public AdRepository(AdContext context) : base(context)
        {
        }
    }
}
