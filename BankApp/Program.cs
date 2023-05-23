// See https://aka.ms/new-console-template for more information
using BankApp.Models;
using BankApp.Models.Enums;
using BankApp.Service;

Console.WriteLine("Hello, World!");


GlobalConfig.Initialize();

try
{

    var user = new User
    {
        FirstName = "Test",
        LastName = "Test",
        Email = "test@test.com",
        Password = "Test-001",
    };
    GlobalConfig.AccountService.AddNew(user, AccountType.SAVINGS);

    User user2 = null;
    //    new User
    //{
    //    FirstName = "Test",
    //    LastName = "Test",
    //    Email = "test@test.com",
    //    Password = "Test-001",
    //};
    GlobalConfig.AccountService.AddNew(user2, AccountType.SAVINGS);

    Console.WriteLine($"Accounts created is: {GlobalConfig.AccountService.RowCount()}");
}catch(Exception e)
{
    Console.WriteLine(e.Message);
}