using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Exam.Models;
using Exam.ViewModels;

namespace Exam.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserContextDB _db;
        public HomeController(UserContextDB context)
        {
            _db = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View("Index");
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            return View(_db.Users.ToList());
        }

        [HttpGet]
        public IActionResult AddUser()
        {
            return View("AddUser");
        }

        private bool IsUnique(AddUserViewModel model)
        {
            if (_db.Users.Where(user => user.Name == model.Name).ToList().Count <= 0) return true;
            if (_db.Users.Where(user => user.Surname == model.Surname).ToList().Count <= 0) return true;
            return _db.Users.Where(user => user.Patronymic == model.Patronymic).ToList().Count <= 0;
        }

        [HttpPost]
        public IActionResult AddUser(AddUserViewModel model)
        {
            if (!IsUnique(model))
            {
                return Content("Error! Entered user already exist!");
            }
            if (!ModelState.IsValid) return Content("Error! Invalid entered data!");
            User user = new User { Name = model.Name, Surname = model.Surname, Patronymic = model.Patronymic, Autobiography = model.Autobiography };
            
            _db.Users.Add(user);
            _db.SaveChanges();

            return Content("Success!");
        }

        [HttpGet]
        public IActionResult EditUser(int id)
        {
            User user = _db.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            
            EditUserViewModel model = new EditUserViewModel { Id = user.Id, Name = user.Name, Surname = user.Surname, Patronymic = user.Patronymic, Autobiography = user.Autobiography };
            return View(model);
        }

        [HttpPost]
        public IActionResult EditUser(EditUserViewModel model)
        {
            User user = _db.Users.Find(model.Id);
            if (!ModelState.IsValid) return RedirectToAction("GetUsers");
            if (user == null) return Content("Error! Entered user doesn't exist!");
            if (model.Name.Equals(user.Name) && model.Surname.Equals(user.Surname) &&
                model.Patronymic.Equals(user.Patronymic))
            {
                return Content("Error! Entered user already exist!");
            }

            if (model.Name != null) user.Name = model.Name;
            if (model.Surname != null) user.Surname = model.Surname;
            if (model.Patronymic != null) user.Patronymic = model.Patronymic;
            if (model.Autobiography != null) user.Autobiography = user.Autobiography;
            _db.SaveChanges();

            return RedirectToAction("GetUsers");
        }

        [HttpGet]
        public IActionResult DeleteUser(User model)
        {
            return View("DeleteUser", model);
        }

        [HttpPost]
        public IActionResult DeleteUser(int id)
        {
            User user = _db.Users.Find(id);
            _db.Users.Remove(user);
            _db.SaveChanges();

            return Content("Success!");
        }
    }
}
