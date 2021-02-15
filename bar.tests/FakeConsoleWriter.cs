using bar.interfaces;

namespace bar.tests
{
    public class FakeConsoleWriter : IConsoleWriter
    {
        private string _outputBuffer = "";
        private string _inputBuffer = "";
        /// <summary>
        /// Used to test
        /// </summary>
        /// <param name="buffer"></param>
        public void SetInputBuffer(string buffer) => _inputBuffer = buffer;
        public string GetOutputBuffer() => _outputBuffer;

        /// <summary>
        /// interface implementation
        /// </summary>
        /// <returns></returns>
        public string ReadLine() => _inputBuffer;
        public void WriteLine(string value) { _outputBuffer = value; }
    }
}