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
    public class EmployeeCongifuration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employees");
            builder.HasKey(employee => employee.ID);
            builder.Property(employee => employee.Name).HasMaxLength(50);
            builder.Property(employee => employee.Surname).HasMaxLength(50);
            builder.Property(employee => employee.Sallary).HasPrecision(10, 3);

            builder.Property(employee => employee.EmployeeType)
                   .HasConversion(employeeType => employeeType.ToString(), 
                                  employeeType => (EmployeeType)Enum.Parse(typeof(EmployeeType), employeeType))
                   .HasMaxLength(15);
        }
    }
}
