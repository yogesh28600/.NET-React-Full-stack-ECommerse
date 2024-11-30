namespace Authentication.DTO;

public class GetUserWithTokenDTO : GetUserDTO{
    public string token { get; set; }
}