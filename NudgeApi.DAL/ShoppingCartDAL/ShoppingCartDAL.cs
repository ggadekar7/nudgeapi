using Microsoft.Data.Sqlite;
using NudgeApi.Contracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NudgeApi.DAL.ShoppingCartDAL
{
    public class ShoppingCartDAL : IShoppingCartDAL
    {
        public async Task<bool> DeleteCartItemAsync(int id)
        {
            bool result = false;
            try
            {
                using (var firstConnection = new SqliteConnection(DbConnection.connectionString))
                {
                    firstConnection.Open();
                    var deleteCommand = firstConnection.CreateCommand();
                    deleteCommand.CommandText = @"delete FROM ShoppingCart where id = "+ id +"";
                    int res = deleteCommand.ExecuteNonQuery();
                    if(res > 0)
                    {
                        result = true;
                    }
                }
            }
            catch (Exception)
            {
            }
            return await Task.FromResult(result);  
        }
    }
}
