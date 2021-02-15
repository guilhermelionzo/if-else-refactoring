using System;
using System.Collections.Generic;
using bar.interfaces;

namespace bar
{
    public class RecipeBook
    {
        private readonly Dictionary<string, Action> _recipes;
        private readonly Func<string> _inputProvider;
        private readonly Action<string> _outputProvider;
        private bool isBelowEighteen(int age) => age >= 18;

        public RecipeBook(IConsoleWriter consoleWriter)
        {
            _inputProvider = consoleWriter.ReadLine;
            _outputProvider = consoleWriter.WriteLine;
            
            _recipes = new Dictionary<string, Action>
            {
                {"beer",ServeBeer},
                {"juice",ServeJuice},
            };
        }
        public void MakeRecipe(string drinkName) => _recipes[drinkName]();
        public IEnumerable<string> GetAvailableDrinkNames() => _recipes.Keys;
        private void ServeJuice() => _outputProvider("Here you go! Fresh and nice juice.");
        private void HandlerInvalidInput() => _outputProvider("Input not valid");

        private void ServeBeer()
        {
            _outputProvider("Not so fast. How old are you?");

            if (!int.TryParse(_inputProvider(), out var age))
            {
                HandlerInvalidInput();
                return;
            }

            HandleBeerAndCheckAge(age);
        }

        private void HandleBeerAndCheckAge(int age)
        {
            if (isBelowEighteen(age))
            {
                _outputProvider("Here you go! Cold beer.");
                return;
            }

            _outputProvider("Sorry but are not older to order a beer.");
        }
    }
}