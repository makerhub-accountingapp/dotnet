using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingApp.DB.Entities
{
    public class Detail
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Note { get; set; } = string.Empty;
        public int TransactionId { get; set; }
        public Transaction Transaction { get; set; } = null!;
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;
        public int TransactionTypeId { get; set; } 
        public TransactionType TransactionType { get; set; } = null!;
    }
}
