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
    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
           //Fluent API yapılandırması
         
           builder.HasKey(x => x.Id); //Primary Key (PK)

            builder.Property(t=>t.Id)  //Pk 1-1 arttırma işlemi
                .UseIdentityColumn();

            builder.Property(t => t.TeamName) //TeamName max uzunluğu zorunlu hale getirme
                .HasMaxLength(50)
                .IsRequired();

            //Tablo ismini belirleme
           // builder.ToTable("Teams");
        }
    }
}
