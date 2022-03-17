using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Rest_Api_Spring.models;
using Rest_Api_Spring.Models.Service;
using System.Collections.Generic;
using System.Diagnostics;

namespace Rest_Api_Spring.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        protected static string URL_User = "http://localhost:8080/user";
        private readonly IUserService userService;
        public HomeController(ILogger<HomeController> logger, IUserService userService)
        {
            this.userService = userService;
            _logger = logger;
        }
       
        public IActionResult Index()
        {
             List<User> userList = userService.GetAll(URL_User);

            return View(userList);
        }

        public IActionResult Detail(int id)
        {
            User userList = userService.GetById(URL_User , id);
            return View(userList);
        }

        [HttpPost]
        public IActionResult Edit(int userId, string nameFirst, string lastName, string startDate, string UserType, string codiceFiscale, int eta)
        {
            User u = new User() { 
                CodiceFiscale = codiceFiscale,
                UserId = userId,
                Eta = eta,
                FirstName = nameFirst,
                LastName = lastName,
                StartDate = startDate,
                UserType = UserType,
            };

            User userList = userService.EditUser(URL_User + "/updateuser", u);

            return Redirect($"Detail/{userId}"); ;
        }

        public IActionResult Delete(int id)
        {

            User userList = userService.DeleteUser(URL_User + $"/{id}");

            return Redirect("/Home/Index");
        }

        public IActionResult Add()
        {
            return View();
        }


        [HttpPost]
        public IActionResult AddUser(string nameFirst, string lastName, string startDate, string UserType, string codiceFiscale, int eta)
        {
            User u = new User()
            {
                CodiceFiscale = codiceFiscale,
                Eta = eta,
                FirstName = nameFirst,
                LastName = lastName,
                StartDate = startDate,
                UserType = UserType,
            };
            User userList = userService.AddUser(URL_User, u);

            return Redirect($"Detail/{userList.UserId}");
        }
    }
}
