using api.data;
using api.Dtos.Stock;
using api.helpers;
using api.interfaces;
using api.Mappers;
using api.models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDBContext _context;
        public StockRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Stock> CreateAsync(Stock stockModel)
        {
            await _context.Stock.AddAsync(stockModel);
            await _context.SaveChangesAsync();
            return stockModel;
        }

        public async Task<Stock?> DeleteAsync(int id)
        {
            var stockModel = await _context.Stock.FirstOrDefaultAsync(stock => stock.Id == id);
            if (stockModel == null)
            {
                return null;
            }
            _context.Stock.Remove(stockModel);
            await _context.SaveChangesAsync();
            return stockModel;
        }

        public async Task<List<StockDto>> GetAllAsync(QueryObject query)
        {
            var stocks = _context.Stock.Include(c => c.Comment).AsQueryable();
            if(!string.IsNullOrWhiteSpace(query.CompanyName)){
                stocks = stocks.Where(stock => stock.CompanyName.Contains(query.CompanyName));
            }
            if(!string.IsNullOrWhiteSpace(query.Symbol)){
                stocks = stocks.Where(stock => stock.Symbol.Contains(query.Symbol));
            }

            if(!string.IsNullOrWhiteSpace(query.Sortby)){
                if(query.Sortby.Equals("Symbol", StringComparison.OrdinalIgnoreCase)) {
                    stocks = query.IsDecsending ? stocks.OrderByDescending(s => s.Symbol) : stocks.OrderBy(s => s.Symbol);
                }
            }

            var skipNumber = (query.PageNumber - 1) * query.PageNumber;

            return await stocks.Skip(skipNumber).Take(query.PageSize).Select(s => s.ToStockDto()).ToListAsync();
        }

        public async Task<Stock?> GetByIdAsync(int id)
        {
            var stock = await _context.Stock.Include(c => c.Comment).FirstOrDefaultAsync(i => i.Id == id);
            return stock;
        }

        public async Task<Stock?> GetSymbol(string symbol)
        {
            return await _context.Stock.FirstOrDefaultAsync(s => s.Symbol == symbol);
        }

        public Task<bool> StockExists(int id)
        {
            return _context.Stock.AnyAsync(s => s.Id == id);
        }

        public async Task<Stock?> UpdateAsync(int id, UpdateStockRequestDto stockDto)
        {
            var stockModel = _context.Stock.FirstOrDefault(stock => stock.Id == id);
            if (stockModel == null)
            {
                return null;
            }
            stockModel.Symbol = stockDto.Symbol;
            stockModel.CompanyName = stockDto.CompanyName;
            stockModel.Purchase = stockDto.Purchase;
            stockModel.LastDiv = stockDto.LastDiv;
            stockModel.Industry = stockDto.Industry;
            stockModel.MarketCap = stockDto.MarketCap;

            await _context.SaveChangesAsync();
            return stockModel;
        }
    }
}