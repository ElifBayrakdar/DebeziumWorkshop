using System;
using System.Threading.Tasks;
using Confluent.Kafka;

namespace DebeziumWorkshop.Consumers
{
    public class StockConsumer : IStockConsumer
    {
        private readonly ConsumerConfig _config;

        public StockConsumer(ConsumerConfig config)
        {
            _config = config;
        }

        public Task Consume()
        {
            try
            {
                using var consumer = new ConsumerBuilder<Ignore, string>(_config).Build();
                Console.WriteLine("Listening the changes of stock...");
                consumer.Subscribe("127.0.0.1.dbo.Stock");

                while (true)
                {
                    ConsumeResult<Ignore, string> consumeResult =
                        consumer.Consume();

                    Console.WriteLine(consumeResult.Message.Value);

                    consumer.Commit(consumeResult);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}