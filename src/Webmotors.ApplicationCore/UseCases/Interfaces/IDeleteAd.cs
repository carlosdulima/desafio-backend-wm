using System.Threading.Tasks;

namespace Webmotors.ApplicationCore.UseCases.Interfaces
{
    public interface IDeleteAd
    {
        Task Execute(int id);
    }
}
