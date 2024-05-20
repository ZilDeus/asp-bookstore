using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreApi.Entities
{
  [Table("author")]
  public class Author
  {

    public Guid Id { get; private set; }

    [Required]
    public string Name { get; set; } = null!;
    public string Country { get; set; } = null!;
    public string City { get; set; } = null!;

    public int BirthYear { get; set; } = 0;

    public ICollection<Book> Books { get; set; } = null!;

    public ICollection<Report> Reports { get; set; } = null!;

    public ICollection<Review> Reviews { get; set; } = null!;

    public int Rating { get; set; } = 0;
  }
}
