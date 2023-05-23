using BankApp.Service.Interfaces;
using BankingApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Service
{
    public static class GlobalConfig
    {
        public static Db Db { get; private set; }
        public static IAccountService AccountService { get; private set; }
        public static void Initialize()
        {
            Db = new Db();
            AccountService = new AccountService(Db);
        }
    }
}
