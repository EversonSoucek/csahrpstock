using api.Dtos.Stock;
using api.helpers;
using api.models;

namespace api.interfaces
{
    public interface IStockRepository
    {
        Task<List<StockDto>> GetAllAsync(QueryObject query);
        Task<Stock?> GetByIdAsync(int id);
        Task<Stock> CreateAsync(Stock stockModel);
        Task<Stock?> UpdateAsync(int id, UpdateStockRequestDto stockDto);
        Task<Stock?> DeleteAsync(int id);
        Task<bool> StockExists(int id);
    }
}