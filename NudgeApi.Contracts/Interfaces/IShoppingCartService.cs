using NudgeApi.DataContracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NudgeApi.Contracts.Interfaces
{
    public interface IShoppingCartService
    {
        Task<bool> DeleteCartItemAsync(int id);
    }
}
