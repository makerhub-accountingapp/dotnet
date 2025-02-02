using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountingApp.BLL.Forms;
using AccountingApp.BLL.Interfaces;
using AccountingApp.DAL.Interfaces;
using AccountingApp.DB.Entities;
using OnlineRestaurant.TL.Templates;

namespace AccountingApp.BLL.Services
{
    public class TransactionTypeService(ITransactionTypeRepository repo) : Service<TransactionType, TransactionTypeCreateForm,  TransactionTypeUpdateForm>(repo), ITransactionTypeService
    {
    }
}
