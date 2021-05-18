using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafeMenuItems
{
    public class CafeMenuRepository
    {
        private readonly List<CafeMenu> _MenuItems = new List<CafeMenu>();
        public bool CreateMenuItems(CafeMenu newItem)
        {
            int itemCount = _MenuItems.Count;
            _MenuItems.Add(newItem);
            bool wasAdded = (_MenuItems.Count > itemCount) ? true : false;
            return wasAdded;
        }
        public List<CafeMenu> ViewMenu()
        {
            return _MenuItems;
        }
        public CafeMenu ViewItemByName(string mealName)
        {
            foreach (CafeMenu menuItem in _MenuItems)
            {
                if (menuItem.MealName.ToLower() == menuItem.MealName)
                {
                    return menuItem;
                }
            }
            return null;
        }
        public bool UpdateMenu(string originalName, CafeMenu newName)
        {
            CafeMenu oldItems = ViewItemByName(originalName);
            if (oldItems != null)
            {
                oldItems.MealName = newName.MealName;
                oldItems.MealDescription = newName.MealDescription;
                oldItems.Ingredients = newName.Ingredients;
                oldItems.Price = newName.Price;
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool DeleteMenuItems(string deleteMenuItem)
        {
            CafeMenu itemToDelete = ViewItemByName(deleteMenuItem);
            if (itemToDelete == null)
            {
                return false;
            }
            else
            {
                _MenuItems.Remove(itemToDelete);
                return true;
            }
        }
    }
}
