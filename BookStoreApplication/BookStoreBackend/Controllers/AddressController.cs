using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookStoreRepositoryLayer.Common;
using Manager.AddressManager;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model.Model;

namespace BookStoreBackend.Controllers
{

    /// <summary>
    /// Address controller class
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
   
     [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressManager addressManager;
        private readonly ILogger<AddressController> logger;
        public AddressController(IAddressManager AddressManager, ILogger<AddressController> logger)
        {
            this.addressManager = AddressManager;
           this.logger = logger;
        }

        [HttpGet]
        public IEnumerable<AddressModel> GetAllAddress()
        {
            logger.LogTrace("Trace Log");
            logger.LogDebug("Debug Log");
            logger.LogInformation("Information Log");
            logger.LogWarning("Warning Log");
            logger.LogError("Error Log");
            logger.LogCritical("Critical Log");
            return addressManager.GetAllAddress();
        }

        [HttpPost]
        public void AddAddress(AddressModel addressModel)
        {
            addressManager.AddAddress(addressModel);
        }
    }
}