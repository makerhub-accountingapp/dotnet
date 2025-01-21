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
    public class TransactionTypeConfiguration : IEntityTypeConfiguration<TransactionType>
    {
        public void Configure(EntityTypeBuilder<TransactionType> builder)
        {
            /********** Tables **********/

            builder.ToTable("TransactionType");

            /********** Properties **********/

            builder.Property(tt => tt.Name).IsRequired();

            /********** Keys **********/

            builder.HasMany(tt => tt.Details)
                .WithOne(d => d.TransactionType)
                .HasForeignKey(d => d.TransactionTypeId);
        }
    }
}
