namespace Authentication.DTO;
public class GetUserDTO{
    public Guid id { get; set; }
    public string firstName { get; set; }
    public string middleName { get; set; }
    public string lastName { get; set; }
    public string email { get; set; }
}