using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace KomodoCafeMenuItems
{
    [TestClass]
    public class CafeMenuTests
    {
        [TestMethod]
        public void ViewMenu_ShouldReturnFullMenu()
        {
            CafeMenu menuItem = new CafeMenu();
            CafeMenuRepository repository = new CafeMenuRepository();

            bool result = repository.ViewMenu(menuItem);

            Assert.IsTrue(result);
        }
    }
}
