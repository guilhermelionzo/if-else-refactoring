using bar.interfaces;

namespace bar.tests
{
    public class FakeConsoleWriter : IConsoleWriter
    {
        public string ReadLine() => "beer";
        public void WriteLine(string format) { }
    }
}