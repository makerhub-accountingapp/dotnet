using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using AccountingApp.DB.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountingApp.DAL.Contexts
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            /********** Tables **********/

            // CaseSensitive « \"\" »
            builder.ToTable("User");

            /********** Properties **********/

            builder.Property(u => u.Email).IsRequired();
            builder.Property(u => u.Password).IsRequired();
            builder.Property(u => u.IsActive).HasDefaultValue(true);

            /********** Keys **********/
            
            builder.HasMany(u => u.Accounts)
                .WithOne(a => a.User)
                .HasForeignKey(a => a.UserId);


            /********** NOTE **********/
            // If the primary key name is Id, the methods below are not necessary.
            // builder.Property(u => u.Id).ValueGeneratedOnAdd();

            // builder.HasKey(u => u.Id);

            // builder.HasMany(u => u.Accounts)
            //    .WithOne(a => a.User)
            //    .HasForeignKey(a => a.UserId)
            //    .HasPrincipalKey(u => u.Id);
        }
    }
}
