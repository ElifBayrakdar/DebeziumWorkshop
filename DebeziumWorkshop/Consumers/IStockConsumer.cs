using System.Threading.Tasks;

namespace DebeziumWorkshop.Consumers
{
    public interface IStockConsumer
    {
        Task Consume();
    }
}