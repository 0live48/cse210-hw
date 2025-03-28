using System;

namespace BankAccountExample
{
    // BankAccount class demonstrating Encapsulation
    public class BankAccount
    {
        // Private fields (hidden implementation)
        private string _accountNumber;
        private double _balance;

        // Public constructor
        public BankAccount(string accountNumber, double initialBalance)
        {
            _accountNumber = accountNumber;
            _balance = initialBalance;
        }

        // Public methods to interact with the account
        public void Deposit(double amount)
        {
            if (amount > 0)
            {
                _balance += amount;
                Console.WriteLine($"Deposited: {amount:C}");
            }
            else
            {
                Console.WriteLine("Deposit amount must be positive.");
            }
        }

        public void Withdraw(double amount)
        {
            if (amount > 0 && amount <= _balance)
            {
                _balance -= amount;
                Console.WriteLine($"Withdrawn: {amount:C}");
            }
            else
            {
                Console.WriteLine("Invalid withdrawal amount or insufficient funds.");
            }
        }

        // Public method to display balance (read-only access)
        public void DisplayBalance()
        {
            Console.WriteLine($"Account: {_accountNumber}");
            Console.WriteLine($"Current Balance: {_balance:C}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create a bank account
            BankAccount account = new BankAccount("123456789", 1000.00);

            // Perform transactions
            account.DisplayBalance();
            account.Deposit(500.50);
            account.Withdraw(200.75);
            account.Withdraw(2000.00); // Should fail
            account.DisplayBalance();
        }
    }
}
