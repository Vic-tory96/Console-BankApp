using BankApp.Models;
using BankApp.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Service.Interfaces
{
    public interface IAccountService
    {
        public void MakeDeposit(Account account, BankTransaction entity);
        public void MakeWithdrawal(Account account, BankTransaction entity, AccountType accType);
        public void MakeTransfer(Account account, BankTransaction entity, AccountType accType);
        public void AddNew(User entity, AccountType AccType);
        public List<Account> GetAll();
        public int RowCount();
        public Account GetById(string Id);
    }
}
