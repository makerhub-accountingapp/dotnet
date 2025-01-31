using AccountingApp.BLL.Forms;
using AccountingApp.DB.Entities;
using AccountingApp.DB.Enums;
using AccountingApp.TL.Exceptions;
using AccountingApp.TL.Templates;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using OnlineRestaurant.TL.Templates;

namespace AccountingApp.API.Templates
{
	[Route("api/[controller]")]
	[ApiController]
	public class GenericHubController<TEntity, TService, TCreateForm, TUpdateForm, THub>

        /********** Dependecy injections **********/

        (IService<TEntity, TCreateForm, TUpdateForm> service, 
		IHubContext<THub> hub)

        /********** Inheritance **********/

        : ControllerBase, 
		IGenericHubController
			<TEntity, TCreateForm, TUpdateForm, THub>

        /********** Generic characteristics **********/

        where TEntity : class, IIdentifiable
		where TService : class, IService<TEntity, TCreateForm, TUpdateForm>
		where TCreateForm : class, IConvertibleToEntity<TEntity, TCreateForm>
		where TUpdateForm : class, IConvertibleToEntity<TEntity, TUpdateForm>, IIdentifiable
		where THub : Hub
	{
		[HttpPost]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> Create([FromBody] TCreateForm form)
		{
			try
			{
				TEntity? createdEntity = service.Create(form);

				if (createdEntity is null) throw new OperationFailedException("Creation failed.");
				await hub.Clients.All.SendAsync($"ReceiveCreate{typeof(TEntity).Name}", createdEntity);

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

		[HttpDelete("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult?> Delete([FromRoute] int id)
		{
			try
			{
				TEntity? deletedEntity = service.Delete(id);

				if (deletedEntity is null)
				{
					throw new OperationFailedException("Delete failed.");
				}

				await hub.Clients.All.SendAsync($"ReceiveDelete{typeof(TEntity).Name}", deletedEntity);

				return Ok(deletedEntity);
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

		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> Get()
		{
			try
			{
				IEnumerable<TEntity> foundEntities = service.Get();

				await hub.Clients.All.SendAsync($"ReceiveGet{typeof(TEntity).Name}", foundEntities);

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
		
		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> GetById([FromRoute] int id)
		{
			try
			{
				TEntity? foundEntity = service.GetById(id);

				if (foundEntity is null) throw new NotFoundException($"{typeof(TEntity).Name} not found.");

				await hub.Clients.All.SendAsync($"ReceiveGetById{typeof(TEntity).Name}", foundEntity);

				return Ok(foundEntity);
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
		
		[HttpPut]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> Update([FromBody] TUpdateForm form)
		{
			try
			{
				TEntity? updatedEntity = service.Update(form);

				if (updatedEntity is null) throw new OperationFailedException("Update failed.");

				await hub.Clients.All.SendAsync($"ReceiveUpdate{typeof(TEntity).Name}", updatedEntity);

				return Ok(updatedEntity);
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
