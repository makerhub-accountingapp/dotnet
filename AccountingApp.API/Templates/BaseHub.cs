using Microsoft.AspNetCore.SignalR;

namespace AccountingApp.API.Templates
{
	public class BaseHub<TEntity> : Hub, IBaseHub<TEntity>
		where TEntity : class
	{
		public async Task NotifyCreate(TEntity entity)
		{
			await Clients.Caller.SendAsync($"ReceiveCreate{typeof(TEntity).Name}", entity);
		}

		public async Task NotifyDelete(TEntity entity)
		{
			await Clients.All.SendAsync($"ReceiveDelete{typeof(TEntity).Name}", entity);
		}

		public async Task NotifyGet(TEntity[] entities)
		{
			await Clients.All.SendAsync($"ReceiveGet{typeof(TEntity).Name}", entities);
		}

		public async Task NotifyGetById(TEntity entity)
		{
			await Clients.All.SendAsync($"ReceiveGet{typeof(TEntity).Name}ById", entity);
		}

		/********** Note **********/

		// Better to separate hub and controller even if it is possible only to use controller
		// Controllelr => request-response model
		// Hub => real-time communication
		// Logics concerning real-time communication should be written in hub
		// Keep the code clean and sustainable
	}
}
