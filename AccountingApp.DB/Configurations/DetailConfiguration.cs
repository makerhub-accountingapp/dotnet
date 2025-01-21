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
    public class DetailConfiguration : IEntityTypeConfiguration<Detail>
    {
        public void Configure(EntityTypeBuilder<Detail> builder)
        {
            /********** Tables **********/

            builder.ToTable("Detail");

            /********** Properties **********/

            builder.Property(d => d.Amount).IsRequired();
            builder.Property(d => d.TransactionDate).IsRequired();
            builder.Property(d => d.TransactionId).IsRequired();
            builder.Property(d => d.Note).HasDefaultValue("");
            builder.Property(d => d.TransactionDate).HasColumnType("timestamp");
        }
    }
}
