using Confluent.Kafka;
using DebeziumWorkshop.Consumers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DebeziumWorkshop
{
    class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host
                .CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services
                        .AddHostedService<StockWorker>()
                        .AddTransient<IStockConsumer, StockConsumer>()
                        .AddSingleton<ConsumerConfig>(option =>
                        {
                            var _config =
                                new ConsumerConfig
                                {
                                    GroupId = "available-stock-consumer",
                                    BootstrapServers = "127.0.0.1:9092",
                                    AllowAutoCreateTopics = true
                                };
                            return _config;
                        });
                });
    }
}