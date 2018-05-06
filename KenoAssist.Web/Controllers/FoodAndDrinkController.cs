using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KenoAssist.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Keno.Common;
using KenoAssist.Web.Helper;
using Microsoft.AspNetCore.Http;

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
				new FoodModel(){Id = 7, Name = "Vegetable soup and a bap", FoodTypeId = 1},
				new FoodModel(){Id = 8, Name = "Sausage rolls", FoodTypeId = 1},
				new FoodModel(){Id = 9, Name = "Baked potato, chicken and lactose free cheese", FoodTypeId = 1},
				new FoodModel(){Id = 10, Name = "Chicken sandwich", FoodTypeId = 1},
				new FoodModel(){Id = 11, Name = "Tuna and onion sandwich", FoodTypeId = 1},
				new FoodModel(){Id = 12, Name = "Melon selection", FoodTypeId = 2},
				new FoodModel(){Id = 13, Name = "Lacotose free strawberry yogurt", FoodTypeId = 2},
				new FoodModel(){Id = 14, Name = "Strawberry jelly", FoodTypeId = 2}
            };

			dinnerList = new List<FoodModel>()
            {
				new FoodModel(){Id = 15, Name = "Chicken curry and rice", FoodTypeId = 1},
				new FoodModel(){Id = 16, Name = "Fish and chips", FoodTypeId = 1},
				new FoodModel(){Id = 17, Name = "Tuna salad", FoodTypeId = 1},
				new FoodModel(){Id = 18, Name = "Sausage and chips", FoodTypeId = 1},
				new FoodModel(){Id = 19, Name = "Beef stew", FoodTypeId = 1},
				new FoodModel(){Id = 20, Name = "Lacotose free ice-cream", FoodTypeId = 2},
				new FoodModel(){Id = 21, Name = "Lacotose free custard and cake", FoodTypeId = 2},
				new FoodModel(){Id = 22, Name = "Strawberry jelly", FoodTypeId = 2}
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
                        new FoodModel(){Id = 1, Name = "Toast and Jam", PercentageAmount=80},
                        new FoodModel(){Id = 2, Name = "An Orange", PercentageAmount=100}
                    },
                    Lunch = new List<FoodModel>()
                    {
                        new FoodModel(){Id = 3, Name = "Chicken Sandwich", PercentageAmount=100},
                        new FoodModel(){Id = 4, Name = "Strawberry Yogurt", PercentageAmount=80}
                    },
                    Dinner = new List<FoodModel>()
                    {
                        new FoodModel(){Id = 5, Name = "Battered Fish and Chips", PercentageAmount=50},
                        new FoodModel(){Id = 6, Name = "Cake and Custard", PercentageAmount=10}
                    }
                },
                new FoodIntakeModel()
                {
                    ClientId = 1,
                    Date = DateTime.Now.AddDays(1),
                    Breakfast = new List<FoodModel>()
                    {
                        new FoodModel(){Id = 1, Name = "Toast and Jam", PercentageAmount=100},
                        new FoodModel(){Id = 2, Name = "An Orange", PercentageAmount=100}
                    },
                    Lunch = new List<FoodModel>()
                    {
                        new FoodModel(){Id = 3, Name = "Chicken Sandwich", PercentageAmount=80},
                        new FoodModel(){Id = 4, Name = "Strawberry Yogurt", PercentageAmount=30}
                    },
                    Dinner = new List<FoodModel>()
                    {
                        new FoodModel(){Id = 5, Name = "Battered Fish and Chips", PercentageAmount=100},
                        new FoodModel(){Id = 6, Name = "Cake and Custard", PercentageAmount=80}
                    }
                },

                new FoodIntakeModel()
                {
                    ClientId = 1,
                    Date = DateTime.Now.AddDays(2),
                    Breakfast = new List<FoodModel>()
                    {
                        new FoodModel(){Id = 1, Name = "Toast and Jam", PercentageAmount=80},
                        new FoodModel(){Id = 2, Name = "An Orange", PercentageAmount=50}
                    },
                    Lunch = new List<FoodModel>()
                    {
                        new FoodModel(){Id = 3, Name = "Chicken Sandwich", PercentageAmount=100},
                        new FoodModel(){Id = 4, Name = "Strawberry Yogurt", PercentageAmount=80}
                    },
                    Dinner = new List<FoodModel>()
                    {
                        new FoodModel(){Id = 5, Name = "Battered Fish and Chips", PercentageAmount=100},
                        new FoodModel(){Id = 6, Name = "Cake and Custard", PercentageAmount=50}
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
                        new FoodModel(){Id = 1, Name = "Toast and Jam", PercentageAmount=80, FoodTypeId=1},
                        new FoodModel(){Id = 2, Name = "An Orange", PercentageAmount=70, FoodTypeId=2}
				},
				Lunch = new List<FoodModel>()
				{
                        new FoodModel(){Id = 3, Name = "Chicken Sandwich", PercentageAmount=100, FoodTypeId=1},
                        new FoodModel(){Id = 4, Name = "Strawberry Yogurt", PercentageAmount=20, FoodTypeId=2}
				},
				Dinner = new List<FoodModel>()
				{
                        new FoodModel(){Id = 5, Name = "Battered Fish and Chips", PercentageAmount=null, FoodTypeId=1},
                        new FoodModel(){Id = 6, Name = "Cake and Custard", PercentageAmount=null, FoodTypeId=2}
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
                        new FoodModel(){Id = 1, Name = "Scrambled eggs and toast", PercentageAmount=100, FoodTypeId=1},
                        new FoodModel(){Id = 2, Name = "An Orange", PercentageAmount=70, FoodTypeId=2}
				},
				Lunch = new List<FoodModel>()
				{
                        new FoodModel(){Id = 3, Name = "Sausage rolls", PercentageAmount=65, FoodTypeId=1},
                        new FoodModel(){Id = 4, Name = "Strawberry Yogurt", PercentageAmount=50, FoodTypeId=2}
				},
				Dinner = new List<FoodModel>()
                    {new FoodModel(){Id = 5, Name = "Beef stew", PercentageAmount=20, FoodTypeId=1},
                        new FoodModel(){Id = 6, Name = "Cake and Custard", PercentageAmount=35, FoodTypeId=2}
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

            ViewBag.BreakfastCount = 0;
            ViewBag.LunchCount = 0;
            ViewBag.DinnerCount = 0;
            ViewBag.SnackCount = 0;
            int breakfast=0;
            int lunch=0;
            int dinner=0;

            var user = HttpContext.Session.GetString("UserType");
            ViewBag.IsStaff = user.Equals("staff");

		    var foodIntake = foodIntakeList.Where(f => f.Date.Day.Equals(day.Day)).FirstOrDefault();
            if (foodIntake == null)
            {
				foodIntake = new FoodIntakeModel();
				    foodIntake.Breakfast = new List<FoodModel>();
				    foodIntake.Lunch = new List<FoodModel>();
				    foodIntake.Dinner = new List<FoodModel>();
				    foodIntake.Snacks = new List<FoodModel>();
            }
            else
            {
                if ((foodIntake.Breakfast[0].PercentageAmount + foodIntake.Breakfast[1].PercentageAmount) / 2 != null)
                {
                    breakfast = (int)(foodIntake.Breakfast[0].PercentageAmount + foodIntake.Breakfast[1].PercentageAmount) / 2;
                    ViewBag.BreakfastCount = breakfast;
                }
                else
                {
                    ViewBag.BreakfastCount = null;
                }
                if ((foodIntake.Lunch[0].PercentageAmount + foodIntake.Lunch[1].PercentageAmount) / 2 != null)
                {
                    lunch = (int)(foodIntake.Lunch[0].PercentageAmount + foodIntake.Lunch[1].PercentageAmount) / 2;
                    ViewBag.LunchCount = lunch;
                }
                else
                {
                    ViewBag.LunchCount = null;
                }
                if ((foodIntake.Dinner[0].PercentageAmount + foodIntake.Dinner[1].PercentageAmount) / 2 != null)
                {
                    dinner = (int)(foodIntake.Dinner[0].PercentageAmount + foodIntake.Dinner[1].PercentageAmount) / 2;
                    ViewBag.DinnerCount = dinner;
                }
                else
                {
                    ViewBag.DinnerCount = null;
                }

                if(foodIntake.Snacks.Any())
                {
                    ViewBag.SnackCount = foodIntake.Snacks[0].PercentageAmount;
                }
                else
                {
                    ViewBag.SnackCount = 0;
                }




            }
			bool IsSubmitted = foodIntake.Date.Date < DateTime.Now.Date;

            ViewBag.BreakfastColour = GetColourString(breakfast);
            ViewBag.LunchColour = GetColourString(lunch);
            ViewBag.DinnerColour = GetColourString(dinner);

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

            var user = HttpContext.Session.GetString("UserType");
            ViewBag.IsStaff = user.Equals("staff");

			ViewBag.IsSubmitted = IsSubmitted;
            ViewBag.DayCount = addDays;
			ViewBag.CurrentDay = Helper.Common.GetDayName(day);

            decimal percentage = (drinkIntake.TotalVolume * 100) / 2000;
            ViewBag.Percentage = percentage;

            ViewBag.Colour = GetDrinkColourString(percentage);

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

            var user = HttpContext.Session.GetString("UserType");
            ViewBag.IsStaff = user.Equals("staff");
                     
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

            var user = HttpContext.Session.GetString("UserType");
            ViewBag.IsStaff = user.Equals("staff");

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
            ViewBag.ProfileImage = HttpContext.Session.GetString("Photo");
            var name = HttpContext.Session.GetString("Name");
            ViewBag.AllergyInfo = string.Format("<span class='bold'>{0}</span> is <span class='bold'>lactose intolerant</span>. The menu options have been filtered to accommated this.",name);

			var mealItems = new MealSelectionModel();
			mealItems.Mains = breakfastList.Where(m => m.FoodTypeId == 1).ToList();
			mealItems.Sides = breakfastList.Where(m => m.FoodTypeId == 2).ToList();

			return View(mealItems);
        }

        [HttpPost]
		public IActionResult MealSelection(MealSelectionModel model,string date, int pageNo)
        {
            ViewBag.ProfileImage = HttpContext.Session.GetString("Photo");
            var name = HttpContext.Session.GetString("Name");
            ViewBag.AllergyInfo = string.Format("{0} is lactose intolerant. The menu options have been filtered to accommated this.", name);
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
            ViewBag.Title = "Suggestions";
			return View(drinkModel);
		}
        
		[HttpPost]
		public IActionResult AddDrinkVolume(DrinkSelectionModel model)
		{
			var drink = drinksList.Where(m => m.Id == model.SelectedDrink).FirstOrDefault();
			var name = HttpContext.Session.GetString("Name");
            ViewBag.Name = name.Substring(0, name.IndexOf(" "));
            ViewBag.Title = "Search Results";
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

            var user = HttpContext.Session.GetString("UserType");
            ViewBag.IsStaff = user.Equals("staff");

			ViewBag.IsSubmitted = false;
			ViewBag.DayCount = 0;
            ViewBag.CurrentDay = Helper.Common.GetDayName(day);

            decimal percentage= (drinkIntake.TotalVolume * 100) / 2000;
            ViewBag.Percentage = percentage;
            ViewBag.Colour = GetDrinkColourString(percentage);

			return View("Drink", drinkIntake);      
		}

        public IActionResult AddFood()
        {
            var food = new FoodSelectionModel();
            food.Food = breakfastList.Concat(lunchList).Concat(dinnerList).ToList();
            ViewBag.Title = "Suggestions";
            return View(food);
        }

        public IActionResult SearchFood(string searchString)
        {

            var foodModel = new FoodSelectionModel();

            var food = breakfastList.Concat(lunchList).Concat(dinnerList).ToList();

            foodModel.Food = food;

            if (!string.IsNullOrEmpty(searchString))
            {
                foodModel.Food = food.Where(m => m.Name.ToLower().Contains(searchString.ToLower())).ToList();
            }
            ViewBag.Title = "Search Results";
            return View("AddFood", foodModel);
        }

        [HttpPost]
        public IActionResult AddFoodAmount(FoodSelectionModel model){
            var foodList = breakfastList.Concat(lunchList).Concat(dinnerList).ToList();
            var food = foodList.Where(m => m.Id == model.SelectedFood).FirstOrDefault();
            var name = HttpContext.Session.GetString("Name");
            ViewBag.Name = name.Substring(0, name.IndexOf(" "));
            return View(food);
        }

        public IActionResult AddedFood(FoodModel food)
        {
            DateTime day = DateTime.Now;
            int breakfast = 0;
            int lunch = 0;
            int dinner = 0;
            int snack = 0;


            var foodIntake = foodIntakeList.Where(f => f.Date.Day.Equals(day.Day)).FirstOrDefault();

            foodIntake.Snacks.Add(food);

            ViewBag.IsSubmitted = false;
            ViewBag.DayCount = 0;
            ViewBag.CurrentDay = Helper.Common.GetDayName(day);

            ViewBag.BreakfastCount = (foodIntake.Breakfast[0].PercentageAmount + foodIntake.Breakfast[1].PercentageAmount) / 2;
            ViewBag.LunchCount = (foodIntake.Lunch[0].PercentageAmount + foodIntake.Lunch[1].PercentageAmount) / 2;
            ViewBag.DinnerCount = (foodIntake.Dinner[0].PercentageAmount + foodIntake.Dinner[1].PercentageAmount) / 2;
            ViewBag.SnackCount = foodIntake.Snacks[0].PercentageAmount;

            if ((foodIntake.Breakfast[0].PercentageAmount + foodIntake.Breakfast[1].PercentageAmount) / 2 != null)
            {
                breakfast = (int)(foodIntake.Breakfast[0].PercentageAmount + foodIntake.Breakfast[1].PercentageAmount) / 2;
                ViewBag.BreakfastCount = breakfast;
            }
            else
            {
                ViewBag.BreakfastCount = null;
            }
            if ((foodIntake.Lunch[0].PercentageAmount + foodIntake.Lunch[1].PercentageAmount) / 2 != null)
            {
                lunch = (int)(foodIntake.Lunch[0].PercentageAmount + foodIntake.Lunch[1].PercentageAmount) / 2;
                ViewBag.LunchCount = lunch;
            }
            else
            {
                ViewBag.LunchCount = null;
            }
            if ((foodIntake.Dinner[0].PercentageAmount + foodIntake.Dinner[1].PercentageAmount) / 2 != null)
            {
                dinner = (int)(foodIntake.Dinner[0].PercentageAmount + foodIntake.Dinner[1].PercentageAmount) / 2;
                ViewBag.DinnerCount = dinner;
            }
            else
            {
                ViewBag.DinnerCount = null;
            }
            if (foodIntake.Snacks[0].PercentageAmount != null)
            {
                snack = (int)foodIntake.Snacks[0].PercentageAmount;
                ViewBag.SnackCount = snack;
            }
            else
            {
                ViewBag.SnackCount = null;
            }

            var user = HttpContext.Session.GetString("UserType");
            ViewBag.IsStaff = user.Equals("staff");

            ViewBag.BreakfastColour = GetColourString(breakfast);
            ViewBag.LunchColour = GetColourString(lunch);
            ViewBag.DinnerColour = GetColourString(dinner);
            ViewBag.SnackColour = GetColourString(snack);

            return View("Food", foodIntake);
        }

        public string GetColourString(int value)
        {
            string red = "#C95345";
            string orange = "#CD8C2A";
            string green = "#74AA4E";
            if(value <= 33)
            {
                return red;
            }
            if(value <= 66)
            {
                return orange; 
            }
            else
            {
                return green;
            }
        }

        public string GetDrinkColourString(decimal value)
        {
            string red = "#C95345";
            string orange = "#CD8C2A";
            string green = "#74AA4E";
            if (value <= 33)
            {
                return red;
            }
            if (value <= 66)
            {
                return orange;
            }
            else
            {
                return green;
            }
        }

        public IActionResult FoodIntakeDetails(DateTime date, int mealId)
        {
            var model = foodIntakeList.Where(m => m.Date.Date == date.Date).FirstOrDefault();
            ViewBag.Date = Common.GetDayName(date);
            ViewBag.ProfileImage = HttpContext.Session.GetString("Photo");
            var food = new FoodIntakeDetailsModel();
            var name = HttpContext.Session.GetString("Name");
            var firstName = name.Substring(0, name.IndexOf(" "));
            food.MealId = mealId;
            switch(mealId)
            {
                case 1:
                    food.Main = model.Breakfast.Where(m => m.FoodTypeId == 1).FirstOrDefault();
                    food.Side = model.Breakfast.Where(m => m.FoodTypeId == 2).FirstOrDefault();
                    food.Summary = string.Format("{0} eat well today as normal", firstName);
                    ViewBag.Meal = "Breakfast";
                    break;
                case 2:
                    food.Main = model.Lunch.Where(m => m.FoodTypeId == 1).FirstOrDefault();
                    food.Side = model.Lunch.Where(m => m.FoodTypeId == 2).FirstOrDefault();
                    food.Summary = string.Format("{0} eat well today as normal", firstName);
                    ViewBag.Meal = "Lunch";
                    break;
                case 3:
                    food.Main = model.Dinner.Where(m => m.FoodTypeId == 1).FirstOrDefault();
                    food.Side = model.Dinner.Where(m => m.FoodTypeId == 2).FirstOrDefault();
                    food.Summary = string.Format("{0} eat well today as normal", firstName);
                    ViewBag.Meal = "Dinner";
                    break;
            }

            ViewBag.MainCount = food.Main.PercentageAmount;
            ViewBag.SideCount = food.Side.PercentageAmount;
            ViewBag.TotalCount = (food.Main.PercentageAmount + food.Side.PercentageAmount)/2;

            ViewBag.MainColour = GetColourString((int)food.Main.PercentageAmount);
            ViewBag.SideColour = GetColourString((int)food.Side.PercentageAmount);
            ViewBag.TotalColour = GetColourString((int)(food.Main.PercentageAmount + food.Side.PercentageAmount) / 2);

            return View(food);
        }

        public IActionResult AddFoodIntakeDetails(DateTime date, int mealId){
            var food = new FoodIntakeDetailsModel();
            var model = foodIntakeList.Where(m => m.Date.Date == date.Date).FirstOrDefault();
            ViewBag.Date = Common.GetDayName(date);
            food.MealId = mealId;
            switch (mealId)
            {
                case 1:
                    food.Main = model.Breakfast.Where(m => m.FoodTypeId == 1).FirstOrDefault();
                    food.Side = model.Breakfast.Where(m => m.FoodTypeId == 2).FirstOrDefault();
                    ViewBag.Meal = "Breakfast";
                    break;
                case 2:
                    food.Main = model.Lunch.Where(m => m.FoodTypeId == 1).FirstOrDefault();
                    food.Side = model.Lunch.Where(m => m.FoodTypeId == 2).FirstOrDefault();
                    ViewBag.Meal = "Lunch";
                    break;
                case 3:
                    food.Main = model.Dinner.Where(m => m.FoodTypeId == 1).FirstOrDefault();
                    food.Side = model.Dinner.Where(m => m.FoodTypeId == 2).FirstOrDefault();
                    ViewBag.Meal = "Dinner";
                    break;
            }
            return View(food);
        }

        [HttpPost]
        public IActionResult AddedFoodIntake(FoodIntakeDetailsModel model)
        {
            var foodIntake = foodIntakeList.Where(m => m.Date.Date == DateTime.Now.Date).FirstOrDefault();

            if(0 > model.Main.PercentageAmount && model.Main.PercentageAmount < 100){
                ModelState.AddModelError("Main.PercentageAmount","Enter a number between 0 and 100");
            }
            if (0 > model.Side.PercentageAmount && model.Side.PercentageAmount < 100)
            {
                ModelState.AddModelError("Side.PercentageAmount", "Enter a number between 0 and 100");
            }
            if(model.Main.PercentageAmount == null)
            {
                ModelState.AddModelError("Main.PercentageAmount", "Enter a number between 0 and 100");
            }
            if (model.Side.PercentageAmount == null)
            {
                ModelState.AddModelError("Side.PercentageAmount", "Enter a number between 0 and 100");
            }
            if (string.IsNullOrEmpty(model.Summary))
            {
                ModelState.AddModelError("Summary", "Enter a summary");
            }

            if (!ModelState.IsValid)
                return View("AddFoodIntakeDetails",model);

            switch (model.MealId)
            {
                case 1:
                    foodIntake.Breakfast = new List<FoodModel>();
                    foodIntake.Breakfast.Add(model.Main);
                    foodIntake.Breakfast.Add(model.Side);
                    break;
                case 2:
                    foodIntake.Lunch = new List<FoodModel>();
                    foodIntake.Lunch.Add(model.Main);
                    foodIntake.Lunch.Add(model.Side);
                    break;
                case 3:
                    foodIntake.Dinner = new List<FoodModel>();
                    foodIntake.Dinner.Add(model.Main);
                    foodIntake.Dinner.Add(model.Side);
                    break;
            }

            var user = HttpContext.Session.GetString("UserType");
            ViewBag.IsStaff = user.Equals("staff");

            ViewBag.IsSubmitted = false;
            ViewBag.DayCount = 0;
            ViewBag.CurrentDay = Helper.Common.GetDayName(DateTime.Now.Date);

            ViewBag.BreakfastCount = (foodIntake.Breakfast[0].PercentageAmount + foodIntake.Breakfast[1].PercentageAmount) / 2;
            ViewBag.LunchCount = (foodIntake.Lunch[0].PercentageAmount + foodIntake.Lunch[1].PercentageAmount) / 2;
            ViewBag.DinnerCount = (foodIntake.Dinner[0].PercentageAmount + foodIntake.Dinner[1].PercentageAmount) / 2;
            ViewBag.SnackCount = 0;


            return View("Food", foodIntake);
        }

    }
}
