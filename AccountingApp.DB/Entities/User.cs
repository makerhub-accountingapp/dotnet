using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountingApp.TL.Templates;

namespace AccountingApp.DB.Entities
{
    public class User : IIdentifiable
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        public List<Account> Accounts { get; set; } = new List<Account>();
    }
}
