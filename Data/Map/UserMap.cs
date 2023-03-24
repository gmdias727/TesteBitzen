using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;
using TesteBitzen.Models;

namespace TesteBitzen.Data.Map
{
    public class UserMap : IEntityTypeConfiguration<UserModel>
    {
        public void Configure(EntityTypeBuilder<UserModel> builder)
        {
            builder.HasKey(x => x.UserId);
            builder.Property(x => x.UserName).IsRequired().HasMaxLength(255);
            builder.Property(x => x.UserEmail).HasMaxLength(255);
            builder.Property(x => x.UserPhone).HasMaxLength(11);
        }
    }
}
