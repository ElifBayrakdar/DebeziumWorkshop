using System.Threading;
using System.Threading.Tasks;
using DebeziumWorkshop.Consumers;
using Microsoft.Extensions.Hosting;

namespace DebeziumWorkshop
{
    public class StockWorker : BackgroundService
    {
        private readonly IStockConsumer _consumer;

        public StockWorker(IStockConsumer consumer)
        {
            _consumer = consumer;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            System.Console.WriteLine("StockWorker started...");

            Task
                .Run(async () => { await _consumer.Consume(); },
                    stoppingToken);

            return Task.CompletedTask;
        }
    }
}