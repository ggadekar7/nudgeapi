using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NudgeApi.Models;
namespace NudgeApi.Contracts.Interfaces
{
    public interface IShoppingCartDAL
    {
        Task<bool> DeleteCartItemAsync(int id);
    }
}
