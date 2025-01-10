using api.Dtos.Stock;
using api.models;
using csahrpstock.models;

namespace api.Mappers
{
    public static class StockMappers
    {
        public static StockDto ToStockDto(this Stock stockModel) {
            return new StockDto{
                Id = stockModel.Id,
                Symbol = stockModel.Symbol,
                CompanyName = stockModel.CompanyName,
                Industry = stockModel.Industry,
                LastDiv = stockModel.LastDiv,
                MarketCap = stockModel.MarketCap,
                Purchase = stockModel.Purchase,
                Comment = stockModel.Comment.Select(c => c.ToCommentDto()).ToList()
            };
        }

        public static Stock ToStockFromCreateDTO (this CreateStockRequestDto stockDto) {
            return new Stock {
                Symbol = stockDto.Symbol,
                CompanyName = stockDto.CompanyName,
                Industry = stockDto.Industry,
                LastDiv = stockDto.LastDiv,
                MarketCap = stockDto.MarketCap,
                Purchase = stockDto.Purchase
            };
        }

        public static Stock ToStockFromFMP (this FMPStock fmpStock) {
            return new Stock {
                Symbol = fmpStock.symbol,
                CompanyName = fmpStock.companyName,
                Industry = fmpStock.industry,
                LastDiv = (decimal)fmpStock.lastDiv,
                MarketCap = fmpStock.mktCap,
                Purchase = (decimal)fmpStock.price
            };
        }
    }
}