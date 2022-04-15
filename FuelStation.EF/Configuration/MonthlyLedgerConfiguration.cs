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
    public class MonthlyLedgerConfiguration : IEntityTypeConfiguration<MonthlyLedger>
    {
        public void Configure(EntityTypeBuilder<MonthlyLedger> builder)
        {
            builder.ToTable("MonthlyLedgers");
            builder.HasKey(monthlyLedger => monthlyLedger.ID);
            builder.Property(monthlyLedger => monthlyLedger.Year).HasMaxLength(4);
            builder.Property(monthlyLedger => monthlyLedger.Month).HasMaxLength(15);
            builder.Property(monthlyLedger => monthlyLedger.Expenses).HasColumnType("decimal(10,3)"); ;
            builder.Property(monthlyLedger => monthlyLedger.Income).HasColumnType("decimal(10,3)"); ;
            builder.Property(monthlyLedger => monthlyLedger.Total).HasColumnType("decimal(10,3)"); ;
            builder.Property(monthlyLedger => monthlyLedger.RentCost).HasColumnType("decimal(10,3)"); ;
        }
    }
}
