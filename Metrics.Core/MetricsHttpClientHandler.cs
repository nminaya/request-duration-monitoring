using System.Diagnostics;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Metrics.Core.Models;

namespace Metrics.Core
{
	public class MetricsHttpClientHandler : HttpClientHandler
	{
		protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			bool successful = false;
			var stopwatch = Stopwatch.StartNew(); // to measure time

			try
			{
				var result = await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
				successful = result.IsSuccessStatusCode;

				return result;
			}
			finally
			{
				stopwatch.Stop();

				var requestResult = new RequestResult
				{
					ElapsedMilliseconds = stopwatch.ElapsedMilliseconds,
					Url = request.RequestUri.LocalPath,
					Successful = successful
				};

				// Log here the RequestResult
			}
		}
	}
}