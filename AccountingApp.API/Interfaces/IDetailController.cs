using AccountingApp.API.Templates;
using AccountingApp.BLL.Forms;
using AccountingApp.DB.Entities;
using AccountingApp.DB.Enums;
using Microsoft.AspNetCore.Mvc;

namespace AccountingApp.API.Interfaces
{
    public interface IDetailController
    {
		/// <summary>
		/// Adds a new entity and related entities to the database.
		/// </summary>
		/// <param name="form">Entity and related entities to add.</param>
		/// <returns>The added entity, or null.</returns>
		Task<IActionResult> Create(DetailTransactionCreateForm form);

		/// <summary>
		/// Asynchronously retrieves all entities from the database.
		/// </summary>
		/// <param name="name">Transaction name</param>
		/// <param name="categoryId">Category id</param>
		/// <param name="transactionId">Transaction id</param>
		/// <param name="transactionTypeId">Transaction type id</param>
		/// <param name="repetition">Repetition enum</param>
		/// <param name="accountId">Account id</param>
		/// <param name="startDate">Starting date of the transaction</param>
		/// <param name="endDate">Ending date of the transaction</param>
		/// <returns>A task representing the asynchronous operation. The task result contains a collection of all entities.</returns>
		Task<IActionResult> Get(string? name, int? categoryId, int? transactionId, int? transactionTypeId, RepetitionEnum? repetition, int? accountId, DateTime? startDate, DateTime? endDate);
    }
}
