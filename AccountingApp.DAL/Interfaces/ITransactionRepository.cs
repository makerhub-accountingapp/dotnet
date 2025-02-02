using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountingApp.DB.Entities;
using OnlineRestaurant.TL.Templates;

namespace AccountingApp.DAL.Interfaces
{
    public interface ITransactionRepository : IRepository<Transaction>
    {
    }
}
