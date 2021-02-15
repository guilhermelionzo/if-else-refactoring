using System;

namespace bar
{
    public static class Program
    {
        static void Main(string[] args)
        {
            var recipeBook = new RecipeBook(new ConsoleWriter());
            var bartender = new Bartender(new ConsoleWriter(), recipeBook);

            while (true) bartender.AskForDrink();
        }
    }
}
