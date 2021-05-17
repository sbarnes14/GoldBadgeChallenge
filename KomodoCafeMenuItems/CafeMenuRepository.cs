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

        public List<CafeMenu> ViewMenu()
        {
            return _MenuItems;
        }
        public bool CreateMenuItems(CafeMenu newItem)
        {
            int itemCount = _MenuItems.Count;
            _MenuItems.Add(newItem);
            bool wasAdded = (_MenuItems.Count > itemCount) ? true : false;
            return wasAdded;
        }
        public bool UpdateMenu(string originalName, CafeMenu newName)
        {
            CafeMenu oldItems = 
        }
        public bool DeleteMenuItems(string deleteMenuItem)
        {
            CafeMenu itemToDelete = ViewMenu(deleteMenuItem);
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
