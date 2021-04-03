using NudgeApi.Contracts.Interfaces;
using NudgeApi.Providers.LaptopProvider;
using NudgeApi.Providers.ObjectProvider;
using NudgeApi.Providers.ShoppingCartProvider;
using NudgeApi.Services.LaptopService;
using NudgeApi.Services.ShoppingService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nudgeapi.DI
{
    public class Module : IModule
    {
        public IEnumerable<Registration> GetRegistrations()
        {
            yield return Registration.AsPerCall<IObjectProvider, ObjectProvider>();
            yield return Registration.AsPerCall<ILaptopProvider, LaptopProvider>();
            yield return Registration.AsPerCall<ILaptopService, LaptopService>();
            yield return Registration.AsPerCall<IShoppingCartProvider, ShoppingCartProvider>();
            yield return Registration.AsPerCall<IShoppingCartService, ShoppingCartService>();
        }
    }
}
