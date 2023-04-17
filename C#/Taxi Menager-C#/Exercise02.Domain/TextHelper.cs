namespace Exercise02.Domain
{
    public static class TextHelper
    {
        public static void WriteInColor(string messange, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(messange);
            Console.ResetColor();
        }
    }
}
