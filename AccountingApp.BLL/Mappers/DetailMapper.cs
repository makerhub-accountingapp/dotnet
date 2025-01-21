using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountingApp.DB.Entities;
using AccountingApp.BLL.Forms;

namespace AccountingApp.BLL.Mappers
{
	public partial class DetailForm
	{
		public Detail ToEntity(DetailForm form)
		{
			return new Detail
			{
				Amount = form.Amount,
				TransactionDate = form.TransactionDate,
				Note = form.Note,
				TransactionId = form.TransactionId,
				CategoryId = form.CategoryId,
				TransactionTypeId = form.TransactionTypeId,
			};
		}
	}
}
