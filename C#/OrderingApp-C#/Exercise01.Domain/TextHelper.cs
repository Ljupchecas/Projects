using Exercise01.Domain.Enums;

namespace Exercise01.Domain
{
    public static class TextHelper
    {
        public static int OrderChecked { get; set; }
        public static void WriteLineInColor(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public static int ValidateNumber(string input)
        {
            bool isValid = int.TryParse(input, out int choice);
            if (!isValid)
            {
                WriteLineInColor("Invalid Input...", ConsoleColor.Red);
                return -1;
            }

            return choice;
        }

        public static void GenerateStatusMessage(OrderStatus orderStatus)
        {
            string message = string.Empty;
            ConsoleColor color = ConsoleColor.White;

            switch (orderStatus)
            {
                case OrderStatus.Processing:
                    color = ConsoleColor.Blue;
                    message = "[Processing] The order is being processed.";
                    break;
                case OrderStatus.Deliverd:
                    color = ConsoleColor.Green;
                    message = "[Deliverd] The order is successfully delivery";
                    break;
                case OrderStatus.DeliveryInProgress:
                    color = ConsoleColor.Yellow;
                    message = "[In Progress] The delivery is in progress...";
                    break;
                case OrderStatus.CouldNotDeliver:
                    color = ConsoleColor.Red;
                    message = "[Not Deliverd] There was a problem with the delivery";
                    break;
                default:
                    break;
            }

            WriteLineInColor(message, color);
            OrderChecked++;
        }

        public static string CapitalizeFirstLetter(string word)
        {
            if(string.IsNullOrEmpty(word))
                return word;

            if(word.Length == 1)
                return char.ToUpper(word[0]).ToString();

            return char.ToUpper(word[0]) + word.Substring(1);
        }
    }
}
