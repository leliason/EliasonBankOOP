using System;
using ClassLibrary;

Console.WriteLine("Console Testing App for Eliason Bank Library");

// Base Account Test

Account testAcct = new Account();
testAcct.IsActive = true; // manually set active for testing
Console.WriteLine("Base Account Created");
Console.WriteLine($"Account Number: {testAcct.AccountNumber}");
Console.WriteLine($"Owner Name: {testAcct.OwnerName}");
Console.WriteLine($"Balance: {testAcct.Balance:C}");
Console.WriteLine($"Is Active: {testAcct.IsActive}");
Console.WriteLine($"Date Opened: {testAcct.DateOpened}");

// Base Account Deposit Test
testAcct.Deposit(500);
Console.WriteLine($"After depositing $500, Balance: {testAcct.Balance:C}");

// Base Account Withdrawl Test
bool withdrawSuccess = testAcct.Withdraw(200);
Console.WriteLine($"Attempt to withdraw $200: {(withdrawSuccess ? "success" : "failed")}, New Balance: {testAcct.Balance:C}");


