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
        public static int ValidateNumber(string input)
        {
            bool isValid = int.TryParse(input, out int choice);
            if (!isValid)
            {
                WriteInColor("Invalid Input...", ConsoleColor.Red);
                return -1;
            }

            return choice;
        }





    }
}
