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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {

        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(user => user.ID);
            builder.Property(user => user.Name).HasMaxLength(50);
            builder.Property(user => user.Surname).HasMaxLength(50);
            builder.Property(user => user.Username).HasMaxLength(50);
            builder.Property(user => user.PasswordHash).HasMaxLength(50);
        }
    }
}
