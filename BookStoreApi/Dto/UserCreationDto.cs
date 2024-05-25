using System.ComponentModel.DataAnnotations;

namespace BookStoreApi.Dto
{
  public class UserRegistrationDto
  {
    [Required(ErrorMessage = "username is required")]
    public string Username { get; set; }
    [EmailAddress]
    [Required(ErrorMessage = "user email is required")]
    public string Email { get; set; }
    [Required(ErrorMessage = "user password is required")]
    public string Password { get; set; }
    [Required(ErrorMessage = "user role is required")]
    public int Role { get; set; }
  }
}
