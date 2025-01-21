using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingApp.DB.Entities
{
    public class Account
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Balance { get; set; } = 0;
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public List<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
