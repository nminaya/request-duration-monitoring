# request-duration-monitoring
This library has a HttpClientHandler to measure the Http request time duration.

Use:

  ```csharp
    using (var client = new HttpClient(new MetricsHttpClientHandler()))
    {
        var result = await client.GetAsync("https://www.google.com.do/");
    }
  ```
The class HttpClient receives a HttpClientHandler throught the constructor. This is the MetricsHttpClientHandler.

In the MetricsHttpClientHandler, at the SendAsync method, at the bottom of the finally, the logging service must be implemented.

  ```csharp
    ...
    finally
    {
        stopwatch.Stop(); // Stopping timer

        // Creating RequestResult
        var requestResult = new RequestResult
        {
          ElapsedMilliseconds = stopwatch.ElapsedMilliseconds,
          Url = request.RequestUri.LocalPath,
          Successful = successful
        };

        // Log here the RequestResult
        // Example
        // _logService.LogRequestDuration(requestResult);
    }
  ```
