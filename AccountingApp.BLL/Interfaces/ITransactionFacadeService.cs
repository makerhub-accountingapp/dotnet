using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountingApp.BLL.Forms;
using AccountingApp.DB.Entities;

namespace AccountingApp.BLL.Interfaces
{
	public interface ITransactionFacadeService
	{
		/// <summary>
		/// Adds a new entity and related entities to the database.
		/// </summary>
		/// <param name="form">Entity and related entities to add.</param>
		/// <returns>The added entity, or null.</returns>
		Detail? Create(TransactionFacadeCreateForm form);
	}
}
