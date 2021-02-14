using System;

//sonar token: 571fd96ddc93d6599add010ac0624e96a221c167

namespace bar
{
    public static class Program
    {
        static void Main(string[] args)
        {
            var recipeBook = new RecipeBook(Console.ReadLine, Console.WriteLine);
            var bartender = new Bartender(Console.ReadLine, Console.WriteLine, recipeBook);

            while (true)
                bartender.AskForDrink();
        }
    }
}
