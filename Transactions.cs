public static class Transactions
{
    public static void Transfer(string transferDirection, Checking checking, Premium premium )
    {
        string? transferAmountInput;
        decimal transferAmount = 0;
        bool inputValid = false;
        if (transferDirection == "1")
        {
            Console.WriteLine("\nTransfer Funds from Checking to Premium");
        }
        else
        {
            Console.WriteLine("\nTransfer Funds from Premium to Checking");
        }
        Console.WriteLine("---------------------------------------------");
        Console.Write("Checking: ");
        checking.PrintAccountInfo();
        Console.Write("\nPremium: ");
        premium.PrintAccountInfo();
        do
        {
            Console.WriteLine("\nHow much do you want to transfer? [Enter c to cancel]");
            transferAmountInput = Console.ReadLine();
            if ((transferAmountInput == null) || (!decimal.TryParse(transferAmountInput, out transferAmount)) || (transferAmount <= 0))
            {
                if (transferAmountInput!.Trim().ToLower() == "c")
                {
                    Console.WriteLine();
                    return;
                }
                Console.WriteLine("Invalid input. Please enter a number greater than 0.");
            }
            else if ((transferDirection == "1") && (transferAmount > checking.Balance))
            {
                Console.WriteLine($"You don't have enough funds in your Checking account to cover that transfer. The transfer amount must be equal to or less than your Checking account balance of ${checking.Balance.ToString("F2")}");
            }
            else if ((transferDirection == "2") && (transferAmount > premium.Balance))
            {
                Console.WriteLine($"You don't have enough funds in your Premium account to cover that transfer. The transfer amount must be equal to or less than your Premium account balance of ${premium.Balance.ToString("F2")}");
            }
            else
            {
                inputValid = true;
            }
        } while (inputValid == false);

        if (transferDirection == "1")
        {
            premium.Balance = premium.Balance + transferAmount;
            checking.Balance = checking.Balance - transferAmount;
            Console.WriteLine($"\nYou have transferred ${transferAmount.ToString("F2")} from your Checking account to your Premium account.\n");
            Console.Write("Checking [updated]: ");
            checking.PrintAccountInfo();
            Console.Write("\nPremium [updated]: ");
            premium.PrintAccountInfo();
        }
        else
        {
            checking.Balance = checking.Balance + transferAmount;
            premium.Balance = premium.Balance - transferAmount;
            Console.WriteLine($"\nYou have transferred ${transferAmount.ToString("F2")} from your Premium account to your Checking account.\n");
            Console.Write("Checking [updated]: ");
            checking.PrintAccountInfo();
            Console.Write("\nPremium [updated]: ");
            premium.PrintAccountInfo();
        }
    }
}
