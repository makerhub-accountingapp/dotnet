using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingApp.DB.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int TransactionDetailId { get; set; }
        public List<Detail> Details { get; set; } = new List<Detail>();
    }
}
