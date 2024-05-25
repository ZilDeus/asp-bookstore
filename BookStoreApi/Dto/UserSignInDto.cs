using System.ComponentModel.DataAnnotations;

namespace BookStoreApi.Dto
{
  public class UserLogInDto
  {
    [EmailAddress]
    [Required(ErrorMessage = "user email is required")]
    public string Email { get; set; }
    [Required(ErrorMessage = "user password is required")]
    public string Password { get; set; }
  }
}
