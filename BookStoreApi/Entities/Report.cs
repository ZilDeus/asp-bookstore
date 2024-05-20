using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreApi.Entities
{
  [Table("report")]
  public class Report
  {
    public Guid Id { get; private set; }

    [Column, Required]
    public string Content { get; set; } = null!;

    public Book Book { get; set; } = null!;

    public AppUser User { get; set; } = null!;
  }
}
