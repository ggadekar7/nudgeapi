using NudgeApi.DataContracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NudgeApi.Contracts.Interfaces
{
    public interface ILaptopProvider
    {
        Task<LaptopResponse> GetListOfLaptopAsync();
        Task<ConfigurationResponse> GetListOfConfigurationAsync();
        Task<LaptopResponse> AddLaptopAsync(Laptop laptop);
        Task<ShoppingCartResponse> AddLaptopToCartAsync(ShoppingCart shoppingCart);
        Task<bool> CreateDbAsync();
        Task<Laptop> GetListOfLaptopByIdAsync(int id);
        Task<ShoppingCartResponse> GetCartItemsAsync();
        Task<bool> AddRamAsync(Ram ram);
        Task<bool> AddHddAsync(Hdd hdd);
        Task<bool> AddColorAsync(Color color);
        Task<bool> DeleteConfiguration(DeleteConfigurationRequest deleteConfigurationRequest);
    }
}
