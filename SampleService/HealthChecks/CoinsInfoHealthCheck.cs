using System.Net.NetworkInformation;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Options;
using SampleService.Configuration;

namespace SampleService.HealthChecks
{
    public class CoinsInfoHealthCheck : IHealthCheck
    {
        private readonly ServiceSettings _settings;

        public CoinsInfoHealthCheck(IOptions<ServiceSettings> settings)
        {
            _settings = settings.Value;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            Ping ping = new(); 

            var url = "172.67.68.79";
            var reply = await ping.SendPingAsync(url);

            if(reply.Status != IPStatus.Success)
                return HealthCheckResult.Unhealthy();

            return HealthCheckResult.Healthy();
        }
    }
}