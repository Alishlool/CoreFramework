using System.ComponentModel.DataAnnotations;

namespace DotNetApi;
public class LoginDto
{
    [Required]
    public string username { get; set; }
    [Required]

    public string PassWord { get; set; }
}
