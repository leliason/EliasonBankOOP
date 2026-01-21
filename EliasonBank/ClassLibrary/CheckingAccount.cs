using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Text;
using static ClassLibrary.Account;

namespace ClassLibrary
{
    public class CheckingAccount : Account
    {
        public decimal OverdraftLimit { get; private set; }

        public CheckingAccount(int accountNumber, string ownerName, decimal overdraftLimit)
           : base(accountNumber, ownerName, AccountType.Checking)
        {
            OverdraftLimit = overdraftLimit;
        }

        public override bool Withdraw(decimal amount)
        {
            if (amount <= 0m) return false;

            // Allow overdraft up to the limit
            if (Balance + OverdraftLimit < amount) return false;

            Balance -= amount;
            return true;
        }
    }

}
