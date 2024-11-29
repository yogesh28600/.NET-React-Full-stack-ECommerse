namespace Authentication.Models;
public class User{
    public Guid Id { get; set; }
    public string firstName { get; set; }
    public string middleName { get; set; }
    public string lastName { get; set; }
    public string email { get; set; }
    public string passwordHash { get; set; }
}
