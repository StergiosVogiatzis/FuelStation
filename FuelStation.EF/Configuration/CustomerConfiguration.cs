using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FuelStation.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace FuelStation.EF.Configuration
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");
            builder.HasKey(customer => customer.ID);
            builder.Property(customer => customer.Name).HasMaxLength(50);
            builder.Property(customer => customer.Surname).HasMaxLength(50);
            builder.Property(customer => customer.CardNumber).HasMaxLength(16).IsRequired();
            builder.HasIndex(customer => customer.CardNumber).IsUnique();

            builder.HasMany(customer => customer.Transactions)
                   .WithOne(transaction => transaction.Customer)
                   .HasForeignKey(transaction => transaction.CustomerID);
        }
    }
}
