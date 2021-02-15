using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using bar.interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace bar.tests
{
    [TestClass]
    public class RecipeBookTests
    {
        private readonly IConsoleWriter _consoleWriter = new FakeConsoleWriter();
        IList<string> drinksList = new List<string>() { "beer", "juice" };

        [TestMethod]
        public void ShouldReturnTrue_WhenGetAllDrinks()
        {
            RecipeBook recipeBook = new RecipeBook(_consoleWriter);

            foreach (var d in drinksList)
                Debug.Assert(recipeBook.GetAvailableDrinkNames().Contains(d));
        }
    }
}
