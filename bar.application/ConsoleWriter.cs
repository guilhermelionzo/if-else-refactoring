using System;
using bar.interfaces;

namespace bar
{
    public class ConsoleWriter : IConsoleWriter
    {
        public string ReadLine() => Console.ReadLine();

        public void WriteLine(string value) => Console.WriteLine(value);
    }
}
