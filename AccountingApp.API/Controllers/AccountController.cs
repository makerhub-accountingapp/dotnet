using AccountingApp.API.Interfaces;
using AccountingApp.API.Templates;
using AccountingApp.BLL.Forms;
using AccountingApp.BLL.Interfaces;
using AccountingApp.DB.Entities;
using AccountingApp.TL.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AccountingApp.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AccountController(IAccountService service) : GenericController<Account, AccountCreateForm, AccountUpdateForm>(service), IAccountController
	{

		[HttpGet("userId/{userId}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public IActionResult Get(int userId)
		{
			try
			{
				IEnumerable<Account> foundEntities = service.Get(userId);

				return Ok(foundEntities);
			}
			catch (NotFoundException ex)
			{
				return BadRequest(ex.Message);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
		}
	}
}
