using Microsoft.EntityFrameworkCore;
using Webmotors.ApplicationCore.Domains;

namespace Webmotors.Infra.Repositories.Context
{
    public partial class AdContextoDbSets
    {
        public DbSet<Ad> Ads { get; set; }
    }
}
