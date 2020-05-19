using System;
using System.Collections.Generic;                                                       
using System.Linq;
using System.Threading.Tasks;
using Manager.AddressManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Model;

namespace BookStoreBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressManager addressManager;

        public AddressController(IAddressManager AddressManager)
        {
            this.addressManager = AddressManager;
        }

        [Route("GetCustomerAddress")]
        [HttpGet]
        public AddressModel GetCustomerAddress(string email)
        {
            return this.addressManager.GetCustomerAddress(email);
        }

    

    [Route("AddDetailAddress")]
        [HttpPost]
        public async Task<IActionResult> AddDetailAddreess(AddressModel addressModel)
        {
            var result = await this.addressManager.AddDetailAddress(addressModel);
            if (result == 1)
            {
                return this.Ok(addressModel);
            }
            else
            {
                return this.BadRequest();
            }

        }
           
    }
}