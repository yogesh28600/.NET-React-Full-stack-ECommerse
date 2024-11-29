using System.ComponentModel.DataAnnotations;

namespace Authentication.DTO;
public class CreateUserDTO{
    [Required]
    public string firstName { get; set; }
    public string middleName { get; set; }
    [Required]
    public string lastName { get; set; }
    [Required]
    public string email { get; set; }
    [Required]
    public string password { get; set; }
}