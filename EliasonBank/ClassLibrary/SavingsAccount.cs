using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Text;
using static ClassLibrary.Account;

namespace ClassLibrary
{
    public class SavingsAccount : Account
    {
        public decimal InterestRate { get; private set; }
        public int WithdrawalLimit { get; private set; } = 3;
        private int _withdrawalsThisMonth;

        public SavingsAccount(int accountNumber, string ownerName, decimal interestRate)
                  : base(accountNumber, ownerName, AccountType.Savings) // KEY FIX: pass type
        {
            InterestRate = interestRate;
        }


        public void ApplyMonthlyInterest()
        {
            if (InterestRate <= 0) return;

            Balance += Balance * InterestRate;
        }


        public void ResetMonthlyWithdrawals()
        {
            _withdrawalsThisMonth = 0;
        }

        public override bool Withdraw(decimal amount) // KEY FIX: base method is now virtual
        {
            if (_withdrawalsThisMonth >= WithdrawalLimit) return false;

            bool success = base.Withdraw(amount);
            if (success) _withdrawalsThisMonth++;

            return success;
        }
    }

}
