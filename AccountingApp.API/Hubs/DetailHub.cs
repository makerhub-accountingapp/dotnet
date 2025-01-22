using AccountingApp.BLL.Interfaces;
using AccountingApp.BLL.Services;
using AccountingApp.DB.Entities;
using Microsoft.AspNetCore.SignalR;

namespace AccountingApp.API.Hubs
{
	public class DetailHub(IDetailService service) : Hub
	{		
		public async Task NotifyGet()
		{
			await Clients.Caller.SendAsync("ReceiveGet", "Details retrieved");
		}

		public async Task NotifyCreate()
		{
			await Clients.All.SendAsync("ReceiveCreate", "Detail created");
		}

		public async Task NotifyUpdate()
		{
			await Clients.All.SendAsync("ReceiveUpdate", "Detail updated");
		}

		public async Task NotifyDelete()
		{
			await Clients.All.SendAsync("ReceiveDelete", "Detail deleted");
		}
	}
}
