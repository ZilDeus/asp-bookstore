using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreApi.Entities
{
  [Table("Book")]
  public class Book
  {
    public Guid Id { get; private set; }

    [Required]
    public string Title { get; set; } = null!;
    [Column("published_at"), Required]
    public DateOnly PublishedAt { get; set; }

    //TODO: replace this string with an enum array
    [Required]
    public string Genre { get; set; } = null!;

    public Author Author { get; set; } = null!;

    public ICollection<Report> Reports { get; set; } = null!;

    public ICollection<Review> Reviews { get; set; } = null!;

    public int Rating { get; set; } = 0;
  }
}
