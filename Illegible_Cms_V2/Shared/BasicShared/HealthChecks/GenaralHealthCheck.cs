using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Illegible_Cms_V2.Shared.BasicShared.HealthChecks;

public class GeneralHealthCheck : IHealthCheck
{
    public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context,
        CancellationToken cancellationToken = new())
    {
        return HealthCheckResult.Healthy("Everything is Ok!");
    }
}