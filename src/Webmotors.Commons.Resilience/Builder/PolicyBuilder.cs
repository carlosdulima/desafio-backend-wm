using Webmotors.Commons.Resilience.Interfaces;

namespace Webmotors.Commons.Resilience.Builder
{
    public class PolicyBuilder
    {
        public IHttpPolicyAsyncBuilder UseExecutorAsync() => new HttpPolicyAsyncBuilder();
    }
}
