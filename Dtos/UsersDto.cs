using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace back_end_challenge.Dtos
{


  public class LoginUserDto
  {
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }

    [Required]
    [StringLength(15, ErrorMessage = "Your password must have only 15 characters")]
    public string Password { get; set; }
  }

  public class UserCreateDto : LoginUserDto
  {
    public string FirstName { get; set; }
    public string LastName { get; set; }

    [DataType(DataType.PhoneNumber)]
    public string PhoneNumber { get; set; }

  }

  public class UserUpdateDto : UserCreateDto { }

  public class UserReadDto : UserCreateDto
  {
    public int Id { get; set; }

  }

}