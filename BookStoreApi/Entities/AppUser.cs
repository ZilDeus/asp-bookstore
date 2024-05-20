using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreApi.Entities
{
  [Table("app_user")]
  public class AppUser
  {
    public Guid Id { get; private set; }

    [Required]
    public string Username { get; set; } = null!;
    [Required]
    public string Email { get; set; } = null!;
    [Required]
    public string Password { get; set; } = null!;

    [Required]
    public UserRoles Role { get; set; }

    public ICollection<Book> Books { get; set; } = null!;

    public ICollection<Report> Reports { get; set; } = null!;

    public ICollection<Review> Reviews { get; set; } = null!;
  }
}
