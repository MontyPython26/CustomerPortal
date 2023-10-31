using BusinessObjectLayer.NewFolder;
using Microsoft.AspNetCore.Mvc;
using BusinessLogicLayer.LogicServices;
using BusinessObjectLayer.CommonEntities;

namespace CustomerPortal.Controllers
{

    
    public class CustomerController : Controller
    {

        private readonly ICustomerLogic _customerLogic;

        public CustomerController(ICustomerLogic customerLogic)
        {
            this._customerLogic = customerLogic;
        }

        [HttpGet]
        public IActionResult CustomerList()
        {

            CustomerModule customerModule = new CustomerModule();



            customerModule.customerdetail = _customerLogic.GetCustomerListLogic().ToList();

            //** Get Customer List
            return View(customerModule);
        }

        public IActionResult CreateCustomer()
        {

            return View();
        }


        [HttpPost]
        public IActionResult CreateCustomerPost(CustomerList Formdata)
        {
            string result = _customerLogic.InsertRecordLogic(Formdata); 

            if (result=="Saved Successfully")
            {
                return RedirectToAction("CustomerList","Customer");
            }

            else
            {
                TempData["ErrorTemp"] = result;
                return View();
            }

        }
        public IActionResult EditCustomer()
        {

            return View();
        }



    }
}
