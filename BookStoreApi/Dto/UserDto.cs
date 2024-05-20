namespace BookStoreApi.Dto
{
  public class UserDto
  {
    public string Username { get; set; }
    public string Email { get; set; }
    public string[] Books { get; set; }
    public string[] Reviews { get; set; }
    public string[] Reports { get; set; }
  }
}
