using BankApp.Models.Enums;

namespace BankApp.Models
{
    public class BankTransaction: BaseEntity
    {
        public TransactionType TransactionType { get; set; }
        public string SenderId { get; set; }
        public string RecieverId { get; set; }

        public TransactionStatus TransactionStatus { get; set; }

        public string AccountId { get; set; }
        public Account Account { get; set; } // navigation property

        public decimal Amount { get; set; }
         
        public string Description { get; set; }
    }
}