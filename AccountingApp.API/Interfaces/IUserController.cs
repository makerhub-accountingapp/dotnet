using AccountingApp.DB.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AccountingApp.API.Interfaces
{
	public interface IUserController
	{
        /// <summary>
        /// Retrieves entity that match the given condition.
        /// </summary>
        /// <param name="email">Email to filter entities.</param>
        /// <param name="password">Password to filter entities.</param>
        /// <returns>A matching entity or null.</returns>
        IActionResult Login(string email, string password);
    }
}
