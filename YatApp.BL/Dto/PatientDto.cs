
using System.ComponentModel.DataAnnotations;

namespace Dto;

public class PatientDto
{
    
    public string FirstName { get; set; } 
    public string LastName { get; set; }
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }
    public string Phone { get; set; } 
    public DateTime DateOfBirth { get; set; }
    [DataType(DataType.Password)]
    public string Password { get; set; }
    public int? GenderId { get; set; }
    public string? Address { get; set; }
    public int? InsuranceID { get; set; }

}
