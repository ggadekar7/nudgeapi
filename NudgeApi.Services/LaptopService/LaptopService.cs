using NudgeApi.Contracts.Interfaces;
using DC=NudgeApi.DataContracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Model=NudgeApi.Models;
using AutoMapper;
using NudgeApi.DataContracts;

namespace NudgeApi.Services.LaptopService
{
    public class LaptopService : ILaptopService
    {
        private IMapper _mapper;
        private readonly ILaptopDAL _laptopDAL;

        public LaptopService(IMapper mapper, ILaptopDAL laptopDAL)
        {
            _mapper = mapper;
            _laptopDAL = laptopDAL;
        }
        public async Task< DC.LaptopResponse>  GetListOfLaptopAsync()
        {
            DC.LaptopResponse laptopResponse1 = new DC.LaptopResponse();
            try
            {
            Model.LaptopResponse laptopResponse = await _laptopDAL.GetListOfLaptopAsync();
            laptopResponse1 = _mapper.Map<DC.LaptopResponse>(laptopResponse);
            }
            catch (Exception)
            {
            }
            return laptopResponse1;
        }

        public async Task<ConfigurationResponse> GetListOfConfigurationAsync()
        {
            DC.ConfigurationResponse configurationResponse1 = new DC.ConfigurationResponse();
            try
            {
                Model.ConfigurationResponse configurationResponse = await _laptopDAL.GetListOfConfigurationAsync();
                configurationResponse1 = _mapper.Map<DC.ConfigurationResponse>(configurationResponse);
            }
            catch (Exception)
            {
            }
            return configurationResponse1;
        }

        public async Task<DC.LaptopResponse> AddLaptopAsync(Laptop laptop)
        {
            DC.LaptopResponse laptopResponse1 = new DC.LaptopResponse();
            try
            {
                Model.LaptopResponse laptopResponse = await _laptopDAL.AddLaptopAsync(_mapper.Map<Model.Laptop>(laptop));
                laptopResponse1 = _mapper.Map<DC.LaptopResponse>(laptopResponse);
            }
            catch (Exception)
            {
            }
            return laptopResponse1;
        }

        public async Task<ShoppingCartResponse> AddLaptopToCartAsync(ShoppingCart shoppingCart)
        {
            DC.ShoppingCartResponse _shoppingCartResponse = new DC.ShoppingCartResponse();
            try
            {
                Model.ShoppingCartResponse shoppingCartResponse = await _laptopDAL.AddLaptopToCartAsync(_mapper.Map<Model.ShoppingCart>(shoppingCart));
                _shoppingCartResponse = _mapper.Map<DC.ShoppingCartResponse>(shoppingCartResponse);
            }
            catch (Exception)
            {
            }
            return _shoppingCartResponse;
        }

        public async Task<bool> CreateDbAsync()
        {
            return await _laptopDAL.CreateDbAsync(); 
        }

        public async Task<Laptop> GetListOfLaptopByIdAsync(int id)
        {
            Model.Laptop laptop = await _laptopDAL.GetListOfLaptopByIdAsync(id);
            return _mapper.Map<DC.Laptop>(laptop);
        }

        public async Task<ShoppingCartResponse> GetCartItemsAsync()
        {
            Model.ShoppingCartResponse shoppingCart = await _laptopDAL.GetCartItemsAsync();
            return _mapper.Map<DC.ShoppingCartResponse>(shoppingCart);
        }

        public async Task<bool> AddRamAsync(Ram ram)
        {
            return await _laptopDAL.AddRamAsync(_mapper.Map < Model.Ram > (ram));
        }

        public async Task<bool> AddHddAsync(Hdd hdd)
        {
            return await _laptopDAL.AddHddAsync(_mapper.Map<Model.Hdd>(hdd));
        }

        public async Task<bool> AddColorAsync(Color color)
        {
            return await _laptopDAL.AddColorAsync(_mapper.Map<Model.Color>(color));
        }

        public async Task<bool> DeleteConfiguration(DeleteConfigurationRequest deleyeyConfigurationRequest)
        {
            return await _laptopDAL.DeleteConfiguration(_mapper.Map<Model.DeleteConfigurationRequest>(deleyeyConfigurationRequest));
        }
    }
}
