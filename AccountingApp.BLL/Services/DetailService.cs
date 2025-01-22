using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountingApp.BLL.Forms;
using AccountingApp.BLL.Interfaces;
using AccountingApp.BLL.Mappers;
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

		public override IEnumerable<Detail> Get(Func<Detail, bool>? predicate)
		{
			predicate = (d) => 
				(detail.Name is null || d.Transaction.Name == detail.Name) &&
				(detail.CategoryId is null || d.CategoryId == detail.CategoryId) &&
				(detail.TransactionTypeId is null || d.TransactionTypeId == detail.TransactionTypeId) &&
				(detail.Repetition is null || d.Transaction.Repetition == detail.Repetition) &&
				(detail.StartDate is null || detail.EndDate is null) ||
				(d.TransactionDate >= detail.StartDate && d.TransactionDate <= detail.EndDate);

			return base.Get(predicate);
		}		
	}
}
