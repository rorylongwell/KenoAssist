using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KenoAssist.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Keno.Common;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KenoAssist.Web.Controllers
{
    public class FoodAndDrinkController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Food()
        {
            var food = new List<FoodModel>()
            {
                new FoodModel(){Id = 1, Name = "Toast and Jam", FoodTypeId = (long)Constants.EFoodType.Breakfast},
                new FoodModel(){Id = 2, Name = "An Orange", FoodTypeId = (long)Constants.EFoodType.Snack},
                new FoodModel(){Id = 3, Name = "Chicken Sandwich", FoodTypeId = (long)Constants.EFoodType.Lunch},
                new FoodModel(){Id = 4, Name = "Strawberry Yogurt" , FoodTypeId = (long)Constants.EFoodType.Snack},
                new FoodModel(){Id = 5, Name = "Battered Fish and Chips", FoodTypeId = (long)Constants.EFoodType.Dinner},
                new FoodModel(){Id = 6, Name = "Cake and Custard", FoodTypeId = (long)Constants.EFoodType.Dinner},
            };



            var foodIntake = new FoodIntakeModel()
            {
                ClientId =1 ,
                Date = DateTime.Now,
                Breakfast = new List<FoodModel>()
                {
                    new FoodModel(){Id = 1, Name = "Toast and Jam"},
                    new FoodModel(){Id = 2, Name = "An Orange"}
                },
                Lunch = new List<FoodModel>()
                {
                    new FoodModel(){Id = 3, Name = "Chicken Sandwich"},
                    new FoodModel(){Id = 4, Name = "Strawberry Yogurt"}
                },
                Dinner = new List<FoodModel>()
                {
                    new FoodModel(){Id = 5, Name = "Battered Fish and Chips"},
                    new FoodModel(){Id = 6, Name = "Cake and Custard"}
                },
                Snacks = new List<FoodModel>()
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

        public IActionResult AddFoodMenu()
        {
            return View();
        }

        public IActionResult Menu(int addDays = 0)
        {

            DateTime day = DateTime.Now.AddDays(addDays); 


            IEnumerable<FoodIntakeModel> menu = new List<FoodIntakeModel>()
            {

                new FoodIntakeModel()
                {
                    ClientId = 1,
                    Date = DateTime.Now,
                    Breakfast = new List<FoodModel>()
                    {
                        new FoodModel(){Id = 1, Name = "Toast and Jam"},
                        new FoodModel(){Id = 2, Name = "An Orange"}
                    },
                    Lunch = new List<FoodModel>()
                    {
                        new FoodModel(){Id = 3, Name = "Chicken Sandwich"},
                        new FoodModel(){Id = 4, Name = "Strawberry Yogurt"}
                    },
                    Dinner = new List<FoodModel>()
                    {
                        new FoodModel(){Id = 5, Name = "Battered Fish and Chips"},
                        new FoodModel(){Id = 6, Name = "Cake and Custard"}
                    }
                },
                new FoodIntakeModel()
                {
                    ClientId = 1,
                    Date = DateTime.Now.AddDays(1),
                    Breakfast = new List<FoodModel>()
                    {
                        new FoodModel(){Id = 1, Name = "Toast and Jam"},
                        new FoodModel(){Id = 2, Name = "An Orange"}
                    },
                    Lunch = new List<FoodModel>()
                    {
                        new FoodModel(){Id = 3, Name = "Chicken Sandwich"},
                        new FoodModel(){Id = 4, Name = "Strawberry Yogurt"}
                    },
                    Dinner = new List<FoodModel>()
                    {
                        new FoodModel(){Id = 5, Name = "Battered Fish and Chips"},
                        new FoodModel(){Id = 6, Name = "Cake and Custard"}
                    }
                },

                new FoodIntakeModel()
                {
                    ClientId = 1,
                    Date = DateTime.Now.AddDays(2),
                    Breakfast = new List<FoodModel>()
                    {
                        new FoodModel(){Id = 1, Name = "Toast and Jam"},
                        new FoodModel(){Id = 2, Name = "An Orange"}
                    },
                    Lunch = new List<FoodModel>()
                    {
                        new FoodModel(){Id = 3, Name = "Chicken Sandwich"},
                        new FoodModel(){Id = 4, Name = "Strawberry Yogurt"}
                    },
                    Dinner = new List<FoodModel>()
                    {
                        new FoodModel(){Id = 5, Name = "Battered Fish and Chips"},
                        new FoodModel(){Id = 6, Name = "Cake and Custard"}
                    }
                }
               
            };

            var currentMenu = menu.Where(f => f.Date.Day.Equals(day.Day)).FirstOrDefault();

            if(currentMenu == null)
            {
                currentMenu = new FoodIntakeModel();
            }


            bool IsSubmitted = currentMenu.Date.Date < DateTime.Now.Date.AddDays(2); 


            ViewBag.IsSubmitted = IsSubmitted;
            ViewBag.DayCount = addDays;
            ViewBag.CurrentDay = GetDayName(day);

            return View(currentMenu);
        }

        public string GetDayName(DateTime date)
        {
            string result = string.Empty;

            //if(date.DayOfWeek ==){

            //}

            if(date.Date == DateTime.Today){
                return "Today";
            }
            if(date.Date == DateTime.Today.AddDays(1)){
                return "Tomorrow";
            }

            result = date.ToString("d");

            return result;

        }

    }
}
