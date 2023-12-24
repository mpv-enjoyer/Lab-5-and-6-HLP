using System.ComponentModel;
using static IBankAccount;

BankProgram program = new();
while (true)
{
    int result;
    if (int.TryParse(Console.ReadLine(), out result))
    {
        program.Add(result);
    }
}

interface IBankAccount
{
    void Deposit(decimal amount);
    void Withdraw(decimal amount);
    decimal GetBalance();
}

class BankAccount : IBankAccount
{
    decimal Balance;
    public delegate void BalanceChangedEventHandler(decimal newBalance);
    public delegate void OverdraftEventHandler(decimal overdraftAmount);
    public event BalanceChangedEventHandler? BalanceChanged;
    public event OverdraftEventHandler? Overdraft;
    public void Deposit(decimal amount)
    {
        Balance += amount;
        BalanceChanged?.Invoke(Balance);
    }
    public void Withdraw(decimal amount)
    {
        Balance -= amount;
        if (Balance < 0)
        {
            Overdraft?.Invoke(-Balance);
            Balance += amount;
        }
        else BalanceChanged?.Invoke(Balance);
    }
    public decimal GetBalance()
    {
        return Balance;
    }
}

class BankProgram
{
    BankAccount account = new();
    public BankProgram() 
    {
        account.BalanceChanged += PrintChanged;
        account.Overdraft += PrintOverdraft;
    }
    public void Add(int value)
    {
        if (value >= 0) account.Deposit(value);
        else account.Withdraw(-value); 
    }
    void PrintChanged(decimal amount)
    {
        Console.WriteLine($"Your bank account has {amount}$ now.");
    }
    void PrintOverdraft(decimal amount)
    {
        Console.WriteLine($"Overdraft by {amount}$. No changed have been made.");
    }
}