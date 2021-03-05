namespace DebuggerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            const string message = @"C:\Users";
            PathVisualizer.DebuggerSide.TestShowVisualizer(message);
        }
    }
}
