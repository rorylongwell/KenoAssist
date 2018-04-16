using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KenoAssist.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Keno.Common;
using KenoAssist.Web.Helper;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KenoAssist.Web.Controllers
{
    public class FoodAndDrinkController : Controller
    {
        private List<FoodCheckBoxModel> breakfastCheckbox;
        private List<FoodCheckBoxModel> lunchCheckbox;
        private List<FoodCheckBoxModel> dinnerCheckbox;

        private List<FoodCheckBoxModel> selectedBreakfast;
        private List<FoodCheckBoxModel> selectedLunch;
        private List<FoodCheckBoxModel> selectedDinner;

        IEnumerable<FoodIntakeModel> menu;

        public FoodAndDrinkController()
        {
            breakfastCheckbox = new List<FoodCheckBoxModel>()
            {
                new FoodCheckBoxModel(){Id = 1, Name = "Toast and jam", FoodTypeId = 1,IsChecked = false},
                new FoodCheckBoxModel(){Id = 2, Name = "Scrambled eggs and toast", FoodTypeId = 1,IsChecked = false},
                new FoodCheckBoxModel(){Id = 3, Name = "Porridge (lactose free milk)", FoodTypeId = 1,IsChecked = false},
                new FoodCheckBoxModel(){Id = 4, Name = "Rice Krispies (lactose free milk)", FoodTypeId = 1,IsChecked = false},
                new FoodCheckBoxModel(){Id = 5, Name = "Pancakes and jam", FoodTypeId = 1,IsChecked = false},
                new FoodCheckBoxModel(){Id = 6, Name = "Apple slices", FoodTypeId = 2,IsChecked = false},
                new FoodCheckBoxModel(){Id = 7, Name = "Lacotose free strawberry yogurt", FoodTypeId = 2,IsChecked = false},
                new FoodCheckBoxModel(){Id = 8, Name = "Large orange", FoodTypeId = 2,IsChecked = false}
            };

            lunchCheckbox = new List<FoodCheckBoxModel>()
            {
                new FoodCheckBoxModel(){Id = 9, Name = "Vegetable soup and a bap", FoodTypeId = 1,IsChecked = false},
                new FoodCheckBoxModel(){Id = 10, Name = "Sausage rolls", FoodTypeId = 1,IsChecked = false},
                new FoodCheckBoxModel(){Id = 11, Name = "Baked potato, chicken and lactose free cheese", FoodTypeId = 1,IsChecked = false},
                new FoodCheckBoxModel(){Id = 12, Name = "Chicken sandwich", FoodTypeId = 1,IsChecked = false},
                new FoodCheckBoxModel(){Id = 13, Name = "Tuna and onion sandwich", FoodTypeId = 1,IsChecked = false},
                new FoodCheckBoxModel(){Id = 14, Name = "Melon selection", FoodTypeId = 2,IsChecked = false},
                new FoodCheckBoxModel(){Id = 15, Name = "Lacotose free strawberry yogurt", FoodTypeId = 2,IsChecked = false},
                new FoodCheckBoxModel(){Id = 16, Name = "Sttrawberry jelly", FoodTypeId = 2,IsChecked = false}
            };

             dinnerCheckbox = new List<FoodCheckBoxModel>()
            {
                new FoodCheckBoxModel(){Id = 17, Name = "Chicken curry and rice", FoodTypeId = 1,IsChecked = false},
                new FoodCheckBoxModel(){Id = 18, Name = "Fish and chips", FoodTypeId = 1,IsChecked = false},
                new FoodCheckBoxModel(){Id = 19, Name = "Tuna salad", FoodTypeId = 1,IsChecked = false},
                new FoodCheckBoxModel(){Id = 20, Name = "Sausage and chips", FoodTypeId = 1,IsChecked = false},
                new FoodCheckBoxModel(){Id = 21, Name = "Beef stew", FoodTypeId = 1,IsChecked = false},
                new FoodCheckBoxModel(){Id = 22, Name = "Lacotose free ice-cream", FoodTypeId = 2,IsChecked = false},
                new FoodCheckBoxModel(){Id = 23, Name = "Lacotose free custard and cake", FoodTypeId = 2,IsChecked = false},
                new FoodCheckBoxModel(){Id = 24, Name = "Sttrawberry jelly", FoodTypeId = 2,IsChecked = false}
            };

            selectedBreakfast = new List<FoodCheckBoxModel>();
            selectedLunch = new List<FoodCheckBoxModel>();
            selectedDinner = new List<FoodCheckBoxModel>();


            menu = new List<FoodIntakeModel>()
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

           
        }

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

            var currentMenu = menu.Where(f => f.Date.Day.Equals(day.Day)).FirstOrDefault();

            if(currentMenu == null)
            {
                currentMenu = new FoodIntakeModel();
            }
           
            bool IsSubmitted = currentMenu.Date.Date < DateTime.Now.Date.AddDays(2);
           
            if (currentMenu.Date.Date == new DateTime())
            {
                IsSubmitted = false;
            }



            ViewBag.IsSubmitted = IsSubmitted;
            ViewBag.DayCount = addDays;
            ViewBag.CurrentDay = Helper.Common.GetDayName(day);

            return View(currentMenu);
        }

        [HttpPost]
        public IActionResult Menu(FoodIntakeModel food,int addDays = 0)
        {

            DateTime day = DateTime.Now.AddDays(addDays);

            var currentMenu = menu.Where(f => f.Date.Day.Equals(day.Day)).FirstOrDefault();

            if (currentMenu == null)
            {
                currentMenu = new FoodIntakeModel();
            }

            bool IsSubmitted = currentMenu.Date.Date < DateTime.Now.Date.AddDays(2);

            if (currentMenu.Date.Date == new DateTime())
            {
                IsSubmitted = false;
            }



            ViewBag.IsSubmitted = IsSubmitted;
            ViewBag.DayCount = addDays;
            ViewBag.CurrentDay = Helper.Common.GetDayName(day);

            return View(currentMenu);
        }

        public IActionResult MealSelection(DateTime Date)
        {
            ViewBag.PageTitle = "Breakfast";
            ViewBag.Date = Date;
            ViewBag.PageNo = 1;
            return View(breakfastCheckbox);
        }

        [HttpPost]
        public IActionResult MealSelection(IEnumerable<FoodCheckBoxModel> SelectedFood,DateTime Date, int PageNo)
        {
            switch(PageNo){
                case 1:
                    ViewBag.PageTitle = "Breakfast";
                    ViewBag.PageNo = PageNo;
                    return View(breakfastCheckbox);
                case 2:
                    ViewBag.PageTitle = "Lunch";
                    ViewBag.PageNo = PageNo;
                    HttpContext.Session.SetObjectAsJson("Breakfast", SelectedFood.Where(m => m.IsChecked).ToList());
                    SelectedFood = new List<FoodCheckBoxModel>();
                    return View(lunchCheckbox);
                case 3:
                    ViewBag.PageTitle = "Dinner";
                    ViewBag.PageNo = PageNo;
                    HttpContext.Session.SetObjectAsJson("Lunch", SelectedFood.Where(m => m.IsChecked).ToList());
                    SelectedFood = new List<FoodCheckBoxModel>();
                    return View(dinnerCheckbox);
                case 4:
                    var food = new FoodIntakeModel();
                    food.Breakfast = new List<FoodModel>();
                    food.Lunch = new List<FoodModel>();
                    food.Dinner = new List<FoodModel>();

                    selectedBreakfast = HttpContext.Session.GetObjectFromJson<List<FoodCheckBoxModel>>("Breakfast");
                    selectedLunch = HttpContext.Session.GetObjectFromJson<List<FoodCheckBoxModel>>("Lunch");
                    selectedDinner = SelectedFood.Where(m => m.IsChecked).ToList();

                    foreach(var item in selectedBreakfast){
                        food.Breakfast.Add(Common.MapCheckBoxToFood(item));
                    }

                    foreach (var item in selectedLunch)
                    {
                        food.Lunch.Add(Common.MapCheckBoxToFood(item));
                    }

                    foreach (var item in selectedDinner)
                    {
                        food.Dinner.Add(Common.MapCheckBoxToFood(item));
                    }

                    return RedirectToAction("Menu", food);
                default:
                    return View();
            }
        }

    }
}
