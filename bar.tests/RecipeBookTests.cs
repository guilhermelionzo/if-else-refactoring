using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace bar.tests
{
    [TestClass]
    public class RecipeBookTests
    {
        [TestMethod]
        public void ShouldReturnTrue_When()
        {
            RecipeBook recipeBook = new RecipeBook(Console.ReadLine, Console.WriteLine);

            Debug.Assert(recipeBook != null);
        }
    }
}
