using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Models;

public abstract class Person
{
    [Key]
    public int PersonId { get; set; }

    [Required(ErrorMessage = "{0} is required!")]
    [DisplayName("First name")]
    public string FirstName { get; set; } = string.Empty;

    [Required(ErrorMessage = "{0} is required!")]
    [DisplayName("Last name")]
    public string LastName { get; set; } = string.Empty;

    [Required(ErrorMessage = "{0} is required!")]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "{0} is required!")]
    [Phone]
    public string Phone { get; set; } = string.Empty;

    [Required(ErrorMessage = "{0} is required")]
    public DateTime DateOfBirth { get; set; }

    //! Note that this will be hashed
    [Required(ErrorMessage = "{0} is required!")]
    public string Password { get; set; } = string.Empty;
    public int? GenderId { get; set; }
    public Gender? Gender { get; set; }
    public string? Address { get; set; }
}
