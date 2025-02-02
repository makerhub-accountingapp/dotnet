using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountingApp.DAL.Interfaces;
using AccountingApp.DB.Contexts;
using AccountingApp.DB.Entities;
using OnlineRestaurant.TL.Templates;

namespace AccountingApp.DAL.Repositories
{
    public class TransactionRepository(MainContext context) : Repository<Transaction>(context), ITransactionRepository
    {
    }
}
