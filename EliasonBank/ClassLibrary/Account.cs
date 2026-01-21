using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Account
    {
        // attributes
        public int AccountNumber { get; private set; }
        public string OwnerName { get; private set; }
        public decimal Balance { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateOpened { get; private set; }
        // enumerator
        // for account types
        public enum AccountType
        {
            Savings,
            Checking,
            Business
        }
        public AccountType TypeOfAccount { get; private set; }
        private List<string> TransactionHistory;
        
        public Account()
        {
            AccountNumber = 0;
            OwnerName = "Unknown";
            IsActive = false;
            DateOpened = DateTime.Now;
            TransactionHistory = new List<string>();
        }
        public Account(int  accountNumber, string ownerName, AccountType accountType)
        {
            AccountNumber = accountNumber;
            OwnerName = ownerName;
            Balance = 0;
            IsActive = true;
            DateOpened = DateTime.Now;
            TypeOfAccount = accountType;
            TransactionHistory = new List<string>();
        }
        // methods
        public virtual void Deposit(decimal amount)
        
        {
            if (!IsActive || amount <= 0)
            {
                throw new ArgumentException("Error - Deposit amount must be positive or account inactive");
            }
            Balance = amount;
            TransactionHistory.Add($"Deposited: {amount:C} on {DateTime.Now}");
        }
        public virtual bool Withdraw(decimal amount)
        {
            if (!IsActive || amount <= 0 || amount > Balance)
            {
                throw new ArgumentException("Error - Withdraw amount must be positive, less than balance, or account inactive");
            }
            Balance -= amount;
            TransactionHistory.Add($"Withdraw: {amount:C} on {DateTime.Now}");
            return true;
        }
        public decimal GetBalance()
        {
            return Balance;
        }
        public List<string> GetTransactionHistory()
        {
            return TransactionHistory;
        }
        public override string ToString()
        {
            return $"Account Number: {AccountNumber}, Owner: {OwnerName}, Balance: {Balance:C}, Active: {IsActive}, Opened On: {DateOpened}, Type: {TypeOfAccount}";
        }

        public void CloseAccount()
        {
            IsActive = false;
        }
        public void CloseAccount(string reason)
        {
            TransactionHistory.Add($"Account closed on {DateTime.Now} Reason: {reason}");
        }
        
    }
}