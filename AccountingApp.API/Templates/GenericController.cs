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
	public class GenericController<TEntity, TService, TCreateForm, TUpdateForm>

		/********** Dependecy injections **********/

		(IService<TEntity, TCreateForm, TUpdateForm> service)

        /********** Inheritance **********/

        : ControllerBase, 
		IGenericController<TEntity, TCreateForm, TUpdateForm>

        /********** Generic characteristics **********/

        where TEntity : class, IIdentifiable
		where TService : class, IService<TEntity, TCreateForm, TUpdateForm>
		where TCreateForm : class, IConvertibleToEntity<TEntity, TCreateForm>
		where TUpdateForm : class, IConvertibleToEntity<TEntity, TUpdateForm>, IIdentifiable
	{
		[HttpPost]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public IActionResult Create([FromBody] TCreateForm form)
		{
			try
			{
				TEntity? createdEntity = service.Create(form);

				if (createdEntity is null) throw new OperationFailedException("Creation failed.");

				return Created($"api/detail/{ createdEntity.Id }", createdEntity);
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
		public IActionResult Delete([FromRoute] int id)
		{
			try
			{
				TEntity? deletedEntity = service.Delete(id);

				if (deletedEntity is null)
				{
					throw new OperationFailedException("Delete failed.");
				}

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
		public IActionResult Get()
		{
			try
			{
				IEnumerable<TEntity> foundEntities = service.Get();

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
		public IActionResult GetById([FromRoute] int id)
		{
			try
			{
				TEntity? foundEntity = service.GetById(id);

				if (foundEntity is null) throw new NotFoundException($"{ typeof(TEntity).Name } not found.");

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
		public IActionResult Update([FromBody] TUpdateForm form)
		{
			try
			{
				TEntity? updatedEntity = service.Update(form);

				if (updatedEntity is null) throw new OperationFailedException("Update failed.");

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
