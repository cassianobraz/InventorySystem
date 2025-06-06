﻿using InventorySystem.Api.Infrastructure;
using InventorySystem.Communication.Responses;

namespace InventorySystem.Api.UseCases.Stocks.GetAll
{
    public class GetAllInventoryUseCase
    {
        private readonly InventoryDBContext _dbContext;

        public GetAllInventoryUseCase(InventoryDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ResponseAllStocksJson Execute()
        {
            var stocks = _dbContext.Stocks.ToList();

            return new ResponseAllStocksJson
            {
                Stocks = stocks.Select(stock => new ResponseShortInventoryJson
                {
                    Id = stock.Id,
                    NameProduct = stock.NameProduct,
                    Amount = stock.Amount,
                    Price = stock.Price,
                    Create_at = stock.Create_at,
                }).ToList(),
            };
        }
    }
}