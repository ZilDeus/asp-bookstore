using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace BookStoreApi.Entities
{
  [Table("app_user")]
  public class AppUser : IdentityUser
  {
    public ICollection<Book> Books { get; set; } = null!;

    public ICollection<Report> Reports { get; set; } = null!;

    public ICollection<Review> Reviews { get; set; } = null!;
  }
}
