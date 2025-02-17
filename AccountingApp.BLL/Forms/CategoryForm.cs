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
    public class CategoryCreateForm : IConvertibleToEntity<Category, CategoryCreateForm>
    {
        [Required]
        public string Name { get; set; } = string.Empty;
		[Required]
		public int UserId { get; set; }

        public Category ToEntity(CategoryCreateForm form)
        {
            return new Category
            {
                Name = form.Name,
                UserId = form.UserId
            };
        }
    }

    public class CategoryUpdateForm : IConvertibleToEntity<Category, CategoryUpdateForm>, IIdentifiable
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
		[Required]
        public int UserId { get; set; }

		public Category ToEntity(CategoryUpdateForm form)
        {
            return new Category
            {
                Id = form.Id,
                Name = form.Name,
                UserId = form.UserId
            };
        }
    }
}
