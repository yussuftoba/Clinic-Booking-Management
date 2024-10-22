using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public class Review
{
    [Key]
    public int RatingID { get; set; }

    [Required(ErrorMessage = "{0} is required")]
    [Range(1, 5, ErrorMessage = "{0} must be between 1 and 5")]
    public int Rating { get; set; } // Rating out of 5

    public string? Comment { get; set; }

    [Required(ErrorMessage = "{0} is required")]
    public DateTime ReviewDate { get; set; } = DateTime.Now;

    //! Navigation fields
    [ForeignKey("Patient")]
    public int PatientId { get; set; }
    public Patient? Patient { get; set; }

    [ForeignKey("Doctor")]
    public int DoctorId { get; set; }
    public Doctor? Doctor { get; set; }
}
