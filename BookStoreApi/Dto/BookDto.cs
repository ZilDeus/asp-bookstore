namespace BookStoreApi.Dto
{
  public class BookDto
  {
    public string Title { get; set; }
    public string Genre { get; set; }
    public string Author { get; set; }
    public string[] Reviews { get; set; }
    public string[] Reports { get; set; }
  }
}
