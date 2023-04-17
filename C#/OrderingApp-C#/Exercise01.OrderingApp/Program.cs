using Exercise01.Domain;
using Exercise01.Domain.Models;

// Ordering App ( AliExpress / eBay )

// Main Menu
// 1. Choose a User

// Orders Menu
// When the user logs, it should have options to:
// - Check Orders
// - Create New Order

// Bonus:
// - On the main menu showcase how many times the all users checked their order
// ex. Fun fact: People checked their order status 5 times !

// * Create Static Database
// * Create Static Text Helper
// * Create Static Property in Non-Static Class
// * Create customer getter and setter on atleast one property


User currentUser = null;

while (true)
{
    #region Main Manu

    Console.Clear();
    Console.WriteLine("Main Manu");

    if(TextHelper.OrderChecked > 0)
    {
        TextHelper.WriteLineInColor($"[Fun Fact]: People checked their order status {TextHelper.OrderChecked} {(TextHelper.OrderChecked == 1 ? "time" : "times")}!", ConsoleColor.DarkCyan);
    }
    

    StaticDatabase.ListUsers();
    Console.Write("Choose User: ");

    int choice = TextHelper.ValidateNumber(Console.ReadLine());

    if (choice == -1)
        continue;

    if(choice > StaticDatabase.Users.Count)
    {
        TextHelper.WriteLineInColor("User does not exist", ConsoleColor.Red);
        Console.ReadKey();
        continue;
    }

    currentUser = StaticDatabase.Users[choice - 1];
    #endregion

    #region Orders Menu
    while(currentUser != null)
    {
        Console.Clear();
        Console.WriteLine($"Welcome {currentUser.Username}");
        Console.WriteLine();
        Console.WriteLine("Orders Menu");
        Console.WriteLine("1) Check Orders");
        Console.WriteLine("2) Create New Order");
        Console.WriteLine("3) Exit");
        Console.Write("> ");

        int menuChoice = TextHelper.ValidateNumber(Console.ReadLine());

        if(menuChoice == -1)
            continue;

        switch (menuChoice)
        {
            case 1:
                Console.Clear();
                currentUser.PrintOrders();
                Console.Write("Choose one to check the status: ");

                int orderCoice = TextHelper.ValidateNumber(Console.ReadLine());

                if(orderCoice == -1)
                    continue;

                if(orderCoice > currentUser.Orders.Count)
                {
                    TextHelper.WriteLineInColor("Order not found!", ConsoleColor.Red);
                    Console.ReadKey();
                    continue;
                }

                TextHelper.GenerateStatusMessage(currentUser.Orders[orderCoice - 1].Status);

                Console.ReadKey();
                break;
            case 2:
                Console.Clear();

                Console.WriteLine("=== Adding Order ===");
                Order newOrder = new Order();

                Console.Write("Name: ");
                newOrder.Title = Console.ReadLine();

                Console.Write("Description: ");
                newOrder.Description = Console.ReadLine();

                StaticDatabase.InsertOrder(currentUser, newOrder);
                Console.ReadKey();
                break;
            case 3:
                currentUser = null;

                Console.WriteLine("Press any key to return to the main manu");
                break;
            default:
                TextHelper.WriteLineInColor("Invalid Input", ConsoleColor.Red);
                Console.ReadKey();
                continue;
        }
    }
    #endregion
}
