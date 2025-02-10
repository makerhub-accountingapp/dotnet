using AccountingApp.API.Interfaces;
using AccountingApp.API.Templates;
using AccountingApp.BLL.Forms;
using AccountingApp.BLL.Interfaces;
using AccountingApp.DB.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AccountingApp.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AccountController(IAccountService service) : GenericController<Account, AccountCreateForm, AccountUpdateForm>(service), IAccountController
	{
	}
}
