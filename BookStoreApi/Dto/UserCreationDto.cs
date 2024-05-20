namespace BookStoreApi.Dto
{
  public class UserCreationDto
  {
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public int Role { get; set; }
  }
}
