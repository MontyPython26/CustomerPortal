using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static Dapper.SqlMapper;
using static System.Net.Mime.MediaTypeNames;
using static System.Reflection.Metadata.BlobBuilder;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Net;
using System.Reflection.Emit;
using System.Reflection;
using System.Runtime.Intrinsics.X86;
using BusinessObjectLayer.NewFolder;
using BusinessLogicLayer.LogicServices;
using BusinessObjectLayer.CommonEntities;

namespace CustomerPortal.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerLogic _customerLogic;
        public CustomerController(ICustomerLogic customerLogic)
        {
            this._customerLogic = customerLogic;
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, CustomerList customer)
        {
            if (id != customer.CustomerId)
            {
                return BadRequest();
            }


          //  Res = _customerLogic.UpdateCustomer();

            return NoContent();

        }

        [HttpGet("{id}")]
        public CustomerList Get(int id)
        {
            var data = _customerLogic.GetCustomerListLogic().ToList();
            if (!data.Any(x=>x.CustomerId==id))
            {
                return new CustomerList();
            }


            return _customerLogic.GetCustomerListLogic().ToList().Where(x=>x.CustomerId==id).First();
            //  Res = _customerLogic.UpdateCustomer();

        }
    }
}