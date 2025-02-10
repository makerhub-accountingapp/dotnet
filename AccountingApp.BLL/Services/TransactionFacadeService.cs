using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountingApp.BLL.Forms;
using AccountingApp.BLL.Interfaces;
using AccountingApp.DB.Entities;
using AccountingApp.DB.Enums;
using AccountingApp.TL.Exceptions;

namespace AccountingApp.BLL.Services
{
	public class TransactionFacadeService(ITransactionService tService, ITransactionTypeService ttService, ICategoryService cService, IDetailService dService, IAccountService aService, IUserService uService) : ITransactionFacadeService
	{
		public Detail? Create(TransactionFacadeCreateForm form)
		{
			RepetitionEnum repetition = (RepetitionEnum)form.Repetition;

			DetailCreateForm dForm = new DetailCreateForm
			{
				Amount = form.Amount,
				TransactionDate = form.TransactionDate,
				Note = form.Note,
				CategoryId = form.CategoryId,
				TransactionTypeId = form.TransactionTypeId,
			};
			
			Func<Transaction, bool> predicate = t => t.AccountId == form.AccountId && t.Name == form.Name && t.Repetition != RepetitionEnum.None && t.Repetition == repetition;

			Transaction? foundTransaction = tService.GetOne(predicate);

			if (foundTransaction is not null)
			{
				dForm.TransactionId = foundTransaction.Id;
			}
			else
			{
				TransactionCreateForm tForm = new TransactionCreateForm
				{
					Name = form.Name,
					AccountId = form.AccountId,
					Repetition = repetition,
					SetDate = form.TransactionDate,
					EndDate = form.EndDate is not null? form.EndDate : null
				};

				Transaction? createdTransaction = tService.Create(tForm);

				if (createdTransaction is null) throw new OperationFailedException("Transaction creation failed");
				else dForm.TransactionId = createdTransaction.Id;
			}

			return dService.Create(dForm);
		}
	}
}
