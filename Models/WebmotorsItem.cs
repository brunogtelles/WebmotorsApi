using System.ComponentModel.DataAnnotations;

namespace WebmotorsApi.Models
{
    public class WebmotorsItem
    {
    [Key]
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string? ConfirmPassword { get; set; }
    }
}
