using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NudgeApi.Contracts.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
using DC=NudgeApi.DataContracts;

namespace nudgeapi.Controllers
{
    [EnableCors("_myAllowSpecificOrigins")]
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IShoppingCartProvider _shoppingCartProvider;
        public ShoppingCartController(IShoppingCartProvider shoppingCartProvider)
        {
            _shoppingCartProvider =  shoppingCartProvider;
        }

        [HttpDelete("deletecartitem")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "GetListOfLaptopAsync", Description = "GetListOfLaptopAsync")]
        public async Task<IActionResult> DeleteCartItemAsync([FromQueryAttribute(Name = "id")] int id)
        {
            bool result = await _shoppingCartProvider.DeleteCartItemAsync(id);
            if (result == false)
                return this.NotFound(result);
            return this.Ok(await Task.FromResult(result));
        }
    }
}
