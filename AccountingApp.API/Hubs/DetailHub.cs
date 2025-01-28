using AccountingApp.API.Templates;
using AccountingApp.BLL.Interfaces;
using AccountingApp.BLL.Services;
using AccountingApp.DB.Entities;
using Microsoft.AspNetCore.SignalR;

namespace AccountingApp.API.Hubs
{
	public class DetailHub : BaseHub<Detail>
	{
	}
}
