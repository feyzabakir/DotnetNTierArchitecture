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
    public class UserProfileSeed : IEntityTypeConfiguration<UserProfile>
    {
        public void Configure(EntityTypeBuilder<UserProfile> builder)
        {
            builder.HasData(
               new UserProfile { Id = 1, FirstName = "Ayşe", LastName = "Yıldız", NickName = "ayse", UserId = 1 },
               new UserProfile { Id = 2, FirstName = "Ali", LastName = "Yılmaz", NickName = "ali", UserId = 2 },
               new UserProfile { Id = 3, FirstName = "Elif", LastName = "Demir", NickName = "elif", UserId = 3 },
               new UserProfile { Id = 4, FirstName = "Ahmet", LastName = "Kaya", NickName = "ahmet", UserId = 4 }
               );
        }
    }
}
