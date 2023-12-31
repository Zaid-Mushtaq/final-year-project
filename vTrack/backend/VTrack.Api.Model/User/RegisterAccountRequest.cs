using System.ComponentModel.DataAnnotations;

namespace VTrack.Api.Model.User;

public class RegisterAccountRequest
{
    [Required]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }

    [Required]
    public string ConfirmPassword { get; set; }
}