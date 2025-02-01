using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountingApp.DB.Entities;
using AccountingApp.DB.Enums;
using AccountingApp.TL.Templates;

namespace AccountingApp.BLL.Forms
{
    public class TransactionCreateForm : IConvertibleToEntity<Transaction, TransactionCreateForm>
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public int AccountId { get; set; }

        [Required]
        public RepetitionEnum Repetition { get; set; }

        [Required]
        public DateTime SetDate { get; set; }

        public DateTime? EndDate { get; set; }

        public Transaction ToEntity(TransactionCreateForm form)
        {
            return new Transaction
            {
                Name = form.Name,
                AccountId = form.AccountId,
                Repetition = form.Repetition,
                SetDate = form.SetDate,
                EndDate = form.EndDate,
            };
        }
    }

    public class TransactionUpdateForm : IConvertibleToEntity<Transaction, TransactionUpdateForm>, IIdentifiable
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public int AccountId { get; set; }

        [Required]
        public RepetitionEnum Repetition { get; set; }

        [Required]
        public DateTime SetDate { get; set; }

        public DateTime? EndDate { get; set; }

        public Transaction ToEntity(TransactionUpdateForm form)
        {
            return new Transaction
            {
                Id = form.Id,
                Name = form.Name,
                AccountId = form.AccountId,
                Repetition = form.Repetition,
                SetDate = form.SetDate,
                EndDate = form.EndDate,
            };
        }
    }
}
