using System.ComponentModel.DataAnnotations;

namespace Authentication.DTO;
public class UpdateUserDTO{
    public string firstName { get; set; }
    public string middleName { get; set; }
    public string lastName { get; set; }
    public string email { get; set; }
    public string password { get; set; }
}