using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;
using Webmotors.Infra.Gateways.Responses;

namespace Webmotors.Infra.Gateway.External
{
    public interface IDesafioOnlineWebmotorsGateway
    {
        [Get("/api/OnlineChallenge/Make")]
        Task<IEnumerable<WebmotorsMakeResponse>> GetMake();

        [Get("/api/OnlineChallenge/Model?MakeID={makeId}")]
        Task<IEnumerable<WebmotorsModelResponse>> GetModel(int makeId);

        [Get("/api/OnlineChallenge/Version?ModelID={modelId}")]
        Task<IEnumerable<WebmotorsVersionResponse>> GetVersion(int modelId);
    }
}
