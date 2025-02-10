using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountingApp.BLL.Forms;
using AccountingApp.BLL.Interfaces;
using AccountingApp.DAL.Interfaces;
using AccountingApp.DB.Entities;
using AccountingApp.DB.Enums;
using AccountingApp.TL.Exceptions;
using OnlineRestaurant.TL.Templates;

namespace AccountingApp.BLL.Services
{
	public class DetailService
		(IDetailRepository repo, ITransactionService tService) 
		: Service<Detail, DetailCreateForm, DetailUpdateForm>(repo), IDetailService
	{
		public override Detail? Create(DetailCreateForm form)
		{
			Func<Detail, bool> predicate = (d) => 
				d.TransactionId == form.TransactionId &&
				d.TransactionDate == form.TransactionDate;

			return base.Create(form, predicate);
		}

		public Detail? Create(DetailTransactionCreateForm form)
		{
			// Converts int to Enum
			RepetitionEnum repetition = (RepetitionEnum)form.Repetition;

			// Extracts the form data to a new DetailCreateForm object
			DetailCreateForm dForm = new DetailCreateForm
			{
				Amount = form.Amount,
				TransactionDate = form.TransactionDate,
				Note = form.Note,
				CategoryId = form.CategoryId,
				TransactionTypeId = form.TransactionTypeId,
			};

			// Checks if the transaction already exists
			Func<Transaction, bool> predicate = t => t.AccountId == form.AccountId && t.Name == form.Name && t.Repetition != RepetitionEnum.None && t.Repetition == repetition;

			Transaction? foundTransaction = tService.GetOne(predicate);

			if (foundTransaction is not null)
			{
				dForm.TransactionId = foundTransaction.Id;
			}
			else
			{
				// Creates a new transaction if it doesn't exist yet
				TransactionCreateForm tForm = new TransactionCreateForm
				{
					Name = form.Name,
					AccountId = form.AccountId,
					Repetition = repetition,
					SetDate = form.TransactionDate,
					EndDate = form.EndDate is not null ? form.EndDate : null
				};

				Transaction? createdTransaction = tService.Create(tForm);

				if (createdTransaction is null) throw new OperationFailedException("Transaction creation failed");
				else dForm.TransactionId = createdTransaction.Id;
			}

			return Create(dForm);
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
