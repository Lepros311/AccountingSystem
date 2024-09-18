namespace AccountingSystem;

public class Checking
{
    public int AccountId { get; set; }
    public decimal Balance { get; set; }

    public Checking(int accountId, decimal balance)
    {
        AccountId = accountId;

        Balance = balance;
    }

    public void GetStartingAmount()
    {
        Console.WriteLine($"\n{this}: ");
        Console.WriteLine($"Please enter your current {this} account balance:");
        string? startingAmountInput;
        decimal startingAmount = 0;
        bool inputValid = false;
        do
        {
            startingAmountInput = Console.ReadLine();
            if ((startingAmountInput == null) || (!decimal.TryParse(startingAmountInput, out startingAmount)))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
            else
            {
                Balance = Balance + startingAmount;
                inputValid = true;
            }
        } while (inputValid == false);
    }

    public void PrintAccountInfo()
    {
        Console.WriteLine($"\nAccount ID: {AccountId}");
        Console.WriteLine($"Balance: ${Balance.ToString("F2")}");
    }

    public virtual void ApplyInterestRate()
    {
        Console.WriteLine("\nApply Interest to Checking Account");
        Console.WriteLine("---------------------------------------------");
        Console.Write("Checking: ");
        this.PrintAccountInfo();
        Console.WriteLine("\nThe interest rate for Checking accounts is currently 3%.");
        Balance = (.03m * Balance) + Balance;
        Console.WriteLine("The interest rate has been applied and the balance has been updated...\n");
        Console.Write("Checking [updated]: ");
        this.PrintAccountInfo();
    }

    public void AdjustBalance()
    {
        Console.WriteLine("---------------------------------------------");
        Console.WriteLine("Entering a positive number will increase the balance. Entering a negative number will decrease the balance.");
        string? adjustmentAmountInput;
        decimal adjustmentAmount = 0;
        bool inputValid = false;
        do
        {
            Console.WriteLine("Please enter the adjustment amount (Enter c to cancel):");
            adjustmentAmountInput = Console.ReadLine();
            if ((adjustmentAmountInput == null) || (!decimal.TryParse(adjustmentAmountInput, out adjustmentAmount)) || (adjustmentAmountInput == "0"))
            {
                if (adjustmentAmountInput!.Trim().ToLower() == "c")
                {
                    return;
                }
                Console.WriteLine("Invalid input. The amount cannot be 0.");
            }
            else
            {
                Balance = Balance + adjustmentAmount;
                if (adjustmentAmount > 0)
                {
                    Console.WriteLine($"You have added ${adjustmentAmount} to your {this} account.\n");
                    Console.Write($"{this} [updated]: ");
                    this.PrintAccountInfo();
                }
                else
                {
                    Console.WriteLine($"You have subtracted ${adjustmentAmount} from your {this} account.\n");
                    Console.Write($"{this} [updated]: ");
                    this.PrintAccountInfo();
                }
                inputValid = true;
            }
        } while (inputValid == false);
    }
}
