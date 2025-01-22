using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountingApp.BLL.Forms;
using AccountingApp.BLL.Interfaces;
using AccountingApp.DAL.Interfaces;
using AccountingApp.DB.Entities;
using AccountingApp.TL.Exceptions;
using OnlineRestaurant.TL.Templates;

namespace AccountingApp.BLL.Services
{
	public class DetailService(IDetailRepository repo) : Service<Detail, DetailCreateForm, DetailUpdateForm>(repo, detail => detail.Id), IDetailService
	{
		public override Detail? Create(DetailCreateForm form, Func<Detail, bool>? predicate)
		{
			predicate = (d) => d.TransactionId == form.TransactionId &&
				d.TransactionDate == form.TransactionDate;

			return base.Create(form, predicate);
		}

		public IEnumerable<Detail> Get(DetailGetForm form)
		{
			Func<Detail, bool> predicate = (d) => 
				(form.Name is null || d.Transaction.Name == form.Name) &&
				(form.CategoryId is null || d.CategoryId == form.CategoryId) &&
				(form.TransactionTypeId is null || d.TransactionTypeId == form.TransactionTypeId) &&
				(form.Repetition is null || d.Transaction.Repetition == form.Repetition) &&
				(form.StartDate is null || form.EndDate is null) ||
				(d.TransactionDate >= form.StartDate && d.TransactionDate <= form.EndDate);

			return base.Get(predicate);
		}		
	}
}
