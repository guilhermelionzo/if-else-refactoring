using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using bar.interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace bar.tests
{
    [TestClass]
    public class BartenderTests
    {
        private readonly FakeConsoleWriter _consoleWriter = new FakeConsoleWriter();
        IList<string> drinksList = new List<string>() { "beer", "juice" };

        [TestMethod]
        public void ShouldReturnTrue_WhenDrinkIsCalled()
        {
            Bartender bartender = new Bartender(_consoleWriter, new RecipeBook(_consoleWriter));

            _consoleWriter.SetInputBuffer("juice");
            bartender.AskForDrink();
            Debug.Assert(_consoleWriter.GetOutputBuffer() == "Here you go! Fresh and nice juice.");
        }

        [DataRow(null)]
        [DataRow("")]
        [DataRow("Not Exists")]
        [DataTestMethod]
        public void ShouldReturnUnbailableDrink_WhenDrinkDoesNotExists(string input)
        {
            Bartender bartender = new Bartender(_consoleWriter, new RecipeBook(_consoleWriter));

            _consoleWriter.SetInputBuffer(input);
            bartender.AskForDrink();
            Debug.Assert(_consoleWriter.GetOutputBuffer() == $"Sorry bro, but we do not do {input}");
        }
    }
}
