using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingApp.BLL.Forms
{
	public class TransactionFacadeCreateForm
	{
		[Required]
		public string Name { get; set; } = string.Empty;
		[Required]
		public decimal Amount { get; set; }
		[Required]
		public int Repetition { get; set; }
		[Required]
		public DateTime TransactionDate { get; set; }
		public DateTime? EndDate { get; set; }

		[Required]
		public int TransactionTypeId { get; set; }
		[Required]
		public int CategoryId { get; set; }

		public string Note { get; set; } = string.Empty;
		[Required]
		public int AccountId { get; set; }
		[Required]
		public int UserId { get; set; }
	}
}
