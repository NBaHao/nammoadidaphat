﻿using CoolMate.Models;

namespace CoolMate.Repositories.Interfaces
{
    public interface IShopOrderRepository
    {
        Task<IEnumerable<ShopOrder>> GetShopOrdersAsync();
        Task<ShopOrder> GetByIdAsync(int id);
        Task<IEnumerable<ShopOrder>> GetOrdersOfUserAsync(string userId);
        Task createShopOrderAsync(ShopOrder shopOrder);
        Task<bool> updateOrderStatusAsync(int orderId, int status);
        Task<bool> IsProductItemOrderedAsync(string? userId, int? ProductId);
        Task RemoveOrderAsync(ShopOrder order);
        Task<IEnumerable<object>> GetBestSellerAsync();
        Task<object> GetLifeTimeSalesAsync();
        Task<object> GetSalesByMonthAsync();
        Task<object> GetSalesByWeekAsync();
        Task<object> GetSalesByDayAsync();
    }
}
