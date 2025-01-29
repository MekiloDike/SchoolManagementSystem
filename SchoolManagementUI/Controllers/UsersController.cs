using Microsoft.AspNetCore.Mvc;
using SchoolManagementUI.Service;
using SchoolManagementUI.ViewModel;


namespace SchoolManagementUI.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUser _user;
        private readonly ILogger<UsersController> _logger;
        public UsersController(IUser user, ILogger<UsersController> logger)
        {
            _user = user;
            _logger = logger;
        }


        [HttpGet]
        public IActionResult Login()
        {
            _logger.LogInformation("Show login page");
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginVM login)
        {
             _logger.LogInformation("About to login");
            var token = await _user.Signin(login);
            _logger.LogInformation($"Login token: {token}");
            if (!string.IsNullOrEmpty(token))
                return RedirectToAction("Index", "School");
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
        }
    }
}
