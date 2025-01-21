using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountingApp.BLL.Forms;
using AccountingApp.DB.Entities;

namespace AccountingApp.BLL.Mappers
{
    internal static class DetailMapper
    {
        public static Detail ToEntity(this DetailForm detail)
        {
            return new Detail
            {
                Amount = detail.Amount,
                TransactionDate = detail.TransactionDate,
                Note = detail.Note,
                TransactionId = detail.TransactionId,
                CategoryId = detail.CategoryId,
                TransactionTypeId = detail.TransactionTypeId,
            };
        }

        public static Detail ToEntity(this DetailUpdateForm detail)
        {
            return new Detail
            {
                Id = detail.Id,
                Amount = detail.Amount,
                TransactionDate = detail.TransactionDate,
                Note = detail.Note,
                TransactionId = detail.TransactionId,
                CategoryId = detail.CategoryId,
                TransactionTypeId = detail.TransactionTypeId,
            };
        }
    }
}
