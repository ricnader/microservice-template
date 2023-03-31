using Azure.Extensions.AspNetCore.Configuration.Secrets;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

namespace Distribuitor.Api.Configurations
{
    public static class KeyVaultConfiguration
    {
        public static void AddKeyVaultConfigurations(this IServiceCollection service,
            WebApplicationBuilder builder)
        {
            var configuration = builder.Configuration;
            var kvUrl = configuration["keyVaultConfig:kvUrl"];
            var tenantId = configuration["keyVaultConfig:tenantId"];
            var clientId = configuration["keyVaultConfig:clientId"];
            var clientSecret = configuration["keyVaultConfig:clientSecretValue"];

            var credential = new ClientSecretCredential(tenantId, clientId, clientSecret);

            var client = new SecretClient(new Uri(kvUrl), credential);

            builder.Configuration.AddAzureKeyVault(client, new AzureKeyVaultConfigurationOptions());
        }
    }
}
