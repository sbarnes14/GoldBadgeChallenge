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

        private CafeMenu _cafeMenu;
        private CafeMenuRepository _repo;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new CafeMenuRepository();
            _cafeMenu = new CafeMenu("Grilled Cheese", 4, "Cheese and bread put into the toaster", "cheese, bread", 5);
            _repo.CreateMenuItems(_cafeMenu);
        }

        [TestMethod]
        public void UpdateMenuItems_ShouldReturnpdatedValue()
        {
            CafeMenu menuItem = new CafeMenu();
            CafeMenuRepository repository = new CafeMenuRepository();

            _repo.UpdateMenu("Grilled Cheese", new CafeMenu("Banana", 5, "its a banana", "just banana", 2));
        }
        [TestMethod]
        public void DeleteMenuItems_ShouldReturnTrue()
        {
            bool wasDeleted = _repo.DeleteMenuItems("Grilled Cheese");

            Assert.IsTrue(wasDeleted);
        }
    }
}
