using System.Diagnostics;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Metrics.Library
{
	public class MetricHttpClientHandler : HttpClientHandler
	{
		protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			bool successful = false;
			var stopwatch = Stopwatch.StartNew();

			try
			{
				var result = await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
				successful = result.IsSuccessStatusCode;

				return result;
			}
			finally
			{
				stopwatch.Stop();
			}
		}
	}
}