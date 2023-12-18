using DotnetNTierArchitecture.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetNTierArchitecture.Repository.Seeds
{
    public class UserSeed : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
               new User { Id = 1, Email = "ayseyildiz@gmail.com", Password = "123456", UserName = "ayseyildiz", TeamId = 1, CreatedDate = DateTime.Now },
               new User { Id = 2, Email = "aliyilmaz@gmail.com", Password = "112233", UserName = "aliyilmaz", TeamId = 2, CreatedDate = DateTime.Now },
               new User { Id = 3, Email = "elifdemir@gmail.com", Password = "123123", UserName = "elifdemir", TeamId = 3, CreatedDate = DateTime.Now },
               new User { Id = 4, Email = "ahmetkaya@gmail.com", Password = "456789", UserName = "ahmetkaya", TeamId = 4, CreatedDate = DateTime.Now }
               );
        }
    }
}
