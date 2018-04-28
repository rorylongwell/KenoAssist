using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KenoAssist.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Keno.Common;
using KenoAssist.Web.Helper;
using Microsoft.AspNetCore.Http;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KenoAssist.Web.Controllers
{
    public class FoodAndDrinkController : Controller
    {
		private List<FoodModel> breakfastList;
		private List<FoodModel> lunchList;
		private List<FoodModel> dinnerList;

		private List<FoodModel> selectedBreakfast;
		private List<FoodModel> selectedLunch;
		private List<FoodModel> selectedDinner;

		private List<DrinkModel> drinksList;

		List<DrinkIntakeModel> drinkIntakeList;

		IEnumerable<FoodIntakeModel> menu;

		IEnumerable<FoodIntakeModel> foodIntakeList;

        public FoodAndDrinkController()
        {
			breakfastList = new List<FoodModel>()
            {
				new FoodModel(){Id = 1, Name = "Toast and jam", FoodTypeId = 1},
				new FoodModel(){Id = 2, Name = "Scrambled eggs and toast", FoodTypeId = 1},
				new FoodModel(){Id = 3, Name = "Porridge (lactose free milk)", FoodTypeId = 1},
				new FoodModel(){Id = 4, Name = "Rice Krispies (lactose free milk)", FoodTypeId = 1},
				new FoodModel(){Id = 5, Name = "Pancakes and jam", FoodTypeId = 1},
				new FoodModel(){Id = 6, Name = "Apple slices", FoodTypeId = 2},
				new FoodModel(){Id = 7, Name = "Lacotose free strawberry yogurt", FoodTypeId = 2},
				new FoodModel(){Id = 8, Name = "Large orange", FoodTypeId = 2}
            };

			lunchList = new List<FoodModel>()
            {
				new FoodModel(){Id = 1, Name = "Vegetable soup and a bap", FoodTypeId = 1},
				new FoodModel(){Id = 2, Name = "Sausage rolls", FoodTypeId = 1},
				new FoodModel(){Id = 3, Name = "Baked potato, chicken and lactose free cheese", FoodTypeId = 1},
				new FoodModel(){Id = 4, Name = "Chicken sandwich", FoodTypeId = 1},
				new FoodModel(){Id = 5, Name = "Tuna and onion sandwich", FoodTypeId = 1},
				new FoodModel(){Id = 6, Name = "Melon selection", FoodTypeId = 2},
				new FoodModel(){Id = 7, Name = "Lacotose free strawberry yogurt", FoodTypeId = 2},
				new FoodModel(){Id = 8, Name = "Strawberry jelly", FoodTypeId = 2}
            };

			dinnerList = new List<FoodModel>()
            {
				new FoodModel(){Id = 1, Name = "Chicken curry and rice", FoodTypeId = 1},
				new FoodModel(){Id = 2, Name = "Fish and chips", FoodTypeId = 1},
				new FoodModel(){Id = 3, Name = "Tuna salad", FoodTypeId = 1},
				new FoodModel(){Id = 4, Name = "Sausage and chips", FoodTypeId = 1},
				new FoodModel(){Id = 5, Name = "Beef stew", FoodTypeId = 1},
				new FoodModel(){Id = 6, Name = "Lacotose free ice-cream", FoodTypeId = 2},
				new FoodModel(){Id = 7, Name = "Lacotose free custard and cake", FoodTypeId = 2},
				new FoodModel(){Id = 8, Name = "Sttrawberry jelly", FoodTypeId = 2}
            };

			selectedBreakfast = new List<FoodModel>();
			selectedLunch = new List<FoodModel>();
			selectedDinner = new List<FoodModel>();


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

			drinksList = new List<DrinkModel>(){

				new DrinkModel(){Id = 1, Name = "Diluted Juice"},
				new DrinkModel(){Id = 2, Name = "Tea"},
				new DrinkModel(){Id = 3, Name = "Coffee"},
				new DrinkModel(){Id = 4, Name = "Water"},
				new DrinkModel(){Id = 5, Name = "Milk"},
				new DrinkModel(){Id = 6, Name = "Orange Juice"},
				new DrinkModel(){Id = 7, Name = "Apple Juice"},
				new DrinkModel(){Id = 8, Name = "Cranberry Juice"},

			};

			drinkIntakeList = new List<DrinkIntakeModel>{
				new DrinkIntakeModel()
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

				},
				new DrinkIntakeModel()
				{
					ClientId = 1,
					Date = DateTime.Now.AddDays(-1),
					Drinks = new List<DrinkModel>()
					{
					new DrinkModel(){Id = 1, Name = "Orange Juice", Volume=250},
					new DrinkModel(){Id = 3, Name = "Diluted Juice", Volume=500},
					new DrinkModel(){Id = 4, Name = "Diluted Juice", Volume=250},
					},
					TotalVolume = 1000

				},
				new DrinkIntakeModel()
				{
					ClientId = 1,
					Date = DateTime.Now.AddDays(-2),
					Drinks = new List<DrinkModel>()
					{
					new DrinkModel(){Id = 1, Name = "Orange Juice", Volume=250},
						new DrinkModel(){Id = 2, Name = "Tea", Volume=250},
					new DrinkModel(){Id = 3, Name = "Diluted Juice", Volume=300},
					new DrinkModel(){Id = 4, Name = "Diluted Juice", Volume=250},
					},
					TotalVolume = 1050

				},
                
			};

			foodIntakeList = new List<FoodIntakeModel>
			{
				new FoodIntakeModel()
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
				},
					new FoodIntakeModel()
	{
				ClientId =1 ,
						Date = DateTime.Now.AddDays(-1),
				Breakfast = new List<FoodModel>()
						{
							new FoodModel(){Id = 1, Name = "Scrambled eggs and toast"},
					new FoodModel(){Id = 2, Name = "An Orange"}
				},
				Lunch = new List<FoodModel>()
				{
							new FoodModel(){Id = 3, Name = "Sausage rolls"},
					new FoodModel(){Id = 4, Name = "Strawberry Yogurt"}
				},
				Dinner = new List<FoodModel>()
						{new FoodModel(){Id = 5, Name = "Beef stew"},
					new FoodModel(){Id = 6, Name = "Cake and Custard"}
				},
				Snacks = new List<FoodModel>()
				{
				}


			}

			};

           
        }

        public IActionResult Index()
        {
            return View();
        }

		public IActionResult Food(int addDays = 0)
        {
				DateTime day = DateTime.Now.AddDays(addDays);

				var foodIntake = foodIntakeList.Where(f => f.Date.Day.Equals(day.Day)).FirstOrDefault();
                if (foodIntake == null)
                {
				    foodIntake = new FoodIntakeModel();
				    foodIntake.Breakfast = new List<FoodModel>();
				    foodIntake.Lunch = new List<FoodModel>();
				    foodIntake.Dinner = new List<FoodModel>();
				    foodIntake.Snacks = new List<FoodModel>();
                }
			bool IsSubmitted = foodIntake.Date.Date < DateTime.Now.Date;

        ViewBag.IsSubmitted = IsSubmitted;
        ViewBag.DayCount = addDays;
        ViewBag.CurrentDay = Helper.Common.GetDayName(day);
              

            return View(foodIntake);
        }

		public IActionResult Drink(int addDays = 0)
        {
			DateTime day = DateTime.Now.AddDays(addDays); 

			var drinkIntake = drinkIntakeList.Where(f => f.Date.Day.Equals(day.Day)).FirstOrDefault();

			if(drinkIntake == null)
			{
				drinkIntake = new DrinkIntakeModel();
			}
			bool IsSubmitted = drinkIntake.Date.Date < DateTime.Now.Date;

			ViewBag.IsSubmitted = IsSubmitted;
            ViewBag.DayCount = addDays;
			ViewBag.CurrentDay = Helper.Common.GetDayName(day);

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
       
        public IActionResult MenuSubmit(string Date)
        {
            Date = Common.RemoveSuffix(Date);
			DateTime day = Convert.ToDateTime(Date);

			FoodIntakeModel food = HttpContext.Session.GetObjectFromJson<FoodIntakeModel>("NewMenuSelection");

			var currentMenu = food;

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
			ViewBag.DayCount = day.Day - DateTime.Now.Day;
            ViewBag.CurrentDay = Helper.Common.GetDayName(day);

            return View("Menu",currentMenu);
        }
        
        public IActionResult MealSelection(string Date)
        {
            ViewBag.PageTitle = "Breakfast";
            ViewBag.Date = Date;
            ViewBag.PageNo = 1;

			var mealItems = new MealSelectionModel();
			mealItems.Mains = breakfastList.Where(m => m.FoodTypeId == 1).ToList();
			mealItems.Sides = breakfastList.Where(m => m.FoodTypeId == 2).ToList();

			return View(mealItems);
        }

        [HttpPost]
		public IActionResult MealSelection(MealSelectionModel model,string date, int pageNo)
        {
			switch(pageNo){
                case 1:
                    ViewBag.PageTitle = "Breakfast";
					ViewBag.PageNo = pageNo;
					var breakfastItems = new MealSelectionModel();
					breakfastItems.Mains = breakfastList.Where(m => m.FoodTypeId == 1).ToList();
					breakfastItems.Sides = breakfastList.Where(m => m.FoodTypeId == 2).ToList();
					return View(breakfastItems);
                case 2:
                    ViewBag.PageTitle = "Lunch";
					ViewBag.Date = date;
					ViewBag.PageNo = pageNo;
					HttpContext.Session.SetObjectAsJson("Breakfast", breakfastList.Where(m => m.Id == model.SelectedMain || m.Id == model.SelectedSide).ToList());
					ModelState.Clear();
					var lunchItems = new MealSelectionModel();
					lunchItems.Mains = lunchList.Where(m => m.FoodTypeId == 1).ToList();
					lunchItems.Sides = lunchList.Where(m => m.FoodTypeId == 2).ToList();
					return View(lunchItems);
                case 3:
                    ViewBag.PageTitle = "Dinner";
					ViewBag.Date = date;
					ViewBag.PageNo = pageNo;
					HttpContext.Session.SetObjectAsJson("Lunch", lunchList.Where(m => m.Id == model.SelectedMain || m.Id == model.SelectedSide).ToList());
					ModelState.Clear();
					var dinnerItems = new MealSelectionModel();
					dinnerItems.Mains = dinnerList.Where(m => m.FoodTypeId == 1).ToList();
					dinnerItems.Sides = dinnerList.Where(m => m.FoodTypeId == 2).ToList();
					return View(dinnerItems);
                case 4:
                    var _food = new FoodIntakeModel();
					_food.Breakfast = new List<FoodModel>();
					_food.Lunch = new List<FoodModel>();
					_food.Dinner = new List<FoodModel>();

                    selectedBreakfast = HttpContext.Session.GetObjectFromJson<List<FoodModel>>("Breakfast");
					selectedLunch = HttpContext.Session.GetObjectFromJson<List<FoodModel>>("Lunch");
					selectedDinner = dinnerList.Where(m => m.Id == model.SelectedMain || m.Id == model.SelectedSide).ToList();
                                  
					_food.Breakfast.AddRange(selectedBreakfast);
					_food.Lunch.AddRange(selectedLunch);
					_food.Dinner.AddRange(selectedDinner);


					HttpContext.Session.SetObjectAsJson("NewMenuSelection", _food);

					return RedirectToAction("MenuSubmit", new {Date = date});
                default:
                    return View();
            }
        }

		public IActionResult AddDrink(){
			
			var drinkModel = new DrinkSelectionModel();
			drinkModel.Drinks = drinksList;
			return View(drinkModel);
		}
        
		[HttpPost]
		public IActionResult AddDrinkVolume(DrinkSelectionModel model)
		{
			var drink = drinksList.Where(m => m.Id == model.SelectedDrink).FirstOrDefault();
			var name = HttpContext.Session.GetString("Name");
            ViewBag.Name = name.Substring(0, name.IndexOf(" "));
			return View(drink);
        }
        
		public IActionResult SearchDrink(string searchString){
			
			var drinkModel = new DrinkSelectionModel();

			var drinks = drinksList;

			drinkModel.Drinks = drinks;

			if(!string.IsNullOrEmpty(searchString))
			{
				drinkModel.Drinks = drinks.Where(m => m.Name.ToLower().Contains(searchString.ToLower())).ToList();
			}
                   
			return View("AddDrink", drinkModel);
        }

		public IActionResult AddedDrink(DrinkModel drink)
		{
			DateTime day = DateTime.Now;

            var drinkIntake = drinkIntakeList.Where(f => f.Date.Day.Equals(day.Day)).FirstOrDefault();

			drinkIntake.Drinks.Add(drink);

			var totalVolume = drinkIntake.TotalVolume;
			drinkIntake.TotalVolume = totalVolume + drink.Volume;

			ViewBag.IsSubmitted = false;
			ViewBag.DayCount = 0;
            ViewBag.CurrentDay = Helper.Common.GetDayName(day);

			return View("Drink", drinkIntake);      
		}
    }
}
