using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KenoAssist.Web.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KenoAssist.Web.Controllers
{
    public class FoodAndDrinkController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Food()
        {
            var food = new List<Keno.Models.FoodViewModel>() 
            {
                new Keno.Models.FoodViewModel(){Id = 1, Name = "Toast and Jam"},
                new Keno.Models.FoodViewModel(){Id = 2, Name = "An Orange"},
                new Keno.Models.FoodViewModel(){Id = 3, Name = "Chicken Sandwich"},
                new Keno.Models.FoodViewModel(){Id = 4, Name = "Strawberry Yogurt"},
                new Keno.Models.FoodViewModel(){Id = 5, Name = "Battered Fish and Chips"},
                new Keno.Models.FoodViewModel(){Id = 6, Name = "Cake and Custard"},
            };



            var foodIntake = new FoodIntakeModel()
            {
                ClientId =1 ,
                Date = DateTime.Now,
                Breakfast = new List<Keno.Models.FoodViewModel>()
                {
                    new Keno.Models.FoodViewModel(){Id = 1, Name = "Toast and Jam"},
                    new Keno.Models.FoodViewModel(){Id = 2, Name = "An Orange"}
                },
                Lunch = new List<Keno.Models.FoodViewModel>()
                {
                    new Keno.Models.FoodViewModel(){Id = 3, Name = "Chicken Sandwich"},
                    new Keno.Models.FoodViewModel(){Id = 4, Name = "Strawberry Yogurt"}
                },
                Dinner = new List<Keno.Models.FoodViewModel>()
                {
                    new Keno.Models.FoodViewModel(){Id = 5, Name = "Battered Fish and Chips"},
                    new Keno.Models.FoodViewModel(){Id = 6, Name = "Cake and Custard"}
                },
                Snacks = new List<Keno.Models.FoodViewModel>()
                {
                }

            };


            return View(foodIntake);
        }

        public IActionResult Drink()
        {
            var drinkIntake = new DrinkIntakeModel()
            {
                ClientId = 1,
                Date = DateTime.Now,
                Drinks = new List<DrinkModel>()
                {
                    new DrinkModel(){Id = 1, Name = "Orange Juice", Volume=250},
                    new DrinkModel(){Id = 2, Name = "Tea", Volume=250},
                    new DrinkModel(){Id = 3, Name = "Diluted Juice", Volume=500},
                    new DrinkModel(){Id = 4, Name = "Diluted Juice", Volume=250},
                },
                TotalVolume = 1250

            };
            return View(drinkIntake);
        }

        public IActionResult AddFood()
        {
            return View();
        }


        public IActionResult Menu()
        {
            return View();
        }
    }
}
