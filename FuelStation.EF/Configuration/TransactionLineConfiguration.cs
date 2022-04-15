using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FuelStation.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FuelStation.EF.Configuration
{
    public class TransactionLineConfiguration : IEntityTypeConfiguration<TransactionLine>
    {
        public void Configure(EntityTypeBuilder<TransactionLine> builder)
        {
            builder.ToTable("TransactionLines");
            builder.HasKey(transactionLine => transactionLine.ID);
            builder.Property(transactionLine => transactionLine.TotalValue).HasColumnType("decimal(10,3)");
            builder.Property(transactionLine => transactionLine.DiscountPercent).HasColumnType("decimal(10,3)");
            builder.Property(transactionLine => transactionLine.DiscountValue).HasColumnType("decimal(10,3)");
            builder.Property(transactionLine => transactionLine.ItemPrice).HasColumnType("decimal(10,3)");
            builder.Property(transactionLine => transactionLine.NetValue).HasColumnType("decimal(10,3)");
            //builder.Property(transactionLine => transactionLine.Quantity).HasColumnType("int(5)");

            builder.HasOne(transactionLine => transactionLine.Transaction)
                   .WithMany(transaction => transaction.TransactionLines)
                   .HasForeignKey(transactionLine => transactionLine.TransactionID).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(transactionLine => transactionLine.Item)
                   .WithMany(item => item.TransactionLines)
                   .HasForeignKey(transactionLine => transactionLine.ItemID).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
