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
        private readonly FakeConsoleWriter _consoleWriter = new FakeConsoleWriter();
        IList<string> drinksList = new List<string>() { "beer", "juice" };

        [TestMethod]
        public void ShouldReturnTrue_WhenGetAllDrinks()
        {
            RecipeBook recipeBook = new RecipeBook(_consoleWriter);

            foreach (var d in drinksList)
                Debug.Assert(recipeBook.GetAvailableDrinkNames().Contains(d));
        }

        [TestMethod]
        [ExpectedException(typeof(System.Collections.Generic.KeyNotFoundException))]
        public void ShouldThrownException_WhenInputAnInvalidDrink()
        {
            RecipeBook recipeBook = new RecipeBook(_consoleWriter);

            recipeBook.MakeRecipe("invalidDrink");
        }

        [TestMethod]
        public void ShouldServerJuice_WhenJuiceIsSelected()
        {
            RecipeBook recipeBook = new RecipeBook(_consoleWriter);

            recipeBook.MakeRecipe("juice");
            Debug.Assert(_consoleWriter.GetOutputBuffer() == "Here you go! Fresh and nice juice.");

        }

        [TestMethod]
        public void ShouldServerBeer_WhenClientIsAbove18()
        {
            RecipeBook recipeBook = new RecipeBook(_consoleWriter);

            _consoleWriter.SetInputBuffer("20");
            recipeBook.MakeRecipe("beer");

            Debug.Assert(_consoleWriter.GetOutputBuffer() == "Here you go! Cold beer.");
        }
        [TestMethod]
        public void ShouldNotServerBeer_WhenClientIsBelow18()
        {
            RecipeBook recipeBook = new RecipeBook(_consoleWriter);

            _consoleWriter.SetInputBuffer("17");
            recipeBook.MakeRecipe("beer");

            Debug.Assert(_consoleWriter.GetOutputBuffer() == "Sorry but are not older to order a beer.");
        }

        [DataRow("aaaa")]
        [DataRow("")]
        [DataRow(null)]
        [DataRow("123..0123")]
        [DataRow("5t5g5&^%%")]
        [DataTestMethod]
        public void ShouldNotInvokeAnyMethod_WhenInputIsInvalid(string input)
        {
            RecipeBook recipeBook = new RecipeBook(_consoleWriter);

            _consoleWriter.SetInputBuffer(input);
            recipeBook.MakeRecipe("beer");

            Debug.Assert(_consoleWriter.GetOutputBuffer() == "Input not valid");
        }
    }
}
