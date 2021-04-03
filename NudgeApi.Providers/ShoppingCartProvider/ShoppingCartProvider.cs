using NudgeApi.Contracts.Interfaces;
using NudgeApi.DataContracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NudgeApi.Providers.ShoppingCartProvider
{
    public class ShoppingCartProvider : IShoppingCartProvider
    {
        private IShoppingCartService _shoppingCartService;
        public ShoppingCartProvider(IShoppingCartService  shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }

        public Task<bool> DeleteCartItemAsync(int id)
        {
            return _shoppingCartService.DeleteCartItemAsync(id);
        }
    }
}
