using AutoMapper;
using NudgeApi.Contracts.Interfaces;
using NudgeApi.DataContracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NudgeApi.Services.ShoppingService
{
    public class ShoppingCartService : IShoppingCartService
    {
        private IMapper _mapper;
        private readonly IShoppingCartDAL _shoppingCartDAL;

        public ShoppingCartService(IMapper mapper, IShoppingCartDAL  shoppingCartDAL)
        {
            _mapper = mapper;
            _shoppingCartDAL = shoppingCartDAL;
        }
        public Task<bool> DeleteCartItemAsync(int id)
        {
            return _shoppingCartDAL.DeleteCartItemAsync(id);
        }
    }
}
