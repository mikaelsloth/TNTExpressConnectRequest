namespace TNTExpressConnectRequest.Tests
{
    using Microsoft.Extensions.Configuration;
    using System;
    using System.Configuration;
    using System.Reflection.Metadata.Ecma335;

    internal class ExpressConnectCredentials
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Account { get; set; }

        private ExpressConnectCredentials()
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("Sensitive.json")
                .AddEnvironmentVariables()
                .Build();

            // Get values from the config, given their key and their target type.
            Username = config.GetRequiredSection("Settings").GetValue<string>("Username") ?? string.Empty;
            Password = config.GetRequiredSection("Settings").GetValue<string>("Password") ?? string.Empty;
            Account = config.GetRequiredSection("Settings").GetValue<string>("Account") ?? string.Empty;
        }

        private static readonly Lazy<ExpressConnectCredentials> lazy = new(() => new ExpressConnectCredentials());

        public static ExpressConnectCredentials Instance => lazy.Value;
    }
}
