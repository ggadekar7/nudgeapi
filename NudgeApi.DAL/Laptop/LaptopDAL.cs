using MODEL=NudgeApi.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NudgeApi.Contracts.Interfaces;
using NudgeApi.Models;
using System.Linq;
using Microsoft.Data.Sqlite;

namespace NudgeApi.DAL.Laptop
{
    public class LaptopDAL : ILaptopDAL
    {
        public async Task<bool> AddColorAsync(Color color)
        {
            bool result = false;
            try
            {
                using (var firstConnection = new SqliteConnection(DbConnection.connectionString))
                {
                    firstConnection.Open();
                    var insertCommand = firstConnection.CreateCommand();
                    insertCommand.CommandText =  @"INSERT INTO Color(type, price) VALUES('" + color.Type  +"', '"+ color.Price +"')";
                    int res = insertCommand.ExecuteNonQuery();
                    if (res > 0)
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

        public async Task<bool> AddHddAsync(Hdd hdd)
        {
            bool result = false;
            try
            {
                using (var firstConnection = new SqliteConnection(DbConnection.connectionString))
                {
                    firstConnection.Open();
                    var insertCommand = firstConnection.CreateCommand();
                    insertCommand.CommandText = @"INSERT INTO Hdd(type, price) VALUES('" + hdd.Type + "', '" + hdd.Price + "')";
                    int res = insertCommand.ExecuteNonQuery();
                    if (res > 0)
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

        public async Task<MODEL.LaptopResponse> AddLaptopAsync(MODEL.Laptop laptop)
        {
            MODEL.LaptopResponse laptopResponse = new MODEL.LaptopResponse();
            try
            {
                List<MODEL.Laptop> list1 = new List<MODEL.Laptop>();
                using (var firstConnection = new SqliteConnection(DbConnection.connectionString))
                {
                    firstConnection.Open();

                    var updateCommand = firstConnection.CreateCommand();

                    string query1 = "select * from Laptop where Name='" + laptop.Name + "'";
                    updateCommand.CommandText = query1;

                    SqliteDataReader adr1 = updateCommand.ExecuteReader();
                    bool flag = adr1.HasRows;
                    if (flag)
                    {
                        return null;
                    }
                    adr1.Close();
                    string query = "INSERT INTO Laptop (Name,price) VALUES ('" + laptop.Name  +"','"+ laptop.Price +"')"; 
                    updateCommand.CommandText = query;

                    updateCommand.ExecuteNonQuery();

                    updateCommand.CommandText =
                   @"
                        SELECT *
                        FROM LAPTOP
                    ";
                    SqliteDataReader adr = updateCommand.ExecuteReader();
                   
                    while (adr.Read())
                    {
                        MODEL.Laptop laptopObj = new MODEL.Laptop();
                        laptopObj.Id = adr.GetInt32(0);
                        laptopObj.Name  = adr.GetString(1);
                        laptopObj.Price = adr.GetString(2);
                        list1.Add(laptopObj);
                    }
                }
                laptopResponse.Laptops = list1;
            }
            catch (Exception ex)
            {
            }
            return await Task.FromResult(laptopResponse); 
        }

        public async Task<ShoppingCartResponse> AddLaptopToCartAsync(MODEL.ShoppingCart shoppingCart)
        {
            MODEL.ShoppingCartResponse shoppingCartResponse = new MODEL.ShoppingCartResponse();
            try
            {
                List<MODEL.ShoppingCart> ShoppingCarts = new List<MODEL.ShoppingCart>();
                using (var firstConnection = new SqliteConnection(DbConnection.connectionString))
                {
                    firstConnection.Open();

                    var updateCommand = firstConnection.CreateCommand();
                    string query = "INSERT INTO ShoppingCart (Name,Ram,Hdd,Color,price) VALUES ('" + shoppingCart.Name + "','" + shoppingCart.Ram + "','" + shoppingCart.Hdd + "','" + shoppingCart.Color + "','" + shoppingCart.Price + "')";
                    updateCommand.CommandText = query;

                    updateCommand.ExecuteNonQuery();

                    updateCommand.CommandText =
                   @"
                        SELECT *
                        FROM ShoppingCart
                    ";
                    SqliteDataReader adr = updateCommand.ExecuteReader();

                    while (adr.Read())
                    {
                        MODEL.ShoppingCart shoppingCartObj = new MODEL.ShoppingCart();
                        shoppingCartObj.Id = adr.GetInt32(0);
                        shoppingCartObj.Name = adr.GetString(1);
                        shoppingCartObj.Ram = adr.GetString(2);
                        shoppingCartObj.Hdd = adr.GetString(3);
                        shoppingCartObj.Color = adr.GetString(4);
                        shoppingCartObj.Price = adr.GetString(5);
                        ShoppingCarts.Add(shoppingCartObj);
                    }
                }
                shoppingCartResponse.Laptops = ShoppingCarts;
            }
            catch (Exception)
            {
            }
            return await Task.FromResult(shoppingCartResponse);
        }

        public async Task<bool> AddRamAsync(Ram ram)
        {
            bool result = false;
            try
            {
                using (var firstConnection = new SqliteConnection(DbConnection.connectionString))
                {
                    firstConnection.Open();
                    var insertCommand = firstConnection.CreateCommand();

                    insertCommand.CommandText = @"select * from Ram where type ='" + ram.Type + "'";
                    SqliteDataReader adr = insertCommand.ExecuteReader();
                    if (adr.HasRows)
                    {
                        return false;
                    }
                    adr.Close();
                    insertCommand.CommandText = @"INSERT INTO Ram(type, price) VALUES('" + ram.Type + "', '" + ram.Price + "')";
                    int res = insertCommand.ExecuteNonQuery();
                    if (res > 0)
                    {
                        result = true;
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return await Task.FromResult(result);  
        }

        public async Task<bool> CreateDbAsync()
        {
            DbConnection.CreateTables();
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteConfiguration(DeleteConfigurationRequest deleyeyConfigurationRequest)
        {
            bool result = false;
            try
            {
                using (var firstConnection = new SqliteConnection(DbConnection.connectionString))
                {
                    firstConnection.Open();
                    var deleteCommand = firstConnection.CreateCommand();
                    string query = "";
                    if(deleyeyConfigurationRequest.CType.ToUpper() == "RAM")
                    {
                        query= @"delete FROM Ram where id = " + deleyeyConfigurationRequest.Id + "";
                    }else if (deleyeyConfigurationRequest.CType.ToUpper() == "HDD")
                    {
                        query = @"delete FROM Hdd where id = " + deleyeyConfigurationRequest.Id + "";
                    }
                    else if (deleyeyConfigurationRequest.CType.ToUpper() == "COLOR")
                    {
                        query = @"delete FROM Color where id = " + deleyeyConfigurationRequest.Id + "";
                    }
                    deleteCommand.CommandText = query;
                    int res = deleteCommand.ExecuteNonQuery();
                    if (res > 0)
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

        public async Task<ShoppingCartResponse> GetCartItemsAsync()
        {
            MODEL.ShoppingCartResponse shoppingCartResponse = new MODEL.ShoppingCartResponse();
            try
            {
                List<MODEL.ShoppingCart> ShoppingCarts = new List<MODEL.ShoppingCart>();
                using (var firstConnection = new SqliteConnection(DbConnection.connectionString))
                {
                    firstConnection.Open();
                    var updateCommand = firstConnection.CreateCommand();
                    updateCommand.CommandText =
                   @"
                        SELECT *
                        FROM ShoppingCart
                    ";
                    SqliteDataReader adr = updateCommand.ExecuteReader();

                    while (adr.Read())
                    {
                        MODEL.ShoppingCart shoppingCartObj = new MODEL.ShoppingCart();
                        shoppingCartObj.Id = adr.GetInt32(0);
                        shoppingCartObj.Name = adr.GetString(1);
                        shoppingCartObj.Ram = adr.GetString(2);
                        shoppingCartObj.Hdd = adr.GetString(3);
                        shoppingCartObj.Color = adr.GetString(4);
                        shoppingCartObj.Price = adr.GetString(5);
                        ShoppingCarts.Add(shoppingCartObj);
                    }
                }
                shoppingCartResponse.Laptops = ShoppingCarts;
            }
            catch (Exception)
            {
            }
            return await Task.FromResult(shoppingCartResponse);  
        }

        public async Task<MODEL.ConfigurationResponse> GetListOfConfigurationAsync()
        {
            MODEL.ConfigurationResponse configurationResponse = new MODEL.ConfigurationResponse();
            try
            {
                List<MODEL.Configuration> list = new List<MODEL.Configuration>();
                List<Ram> rams = new List<Ram>();
                List<Hdd> hdds = new List<Hdd>();
                List<Color> colors = new List<Color>();
                using (var firstConnection = new SqliteConnection(DbConnection.connectionString))
                {
                    firstConnection.Open();
                    var selectCommand = firstConnection.CreateCommand();
                    selectCommand.CommandText =
                   @"
                        SELECT *
                        FROM Ram
                    ";
                    SqliteDataReader adr = selectCommand.ExecuteReader();
                    while (adr.Read())
                    {
                        MODEL.Ram ram = new MODEL.Ram();
                        ram.Id = adr.GetInt32(0);
                        ram.Type = adr.GetString(1);
                        ram.Price = adr.GetString(2);
                        rams.Add(ram);
                    }
                    adr.Close();
                    selectCommand.CommandText =
                  @"
                        SELECT *
                        FROM Hdd
                    ";
                    adr = selectCommand.ExecuteReader();
                    while (adr.Read())
                    {
                        MODEL.Hdd hdd = new MODEL.Hdd();
                        hdd.Id = adr.GetInt32(0);
                        hdd.Type = adr.GetString(1);
                        hdd.Price = adr.GetString(2);
                        hdds.Add(hdd);
                    }
                    adr.Close();
                    selectCommand.CommandText =
                 @"
                        SELECT *
                        FROM Color
                    ";
                    adr = selectCommand.ExecuteReader();
                    while (adr.Read())
                    {
                        MODEL.Color color = new MODEL.Color();
                        color.Id = adr.GetInt32(0);
                        color.Type = adr.GetString(1);
                        color.Price = adr.GetString(2);
                        colors.Add(color);
                    }
                }
                configurationResponse.Rams = rams;
                configurationResponse.Hdds = hdds;
                configurationResponse.Colors = colors;
            }
            catch (Exception)
            {
            }
            return await Task.FromResult(configurationResponse); 
        }

        public async Task<MODEL.LaptopResponse> GetListOfLaptopAsync()
        {
            MODEL.LaptopResponse laptopResponse = new MODEL.LaptopResponse();
            try
            {
                List<MODEL.Laptop> list = new List<MODEL.Laptop>();
                using (var firstConnection = new SqliteConnection(DbConnection.connectionString))
                {
                    firstConnection.Open();

                    var selectCommand = firstConnection.CreateCommand();

                    selectCommand.CommandText =
                   @"
                        SELECT *
                        FROM LAPTOP
                    ";
                    SqliteDataReader adr = selectCommand.ExecuteReader();

                    while (adr.Read())
                    {
                        MODEL.Laptop laptopObj = new MODEL.Laptop();
                        laptopObj.Id = adr.GetInt32(0);
                        laptopObj.Name = adr.GetString(1);
                        laptopObj.Price = adr.GetString(2);
                        list.Add(laptopObj);
                    }
                }
                
                laptopResponse.Laptops = list;
            }
            catch (Exception)
            {
            }
            return await Task.FromResult(laptopResponse);  
        }

        public async Task<MODEL.Laptop> GetListOfLaptopByIdAsync(int id)
        {
            MODEL.Laptop laptop = new MODEL.Laptop();
            try
            {
                using (var firstConnection = new SqliteConnection(DbConnection.connectionString))
                {
                    firstConnection.Open();
                    var selectCommand = firstConnection.CreateCommand();
                    selectCommand.CommandText =
                   @"
                        SELECT *
                        FROM LAPTOP where id="+ id + "";
                    SqliteDataReader adr = selectCommand.ExecuteReader();

                    while (adr.Read())
                    {
                        laptop.Id = adr.GetInt32(0);
                        laptop.Name = adr.GetString(1);
                        laptop.Price = adr.GetString(2);
                    }
                }
            }
            catch (Exception)
            {
            }
            return await Task.FromResult(laptop);  
        }
    }
}
