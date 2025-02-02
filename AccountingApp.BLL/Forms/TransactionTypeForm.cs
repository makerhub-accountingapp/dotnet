using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountingApp.DB.Entities;
using AccountingApp.TL.Templates;

namespace AccountingApp.BLL.Forms
{
    public class TransactionTypeCreateForm : IConvertibleToEntity<TransactionType, TransactionTypeCreateForm>
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        public TransactionType ToEntity(TransactionTypeCreateForm form)
        {
            return new TransactionType
            {
                Name = form.Name,
            };
        }
    }

    public class TransactionTypeUpdateForm : IConvertibleToEntity<TransactionType, TransactionTypeUpdateForm>, IIdentifiable
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public TransactionType ToEntity(TransactionTypeUpdateForm form)
        {
            return new TransactionType
            {
                Id = form.Id,
                Name = form.Name,
            };
        }
    }
}
