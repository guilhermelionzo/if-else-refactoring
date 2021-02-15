using System;
using System.Linq;
using bar.interfaces;

namespace bar
{
    public class Bartender
    {
        private readonly Func<string> _inputProvider;
        private readonly Action<string> _outputProvider;
        private readonly RecipeBook _recipeBook;

        public Bartender(IConsoleWriter consoleWriter, RecipeBook recipeBook = null)
        {
            _inputProvider = consoleWriter.ReadLine;
            _outputProvider = consoleWriter.WriteLine;
            _recipeBook = recipeBook;
        }

        public void AskForDrink()
        {
            _outputProvider($"What drink do you want? ({string.Join(", ", _recipeBook.GetAvailableDrinkNames())})");

            var drink = _inputProvider() ?? string.Empty;

            if (_recipeBook.GetAvailableDrinkNames().Contains(drink)) _recipeBook.MakeRecipe(drink);
            else UnavailableDrink(drink);
        }

        private void UnavailableDrink(string drink) => _outputProvider($"Sorry bro, but we do not do {drink}");
    }
}