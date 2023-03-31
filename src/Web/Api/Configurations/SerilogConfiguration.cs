using Serilog.Events;
using Serilog;
using Serilog.Sinks.Graylog;
using Serilog.Sinks.Graylog.Core.Transport;

namespace Distribuitor.Api.Configurations
{
    public static class SerilogConfiguration
    {
        public static void AddSerilogApi(IConfiguration configuration)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Information)
                .Enrich.FromLogContext()
                .Enrich.WithProperty("source", "agrega-admin-api-dev")
                .WriteTo.Graylog(
                    new GraylogSinkOptions
                    {
                        HostnameOrAddress = "prdlogsrv.grupoltm.com.br",
                        Port = 12201,
                        TransportType = TransportType.Udp,
                        MinimumLogEventLevel = LogEventLevel.Information
                    }
                )
                .CreateLogger();
        }
    }
}
