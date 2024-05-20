namespace BookStoreApi.Dto
{
  public class BookCreationDto
  {
    public string Title { get; set; }
    public string Genre { get; set; }
    public Guid Author { get; set; }
  }
}
