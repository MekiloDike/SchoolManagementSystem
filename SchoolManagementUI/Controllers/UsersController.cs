using Microsoft.AspNetCore.Mvc;
using SchoolManagementUI.Service;
using SchoolManagementUI.ViewModel;


namespace SchoolManagementUI.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUser _user;
        public UsersController(IUser user)
        {
            _user = user;
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public  IActionResult Log(LoginVM login)
        {
            var signIn = _user.Signin(login);           
                       
            return RedirectToAction("Home");
            return View();
            
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterVM register)
        {
            var reg = _user.Register(register);
            return RedirectToAction("Login");
            return View();
        }
    }
}
