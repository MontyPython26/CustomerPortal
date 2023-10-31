using BusinessLogicLayer.LogicServices;
using BusinessObjectLayer.CustomerList_DbEntities;
using Microsoft.AspNetCore.Mvc;
using System.Data.Common;

namespace CustomerPortal.Controllers
{
    public class LoginController : Controller
    {
        private IUserLogic _userLogic;
        public LoginController(IUserLogic userLogic) 
        {
            _userLogic = userLogic;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

            [HttpPost]
            public IActionResult Signin(string username, string passwordhash)
            {
                // Validate the username and password
                if (IsValidUser(username, passwordhash))
                {
                    // Redirect to the user's dashboard or another protected area
                    return RedirectToAction("Customerlist", new { controller = "Customer" });
                }
                else
                {
                    // Invalid credentials, show an error message
                    ViewBag.ErrorMessage = "Invalid username or password.";
                    return RedirectToAction("");
            }
            }

            private bool IsValidUser(string username, string password)
        {

            try
            {
                UserModel u = new UserModel
                {
                    Username = username,
                    PasswordHash = password
                };
                if (_userLogic.VerifyUser(u))
                {
                    return true;
                }
            }
            catch (Exception ex)
            {

                return false;
            }

                return false;
            }
        }


    }

