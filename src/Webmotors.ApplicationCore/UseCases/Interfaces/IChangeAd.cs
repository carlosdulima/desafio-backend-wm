using System.Threading.Tasks;
using Webmotors.ApplicationCore.Domains;

namespace Webmotors.ApplicationCore.UseCases.Interfaces
{
    public interface IChangeAd
    {
        Task Execute(Ad ad);
    }
}
