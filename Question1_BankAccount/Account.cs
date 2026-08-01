// Question 1: Bank Account Class
// Create a class called Account with private fields name and balance.
// Add a constructor that takes name and initial balance.
// Add a deposit method that adds amount to balance and returns updated balance.
// Add getBalance, getName and setName methods.
// Create two accounts, perform deposits and name update, print results.

using System;

public class Account
{
    private string name;
    private double balance;

    public Account(string name, double initialBalance)
    {
        this.name = name;
        this.balance = initialBalance;
    }

    public double deposit(double amount)
    {
        balance += amount;
        return balance;
    }

    public double getBalance()
    {
        return balance;
    }

    public void setName(string newName)
    {
        name = newName;
    }

    public string getName()
    {
        return name;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Account account1 = new Account("John Doe", 1000);
        Console.WriteLine(account1.deposit(250));
        Console.WriteLine(account1.getName());

        Account account2 = new Account("Riya", 500);
        Console.WriteLine(account2.getBalance());
        Console.WriteLine(account1.deposit(0.5));
        Console.WriteLine(account1.getBalance());

        account2.setName("Riya Amit Mehta");
        Console.WriteLine(account2.getName());
    }
}
