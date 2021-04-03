using NudgeApi.Contracts.Interfaces;
using DC = NudgeApi.DataContracts;
using System;
using Xunit;
using System.Collections.Generic;
using NudgeApi.Providers.LaptopProvider;
using NudgeApi.Services.LaptopService;
using NudgeApi.DAL.Laptop;
using AutoMapper;
using NMock;
using Microsoft.Extensions.Configuration;
using NudgeApi.DataContracts;

namespace NudgeApi.Tests
{
    public class UnitTest1
    {
        private AutoMapper.IConfigurationProvider provider;
        private static IMapper _mapper;
        public UnitTest1()
        {
        }
        public  ILaptopService GetServiceObject()
        {
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new SourceMappingProfile());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }
            // _laptopProvider = new LaptopProvider(new LaptopService(new Mapper(provider), new LaptopDAL()));

            ILaptopService laptopService = new LaptopService(_mapper, new LaptopDAL());
            laptopService.CreateDbAsync();
            return laptopService;
        }
        [Fact]
        public async void GetListOfLaptopAsyncTest()
        {
            ILaptopService laptopService = GetServiceObject();
            DC.LaptopResponse  list= await laptopService.GetListOfLaptopAsync();
            Assert.NotEmpty(list.Laptops);
        }

        [Fact]
        public async void AddLaptopAsyncTest()
        {
            ILaptopService laptopService = GetServiceObject();
            Laptop laptop = new Laptop();
            laptop.Name = "Lenova";
            laptop.Price = "500";
            DC.LaptopResponse laptopResponse = await laptopService.AddLaptopAsync(laptop);
            Laptop laptopActual = laptopResponse.Laptops[laptopResponse.Laptops.Count - 1];
            Assert.Equal(laptop.Name,laptopActual.Name);
            Assert.Equal(laptop.Price, laptopActual.Price);
        }

        [Fact]
        public async void AddRamAsyncTest()
        {
            ILaptopService laptopService = GetServiceObject();
            Ram ram = new Ram();
            ram.Type = "20GB";
            ram.Price = "500";
            bool flag = await laptopService.AddRamAsync(ram);
            Assert.True(flag);
        }

        [Fact]
        public async void AddRamAsyncTest_Fail()
        {
            ILaptopService laptopService = GetServiceObject();
            Ram ram = new Ram();
            ram.Type = "8GB";
            ram.Price = "500";
            bool flag = await laptopService.AddRamAsync(ram);
            Assert.False(flag);
        }

        [Fact]
        public async void AddHddAsyncTest()
        {
            ILaptopService laptopService = GetServiceObject();
            Hdd hdd = new Hdd();
            hdd.Type = "5 TB";
            hdd.Price = "500";
            bool flag = await laptopService.AddHddAsync(hdd);
            Assert.True(flag);
        }

        [Fact]
        public async void AddColorAsyncTest()
        {
            ILaptopService laptopService = GetServiceObject();
            Color color = new Color();
            color.Type = "4 TB";
            color.Price = "500";
            bool flag = await laptopService.AddColorAsync(color);
            Assert.True(flag);
        }
    }
}
