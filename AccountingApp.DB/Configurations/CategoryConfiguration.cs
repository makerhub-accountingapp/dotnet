using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountingApp.DB.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountingApp.DB.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            /********** Tables **********/

            builder.ToTable("Category");

            /********** Properties **********/

            builder.Property(c => c.Name).IsRequired();

            /********** Keys **********/

            builder.HasMany(c => c.Details)
                .WithOne(d => d.Category)
                .HasForeignKey(d => d.CategoryId);
        }
    }
}
