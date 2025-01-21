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
	public class DetailService(IDetailRepository repo) : Service<Detail>(repo, detail => detail.Id), IDetailService
	{
		public Detail? Create(DetailForm detail)
		{
			// Checks if the detail already exists
			if (repo.Any(d =>
				d.TransactionId == detail.TransactionId &&
				d.TransactionDate == detail.TransactionDate))
			{
				throw new AlreadyExistException("Transaction detail already registered.");
			}

			return repo.Create(detail.ToEntity());
		}

		public void Delete(int id)
		{
			// Checks if the detail exists
			Detail? detailToDelete = repo.GetOne(d => d.Id == id);

			if (detailToDelete is null)
			{
				throw new NotFoundException("Transaction detail not found.");

			}

			repo.Delete(detailToDelete);
		}

		public IEnumerable<Detail> Get(DetailGetForm detail)
		{
			IEnumerable<Detail> foundDetails = repo.Get(d =>
				(detail.Name is null || d.Transaction.Name == detail.Name) &&
				(detail.CategoryId is null || d.CategoryId == detail.CategoryId) &&
				(detail.TransactionTypeId is null || d.TransactionTypeId == detail.TransactionTypeId) &&
				(detail.Repetition is null || d.Transaction.Repetition == detail.Repetition) &&
				(detail.StartDate is null || detail.EndDate is null ||
				(d.TransactionDate >= detail.StartDate && d.TransactionDate <= detail.EndDate))
			);

			return foundDetails;
		}

		public Detail? Update(DetailUpdateForm detail)
		{
			// Checks if the detail exists
			Detail? foundDetail = repo.GetOne(d => d.Id == detail.Id);

			if (foundDetail is null)
			{
				throw new NotFoundException("Transaction detail not found");
			}

			return Update(detail.ToEntity());
		}
	}
}
