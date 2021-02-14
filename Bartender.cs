using System;
using System.Linq;

namespace bar
{
    public class Bartender
    {
        private readonly Func<string> _inputProvider;
        private readonly Action<string> _outputProvider;
        private readonly RecipeBook _recipeBook;
        private void UnavailableDrink(string drink) => _outputProvider($"Sorry bro, but we do not do {drink}");

        public Bartender(Func<string> inputProvider, Action<string> outputProvider, RecipeBook recipeBook = null)
        {
            _inputProvider = inputProvider;
            _outputProvider = outputProvider;
            _recipeBook = recipeBook;
        }

        public void AskForDrink()
        {
            _outputProvider($"What drink do you want? ({string.Join(", ", _recipeBook.GetAvailableDrinkNames())})");

            var drink = _inputProvider() ?? string.Empty;

            if (!_recipeBook.GetAvailableDrinkNames().Contains(drink)) UnavailableDrink(drink);

            _recipeBook.MakeRecipe(drink);
        }
    }
}