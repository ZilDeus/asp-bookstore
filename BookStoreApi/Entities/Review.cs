using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreApi.Entities
{
  [Table("review")]
  public class Review
  {

    public Guid Id { get; private set; }

    [Required]
    public int Score { get; set; } = 0;
    public string Content { get; set; }

    public Book Book { get; set; } = null!;

    public AppUser User { get; set; } = null!;
  }
}
