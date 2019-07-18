using AnyStatus.API;
using AnyStatus.Plugins.Additional.Widgets.BC.HTTP.Models;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;

namespace AnyStatus.Plugins.Additional
{
    public class BcHTTPHealthCheck : ICheckHealth<BcHttpStatus>
    {
        [DebuggerStepThrough]
        public async Task Handle(HealthCheckRequest<BcHttpStatus> request, CancellationToken cancellationToken)
        {
            using (var handler = new HttpClientHandler())
            {
                //if (!string.IsNullOrWhiteSpace(request.DataContext.CertificateFile)) {
                //    X509Certificate2 certificate;
                //    if (string.IsNullOrWhiteSpace(request.DataContext.CertificatePassword)) {
                //        certificate = new X509Certificate2(request.DataContext.CertificateFile);
                //    } else
                //    {
                //        certificate = new X509Certificate2(request.DataContext.CertificateFile, request.DataContext.CertificatePassword);
                //    }
                //    handler.ClientCertificateOptions = ClientCertificateOption.Automatic;
                //}

                handler.ClientCertificateOptions = ClientCertificateOption.Automatic;

                try
                {
                    using (var client = new HttpClient(handler))
                    {
                        var response = await client.GetAsync(request.DataContext.Url).ConfigureAwait(false);

                        var responseBody = await response.Content.ReadAsStringAsync();

                        if (request.DataContext.IsHealthCheck)
                        {
                            
                            var result = JsonConvert.DeserializeObject<HealthCheckResult>(responseBody);

                            request.DataContext.State = result.allChecksPassed ? State.Ok : State.Failed;
                            if (!result.allChecksPassed)
                            {
                                throw new Exception("Error in Health Check: " + responseBody);
                            }
                            
                        } else
                        {
                            request.DataContext.State = response.IsSuccessStatusCode ? State.Ok : State.Failed;
                            if (!response.IsSuccessStatusCode)
                            {
                                throw new Exception("Error in request: " + responseBody);
                            }
                        }

                        
                    }
                }
                catch (AggregateException ae)
                {
                    ae.Handle(ex =>
                    {
                        if (ex is HttpRequestException)
                            request.DataContext.State = State.Failed;

                        return ex is HttpRequestException;
                    });
                }
            }
        }
    }
}