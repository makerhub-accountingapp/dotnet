using AccountingApp.API.Hubs;
using AccountingApp.BLL.Forms;
using AccountingApp.BLL.Interfaces;
using AccountingApp.DB.Entities;
using AccountingApp.DB.Enums;
using AccountingApp.TL.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace AccountingApp.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DetailController(IHubContext<DetailHub> hub, IDetailService service) : ControllerBase
	{
		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Detail>))]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> Get(string? name, int? categoryId, int? transactionTypeId, RepetitionEnum? repetition, DateTime? startDate, DateTime? endDate)
		{
			DetailGetForm predicate = new DetailGetForm()
			{
				Name = name,
				CategoryId = categoryId,
				TransactionTypeId = transactionTypeId,
				Repetition = repetition,
				StartDate = startDate,
				EndDate = endDate
			};

			try
			{
				IEnumerable<Detail> foundDetails = service.Get(predicate);
				await hub.Clients.All.SendAsync("ReceiveGet", foundDetails);

				return Ok(foundDetails);
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
