using StockTrader.Domain.Models;
using System.Threading.Tasks;

namespace StockTrader.Domain.Services
{
    public interface IMajorIndexService
    {
        Task<MajorIndex> GetMajorIndex(MajorIndexType IndexType);
    }
}
