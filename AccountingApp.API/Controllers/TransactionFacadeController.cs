using AccountingApp.BLL.Forms;
using AccountingApp.BLL.Interfaces;
using AccountingApp.DB.Entities;
using AccountingApp.TL.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineRestaurant.TL.Templates;

namespace AccountingApp.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TransactionFacadeController(ITransactionFacadeService service) : ControllerBase
	{
		[HttpPost]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public IActionResult Create([FromBody] TransactionFacadeCreateForm form)
		{
			try
			{
				Detail? createdEntity = service.Create(form);

				if (createdEntity is null) throw new OperationFailedException("Creation failed.");

				return Created($"api/detail/{createdEntity.Id}", createdEntity);
			}
			catch (OperationFailedException ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}
