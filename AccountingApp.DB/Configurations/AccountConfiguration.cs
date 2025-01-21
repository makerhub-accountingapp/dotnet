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
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            /********** Tables **********/
            
            builder.ToTable("Account");

            /********** Properties **********/

            builder.Property(a => a.Name).IsRequired();
            builder.Property(a => a.UserId).IsRequired();
            builder.Property(a => a.Balance).HasDefaultValue(0);
            builder.Property(a => a.Balance)
                .HasPrecision(10, 2);

            /********** Keys **********/

            builder.HasMany(a => a.Transactions)
                .WithOne(t => t.Account)
                .HasForeignKey(t => t.AccountId);
        }
    }
}
