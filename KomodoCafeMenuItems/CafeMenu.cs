using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafeMenuItems
{
    public enum MealNumber { Sandwich, soup, salad, bagel }
    public class CafeMenu
    {
        public string MealName { get; set; }
        public MealNumber MealNumber { get; set; }
        public string MealDescription { get; set; }
        public string Ingredients { get; set; }
        public double Price { get; set; }

        public CafeMenu() { }
        public CafeMenu(string mealName, MealNumber mealNumber, string mealDescription, string ingredients, double price)
        {
            MealName = mealName;
            MealNumber = mealNumber;
            MealDescription = mealDescription;
            Ingredients = ingredients;
            Price = price;
        }
    }
}
