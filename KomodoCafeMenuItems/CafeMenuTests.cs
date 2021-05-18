using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace KomodoCafeMenuItems
{
    [TestClass]
    public class CafeMenuTests
    {
        [TestMethod]
        public void CreateNewItem_ShouldReturnCorrect()
        {
            CafeMenu menuItem = new CafeMenu();
            CafeMenuRepository repository = new CafeMenuRepository();

            bool result = repository.CreateMenuItems(menuItem);

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void ViewMenu_ShouldReturnFullMenu()
        {
            CafeMenu menuItem = new CafeMenu();
            CafeMenuRepository repository = new CafeMenuRepository();
            repository.CreateMenuItems(menuItem);

            List<CafeMenu> directory = repository.ViewMenu();

            bool hasContent = directory.Contains(menuItem);
            Assert.IsTrue(hasContent);
        }
    }
}
