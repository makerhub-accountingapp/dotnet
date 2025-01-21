using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountingApp.DB.Enums;

namespace AccountingApp.DB.Entities
{
    public class Transaction
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int AccountId { get; set; }
        public Account Account { get; set; } = null!;
        public RepetitionEnum Repetition { get; set; }
        public DateTime SetDate { get; set; }
        public DateTime? EndDate { get; set; }
        public List<Detail> Details { get; set; } = new List<Detail>();
    }
}
