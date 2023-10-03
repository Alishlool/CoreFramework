using System.ComponentModel.DataAnnotations;

namespace DotNetApi;
public class RegisterDto
{

    [Required]
    public string UserName { get; set; }
    [Required]
    
    public string PassWord { get; set; }
}
