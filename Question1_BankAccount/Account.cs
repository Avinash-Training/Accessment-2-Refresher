// ============================================================
// ASSESSMENT 2 - REFRESHER
// Question 1: Bank Account Class
// Status: ✅ DONE
// Note: TopBrains was not working, solution implemented manually
// ============================================================

/*
 * QUESTION:
 * Create a C# class called `Account` that represents a simple bank account.
 * The class should:
 *   1. Have private fields: `name` (string) and `balance` (double).
 *   2. Have a constructor that accepts a name and an initial balance.
 *   3. Include a method `deposit(double amount)` that adds the amount to the
 *      balance and returns the updated balance.
 *   4. Include a getter method `getBalance()` that returns the current balance.
 *   5. Include getter and setter methods for the `name` field.
 *
 * In the `Main` method, perform the following operations:
 *   - Create account1 for "John Doe" with balance 1000. Deposit 250 and print balance.
 *   - Print the name of account1.
 *   - Create account2 for "Riya" with balance 500. Print her balance.
 *   - Deposit 0.5 into account1 and print the returned balance.
 *   - Print the final balance of account1.
 *   - Change account2's name to "Riya Amit Mehta" and print it.
 *
 * Expected Output:
 *   1250
 *   John Doe
 *   500
 *   1250.5
 *   1250.5
 *   Riya Amit Mehta
 */

// ============================================================
// SOLUTION
// ============================================================

using System;

public class Account
{
    // Private fields - cannot be accessed directly from outside the class
    private string name;
    private double balance;

    // Constructor: initializes the account with a name and starting balance
    public Account(string name, double initialBalance)
    {
        this.name = name;
        this.balance = initialBalance;
    }

    // Adds the given amount to the balance and returns the updated balance
    public double deposit(double amount)
    {
        balance += amount;
        return balance;
    }

    // Returns the current balance (getter for balance)
    public double getBalance()
    {
        return balance;
    }

    // Sets a new name for the account holder (setter for name)
    public void setName(string newName)
    {
        name = newName;
    }

    // Returns the current name of the account holder (getter for name)
    public string getName()
    {
        return name;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        // Create account1 for "John Doe" with initial balance of 1000
        Account account1 = new Account("John Doe", 1000);

        // Deposit 250 into account1 and print the returned balance → 1250
        Console.WriteLine(account1.deposit(250));

        // Print the name of account1 → John Doe
        Console.WriteLine(account1.getName());

        // Create account2 for "Riya" with initial balance of 500
        Account account2 = new Account("Riya", 500);

        // Print the balance of account2 → 500
        Console.WriteLine(account2.getBalance());

        // Deposit 0.5 into account1 and print the returned balance → 1250.5
        Console.WriteLine(account1.deposit(0.5));

        // Print the final balance of account1 → 1250.5
        Console.WriteLine(account1.getBalance());

        // Update account2's name to full name
        account2.setName("Riya Amit Mehta");

        // Print the updated name → Riya Amit Mehta
        Console.WriteLine(account2.getName());
    }
}
