using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using chefs_dishes.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace chefs_dishes.Controllers
{
    public class HomeController : Controller
    {
        private YourContext dbContext;
        // here we can "inject" our context service into the constructor
        public HomeController(YourContext context)
    {
        dbContext = context;
    }
        public IActionResult Index()
        {
            List<Chef> AllChefs = dbContext.Chef.Include(dish => dish.Dishes).ToList();
            ViewBag.allchefs = AllChefs;
            return View();
        }

        [HttpGet("dishes")]
        public IActionResult showDishes()
        {
            List<Dish> AllDishes = dbContext.Dish.Include(chef => chef.Creator).ToList();
            ViewBag.alldishes = AllDishes;
            return View("Dishes");
        }

        [HttpGet("dishes/new")]
        public IActionResult show_Dish_form()
        {
            List<Chef> AllChefs = dbContext.Chef.ToList();
            ViewBag.allchefs = AllChefs;
            return View("AddDish");
        }

        [HttpPost("newdish")]
        public IActionResult createDish(Dish dish)
        {
            if(ModelState.IsValid)
            {   
                dbContext.Add(dish);
                dbContext.SaveChanges();
                return RedirectToAction("showDishes");
            }
            else
            {
                List<Chef> AllChefs = dbContext.Chef.ToList();
                ViewBag.allchefs = AllChefs;
                return View("AddDish", dish);
            }
        }

        [HttpGet("new")]
        public IActionResult show_Chef_Form()
        {
            return View("AddChef");
        }

        [HttpPost("newchef")]
        public IActionResult createChef(Chef chef)
        {
            if(ModelState.IsValid)
            {
                if(chef.Date_of_Birth >= DateTime.Today)
                {
                    ModelState.AddModelError("Date_of_Birth", "Date of Birth must be from the past.");
                    return View("AddChef");
                }
                Chef newChef = new Chef
                {
                    FirstName = chef.FirstName,
                    LastName = chef.LastName,
                    Date_of_Birth = chef.Date_of_Birth,
                };
                dbContext.Add(newChef);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("AddChef");
            }
        }
    }
}
