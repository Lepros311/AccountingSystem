using AccountingSystem;

Checking checking = new Checking(123456789, 0);
Premium premium = new Premium(987654321, 0);

string? userMenuChoice;
bool exit = false;

void PrintMenu()
{
    Console.WriteLine("MAIN MENU:");
    Console.WriteLine("1) View Account Balances");
    Console.WriteLine("2) Adjust Checking Account Balance");
    Console.WriteLine("3) Adjust Premium Account Balance");
    Console.WriteLine("4) Apply Interest");
    Console.WriteLine("5) Transfer Funds from Checking to Premium");
    Console.WriteLine("6) Transfer Funds from Premium to Checking");
    Console.WriteLine("7) Exit program");
}

void GetUserMenuSelection()
{
    string[] menuOptions = { "1", "2", "3", "4", "5", "6", "7" };
    do
    {
        Console.WriteLine("What would you like to do? Enter 1, 2, 3, 4, 5, 6, or 7:");
        userMenuChoice = Console.ReadLine();
        if (!menuOptions.Contains(userMenuChoice))
        {
            Console.WriteLine("That is not a valid option. You must enter 0, 1, 2, 3, 4, 5, 6, or 7.");
        }
    } while (!menuOptions.Contains(userMenuChoice));
}

void MenuSelectionControl(string userMenuChoice)
{
    switch (userMenuChoice)
    {
        case "1":
            Console.Clear();
            Console.WriteLine("\nAccount Balances");
            Console.WriteLine("---------------------------------------------");
            Console.Write("Checking: ");
            checking.PrintAccountInfo();
            Console.Write("\nPremium: "); 
            premium.PrintAccountInfo();
            Console.WriteLine("---------------------------------------------");
            Console.Write("\nPress any key for the Main Menu...");
            Console.ReadLine();
            Console.WriteLine();
            break;
        case "2":
            Console.Clear();
            Console.Write("\nChecking: ");
            checking.PrintAccountInfo();
            Console.WriteLine("\nAdjust Checking Account Balance");
            checking.AdjustBalance();
            Console.Write("\nPress any key for the Main Menu...");
            Console.ReadLine();
            Console.WriteLine();
            break;
        case "3":
            Console.Clear();
            Console.Write("\nPremium: ");
            premium.PrintAccountInfo();
            Console.WriteLine("\nAdjust Premium Account Balance");
            premium.AdjustBalance();
            Console.Write("\nPress any key for the Main Menu...");
            Console.ReadLine();
            Console.WriteLine();
            break;
        case "4":
            Console.Clear();
            checking.ApplyInterestRate();
            premium.ApplyInterestRate();
            Console.Write("\nPress any key for the Main Menu...");
            Console.ReadLine();
            Console.WriteLine();
            break;
        case "5":
            Console.Clear();
            Transactions.Transfer("1", checking, premium);
            Console.Write("\nPress any key for the Main Menu...");
            Console.ReadLine();
            Console.WriteLine();
            break;
        case "6":
            Console.Clear();
            Transactions.Transfer("2", checking, premium);
            Console.Write("\nPress any key for the Main Menu...");
            Console.ReadLine();
            Console.WriteLine();
            break;
        case "7":
            Console.WriteLine("\nThanks for using Accounting System 1.0");
            Console.WriteLine("Goodbye!");
            exit = true;
            Environment.Exit(0);
            break;
    }
}

Console.WriteLine("Welcome to the Accounting System 1.0");
Console.WriteLine("---------------------------------------------");
checking.GetStartingAmount();
premium.GetStartingAmount();
Console.WriteLine();

do
{
    PrintMenu();
    GetUserMenuSelection();
    MenuSelectionControl(userMenuChoice!);
} while (exit == false);