using AccountingApp.BLL.Interfaces;
using AccountingApp.BLL.Services;
using AccountingApp.DB.Entities;
using Microsoft.AspNetCore.SignalR;

namespace AccountingApp.API.Hubs
{
	public class DetailHub(IDetailService service) : Hub
	{
		private IEnumerable<Detail> Details => service.Get();

		public async Task Refresh()
		{
			await Clients.All.SendAsync("GetDetails", Details);
		}

		public async Task Get()
		{
			await Clients.Caller.SendAsync("GetDetails", Details);
		}
	}
}
