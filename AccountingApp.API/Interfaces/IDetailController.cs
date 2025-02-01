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
        /// Asynchronously retrieves all entities from the database.
        /// </summary>
        /// <param name="name">Transaction name</param>
        /// <param name="categoryId">Category id</param>
        /// <param name="transactionTypeId">Transaction type id</param>
        /// <param name="repetition">Repetition enum</param>
        /// <param name="startDate">Starting date of the transaction</param>
        /// <param name="endDate">Ending date of the transaction</param>
        /// <returns>A task representing the asynchronous operation. The task result contains a collection of all entities.</returns>
        Task<IActionResult> Get(string? name, int? categoryId, int? transactionTypeId, RepetitionEnum? repetition, DateTime? startDate, DateTime? endDate);
    }
}
