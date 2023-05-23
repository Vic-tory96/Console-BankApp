using BankApp.Models.Enums;
using BankApp.Models;
using BankingApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp.Service.Interfaces;

namespace BankApp.Service
{
    public class AccountService : IAccountService
    {
        private readonly Db db;

        public AccountService(Db db)
        {
            this.db = db;
        }

        public void MakeDeposit(Account account, BankTransaction entity)
        {
            if (account == null) throw new ArgumentNullException("Account data cannot be null.");
            if (entity == null) throw new ArgumentNullException("Transaction data cannot be null.");

            account.Balance += entity.Amount;
            db.Transactions.Add(entity);
        }


        public void MakeWithdrawal(Account account, BankTransaction entity, AccountType accType)
        {
            if (account == null) throw new ArgumentNullException("Account data cannot be null.");
            if (entity == null) throw new ArgumentNullException("Transaction data cannot be null.");

            // open close principle
            if (accType == AccountType.SAVINGS)
            {
                if (account.Balance > 100)
                {
                    account.Balance -= entity.Amount;
                    db.Transactions.Add(entity);
                }
                throw new ArgumentOutOfRangeException("Insufficient funds.");
            }
            else
            {
                if (account.Balance > 1000)
                {
                    account.Balance -= entity.Amount;
                    db.Transactions.Add(entity);
                }
                throw new ArgumentOutOfRangeException("Insufficient funds.");
            }
        }


        public void MakeTransfer(Account account, BankTransaction entity, AccountType accType)
        {
            this.MakeWithdrawal(account, entity, accType);
            this.MakeDeposit(account, entity);
        }

        public void AddNew(User entity, AccountType AccType)
        {
            if (entity == null) throw new Exception("User data cannot be null.");
            var rand = new Random();
            var accNum = rand.Next(0, 1000000000).ToString("D10");
            var account = new Account
            {
                AccountNumber = accNum,
                AccountName = $"{entity.FirstName} {entity.LastName}",
                AccountType = AccType,
                Balance = 0,
                UserId = entity.Id
            };

            db.Accounts.Add(account);
            db.Users.Add(entity);
        }

        public List<Account> GetAll()
        {
            return db.Accounts.ToList();
        }

        public Account GetById(string Id)
        {
            var account = db.Accounts.FirstOrDefault(a => a.Id == Id);
            if (account != null)
            {
                var user = db.Users.FirstOrDefault(u => u.Id == account.UserId);
                var transactions = db.Transactions.ToList();
                if (user != null)
                    account.User = user;

                if (transactions != null)
                    account.Transactions = transactions;

                return account;
            }
            return new Account();
        }

        public int RowCount()
        {
            return db.Accounts.Count();
        }

        // Todo: Update Method

        // Todo: Delete Method
    }
}
