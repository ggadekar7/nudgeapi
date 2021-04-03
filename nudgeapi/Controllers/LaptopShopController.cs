using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DC=NudgeApi.DataContracts;
using Swashbuckle.AspNetCore.Annotations;
using NudgeApi.Contracts.Interfaces;
using Microsoft.Data.Sqlite;
using Microsoft.AspNetCore.Cors;

namespace nudgeapi.Controllers
{
    [EnableCors("_myAllowSpecificOrigins")]
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class LaptopShopController : ControllerBase
    {
        private readonly ILaptopProvider _laptopProvider;
        public LaptopShopController(ILaptopProvider laptopProvider)
        {
            _laptopProvider =  laptopProvider;
        }

        [HttpGet("laptops")]
        [ProducesResponseType(typeof( DC.LaptopResponse ), StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "GetListOfLaptopAsync", Description = "GetListOfLaptopAsync")]
        public async Task<IActionResult> GetListOfLaptopAsync()
        {

            DC.LaptopResponse   result = await _laptopProvider.GetListOfLaptopAsync();
            if (result == null)
                return this.NotFound(result);
            return this.Ok(await Task.FromResult(result));
        }

        [HttpGet("configurations")]
        [ProducesResponseType(typeof(List<DC.Configuration>), StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "GetListOfConfigurationAsync", Description = "GetListOfConfigurationAsync")]
        public async Task<IActionResult> GetListOfConfigurationAsync()
        {

            DC.ConfigurationResponse result = await _laptopProvider.GetListOfConfigurationAsync();
            if (result == null)
                return this.NotFound(result);
            return this.Ok(await Task.FromResult(result));
        }

        [Route("laptop/add")]
        [HttpPost]
        [SwaggerOperation(Summary = "AddLaptopAsync", Description = "AddLaptopAsync")]
        public async Task<IActionResult> AddLaptopAsync([FromBody] DC.Laptop laptop)
        {
            DC.LaptopResponse result = null;
            result = await _laptopProvider.AddLaptopAsync(laptop);
            if (result == null)
                return this.StatusCode(StatusCodes.Status400BadRequest, "Unable to create site.");
            return Ok(result);
        }

        [Route("laptop/addcart")]
        [HttpPost]
        [SwaggerOperation(Summary = "AddLaptopToCartAsync", Description = "AddLaptopToCartAsync")]
        public async Task<IActionResult> AddLaptopToCartAsync([FromBody] DC.ShoppingCart shoppingCart)
        {
            DC.ShoppingCartResponse result = null;
            result = await _laptopProvider.AddLaptopToCartAsync(shoppingCart);
            if (result == null)
                return this.StatusCode(StatusCodes.Status400BadRequest, "Unable to add.");
            return Ok(result);
        }

        [Route("createdatabase")]
        [HttpPost]
        [SwaggerOperation(Summary = "CreateDbAsync", Description = "CreateDbAsync")]
        public async Task<IActionResult> CreateDbAsync()
        {
            await _laptopProvider.CreateDbAsync();
            return Ok();
        }

        [HttpGet("laptops/{id}")]
        [ProducesResponseType(typeof(DC.Laptop), StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "GetListOfLaptopAsync", Description = "GetListOfLaptopAsync")]
        public async Task<IActionResult> GetListOfLaptopAsync([FromRoute(Name = "id")] int id)
        {

            DC.Laptop  result = await _laptopProvider.GetListOfLaptopByIdAsync(id);
            if (result == null)
                return this.NotFound(result);
            return this.Ok(await Task.FromResult(result));
        }

        [HttpGet("shoppingcart")]
        [ProducesResponseType(typeof(DC.ShoppingCartResponse), StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "GetCartItemsAsync", Description = "GetCartItemsAsync")]
        public async Task<IActionResult> GetCartItemsAsync()
        {
            DC.ShoppingCartResponse result = await _laptopProvider.GetCartItemsAsync();
            if (result == null)
                return this.NotFound(result);
            return this.Ok(await Task.FromResult(result));
        }


        [Route("ram/add")]
        [HttpPost]
        [SwaggerOperation(Summary = "AddRamAsync", Description = "AddRamAsync")]
        public async Task<IActionResult> AddRamAsync([FromBody] DC.Ram ram)
        {
            bool result;
            result = await _laptopProvider.AddRamAsync(ram);
            if (result == false)
                return this.StatusCode(StatusCodes.Status400BadRequest, "Unable to create site.");
            return Ok(result);
        }

        [Route("hdd/add")]
        [HttpPost]
        [SwaggerOperation(Summary = "AddHddAsync", Description = "AddHddAsync")]
        public async Task<IActionResult> AddHddAsync([FromBody] DC.Hdd hdd)
        {
            bool result = false;
            result = await _laptopProvider.AddHddAsync(hdd);
            if (result == false)
                return this.StatusCode(StatusCodes.Status400BadRequest, "Unable to create site.");
            return Ok(result);
        }

        [Route("color/add")]
        [HttpPost]
        [SwaggerOperation(Summary = "AddColorAsync", Description = "AddColorAsync")]
        public async Task<IActionResult> AddColorAsync([FromBody] DC.Color color)
        {
            bool result = false;
            result = await _laptopProvider.AddColorAsync(color);
            if (result == false)
                return this.StatusCode(StatusCodes.Status400BadRequest, "Unable to create site.");
            return Ok(result);
        }


        [HttpDelete("deleteconfiguration/{CType}/{id}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "DeleteConfiguration", Description = "DeleteConfiguration")]
        public async Task<IActionResult> DeleteConfiguration([FromRoute(Name = "CType")] string CType, [FromRoute(Name = "id")] int id)
        {
            DC.DeleteConfigurationRequest deleteConfiguration = new DC.DeleteConfigurationRequest();
            deleteConfiguration.CType = CType;
            deleteConfiguration.Id = id;
            bool result = await _laptopProvider.DeleteConfiguration(deleteConfiguration);
            if (result == false)
                return this.NotFound(result);
            return this.Ok(await Task.FromResult(result));
        }
    }
}
