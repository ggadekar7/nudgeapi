using NudgeApi.Contracts.Interfaces;
using NudgeApi.DataContracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NudgeApi.Providers.LaptopProvider
{
    public class LaptopProvider : ILaptopProvider
    {
        private ILaptopService _laptopService;
        public LaptopProvider(ILaptopService laptopService)
        {
            _laptopService = laptopService;
        }

        public Task<bool> AddColorAsync(Color color)
        {
            return _laptopService.AddColorAsync(color);
        }

        public Task<bool> AddHddAsync(Hdd hdd)
        {
            return _laptopService.AddHddAsync(hdd);
        }

        public Task<LaptopResponse> AddLaptopAsync(Laptop laptop)
        {
            return _laptopService.AddLaptopAsync(laptop);
        }

        public Task<ShoppingCartResponse> AddLaptopToCartAsync(ShoppingCart shoppingCart)
        {
            return _laptopService.AddLaptopToCartAsync(shoppingCart);
        }

        public Task<bool> AddRamAsync(Ram ram)
        {
            return _laptopService.AddRamAsync(ram);
        }

        public Task<bool> CreateDbAsync()
        {
            return _laptopService.CreateDbAsync();
        }

        public Task<bool> DeleteConfiguration(DeleteConfigurationRequest deleteConfigurationRequest)
        {
            return _laptopService.DeleteConfiguration(deleteConfigurationRequest);
        }

        public Task<ShoppingCartResponse> GetCartItemsAsync()
        {
            return _laptopService.GetCartItemsAsync();
        }

        public Task<ConfigurationResponse> GetListOfConfigurationAsync()
        {
            return _laptopService.GetListOfConfigurationAsync();
        }

        public Task<LaptopResponse> GetListOfLaptopAsync()
        {
            //ILaptopService laptopService = _objectProvider.GetInstance<ILaptopService>();
            return _laptopService.GetListOfLaptopAsync();
        }

        public Task<Laptop> GetListOfLaptopByIdAsync(int id)
        {
            return _laptopService.GetListOfLaptopByIdAsync(id);
        }
    }
}
