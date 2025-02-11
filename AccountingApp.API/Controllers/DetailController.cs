using AccountingApp.API.Hubs;
using AccountingApp.API.Interfaces;
using AccountingApp.API.Templates;
using AccountingApp.BLL.Forms;
using AccountingApp.BLL.Interfaces;
using AccountingApp.BLL.Services;
using AccountingApp.DB.Entities;
using AccountingApp.DB.Enums;
using AccountingApp.TL.Exceptions;
using AccountingApp.TL.Templates;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using OnlineRestaurant.TL.Templates;

namespace AccountingApp.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DetailController
        (IDetailService service, IHubContext<DetailHub> hub)
        : GenericHubController<Detail, DetailCreateForm, DetailUpdateForm, DetailHub>(service, hub), IDetailController
	{
		[HttpPost("detailtransaction")]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> Create([FromBody] DetailTransactionCreateForm form)
		{
			try
			{
				Detail? createdEntity = service.Create(form);

				if (createdEntity is null) throw new OperationFailedException("Creation failed.");

				await hub.Clients.All.SendAsync("ReceiveCreateDetail", createdEntity);

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

		[HttpGet("filtered")]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Detail>))]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> Get(string? name, int? categoryId, int? transactionId, int? transactionTypeId, RepetitionEnum? repetition, DateTime? startDate, DateTime? endDate)
		{
			DetailGetForm form = new DetailGetForm()
			{
				Name = name,
				CategoryId = categoryId,
				TransactionId = transactionId,
				TransactionTypeId = transactionTypeId,
				Repetition = repetition,
				StartDate = startDate,
				EndDate = endDate
			};

			try
			{
				IEnumerable<Detail> foundDetails = service.Get(form);
				await hub.Clients.All.SendAsync("ReceiveGetDetail", foundDetails);

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
