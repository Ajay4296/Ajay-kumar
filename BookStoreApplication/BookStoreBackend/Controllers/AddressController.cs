﻿using System;
using System.Collections.Generic;                                                       
using System.Linq;
using System.Threading.Tasks;
using BookStoreRepositoryLayer.Common;
using Manager.AddressManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Model;

namespace BookStoreBackend.Controllers
{
    //public class HandelBadRequest
    //{
    //    public string ErrorMessage { get; set; }
    //}
    /// <summary>
    /// Address controller class
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        /// <summary>
        /// The address manager
        /// </summary>
        private readonly IAddressManager addressManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddressController"/> class.
        /// </summary>
        /// <param name="AddressManager">The address manager.</param>
        public AddressController(IAddressManager AddressManager)
        {
            this.addressManager = AddressManager;
        }

        /// <summary>
        /// Gets the customer address.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        //[Route("GetCustomerAddress")]
        [HttpGet]
        public AddressModel GetCustomerAddress(string email)
        {
            return this.addressManager.GetCustomerAddress(email);
        }


        /// <summary>
        /// Adds the detail addreess.
        /// </summary>
        /// <param name="addressModel">The address model.</param>
        /// <returns></returns>
        //[Route("AddDetailAddress")]
        [HttpPost]
        public async Task<IActionResult> AddDetailAddreess(AddressModel addressModel)
        {
            var result = await this.addressManager.AddDetailAddress(addressModel);
            if (result == 1)
            {
                return this.Ok(addressModel);
            }            
                return this.BadRequest(JsonErrorModel.Json());           

        }
       
    }
}