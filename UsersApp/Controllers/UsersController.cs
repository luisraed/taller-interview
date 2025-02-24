using Microsoft.AspNetCore.Mvc;
using UsersApp.Data.Repositories;
using UsersApp.Models;

namespace UsersApp.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersRepository _usersRepository;
        public UsersController(IUsersRepository usersRepository) 
        {
            _usersRepository = usersRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UserDetails(string userName)
        {
            var user = _usersRepository.GetByName(userName);

            if (user == null)
            {
                return View("UserNotFound");
            }

            // This conversion can be done by using a library AutoMapper or implementing a custom translator between Data Entities and View Models
            var returnUserModel = new UserViewModel
            {
                UserName = userName,
                Id = user.Id,
                IsAdmin = user.IsAdmin
            };

            return View(returnUserModel);
        }
    }
}
