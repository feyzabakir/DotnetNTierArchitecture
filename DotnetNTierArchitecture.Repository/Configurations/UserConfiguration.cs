using DotnetNTierArchitecture.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetNTierArchitecture.Repository.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
          builder.HasKey(x => x.Id); //PK

          builder.Property(x=>x.Id) //1-1 artma
                .UseIdentityColumn();

        builder.Property(x=>x.UserName).IsRequired().HasMaxLength(50);
        builder.Property(x=>x.Email).IsRequired().HasMaxLength(250);
        builder.Property(x=>x.Password).IsRequired().HasMaxLength(250);
           
        }
    }
}
