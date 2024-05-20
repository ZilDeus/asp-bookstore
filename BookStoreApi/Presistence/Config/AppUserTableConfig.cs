using BookStoreApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApi.Presistence.Config
{
  public class AppUserTableConfig : IEntityTypeConfiguration<AppUser>
  {
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<AppUser> builder)
    {
    }
  }
}
