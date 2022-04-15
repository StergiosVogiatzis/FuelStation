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
    public class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.ToTable("Items");
            builder.HasKey(item => item.ID);
            builder.Property(item => item.Code).HasMaxLength(50);
            builder.HasIndex(item => item.Code).IsUnique();
            builder.Property(item => item.Description).HasMaxLength(50);
            builder.Property(item => item.Price).HasColumnType("decimal(10,3)");
            builder.Property(item => item.Cost).HasColumnType("decimal(10,3)");

            builder.Property(item => item.ItemType)
                   .HasConversion(itemType => itemType.ToString(),
                                  itemType => (ItemType)Enum.Parse(typeof(ItemType), itemType))
                   .HasMaxLength(15);

            builder.HasMany(item => item.TransactionLines)
                   .WithOne(transactionLine => transactionLine.Item)
                   .HasForeignKey(transactionLine => transactionLine.ItemID);
        }
    }
}
