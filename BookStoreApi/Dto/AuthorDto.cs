namespace BookStoreApi.Dto
{
  public class AuthorDto
  {
    public string Name { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public int BirthYear { get; set; }
    public string[] Reviews { get; set; }
    public string[] Reports { get; set; }
    public string[] Books { get; set; }
  }
}
