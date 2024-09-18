namespace AccountingSystem;

public class Premium : Checking
{
    public Premium(int accountId, decimal balance) : base(accountId, balance)
    {

    }

    public override void ApplyInterestRate()
    {
        Console.WriteLine("\nApply Interest to Premium Account");
        Console.WriteLine("---------------------------------------------");
        Console.Write("Premium: ");
        this.PrintAccountInfo();
        Console.WriteLine("\nThe interest rate for Premium accounts is currently 4%.");
        Balance = (.04m * Balance) + Balance;
        Console.WriteLine("The interest rate has been applied and the balance has been updated...\n");
        Console.Write("Premium [updated]: ");
        this.PrintAccountInfo();
        Console.WriteLine();
    }
}
