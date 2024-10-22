using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public class Doctor : Person
{
    [Required(ErrorMessage = "{0} is required")]
    public double? ConsultationFee { get; set; }

    public bool Availability { get; set; } = true;

    public int? ExperienceYears { get; set; }
    public string? Qualifications { get; set; }
    public float? Rating { get; set; } = 4;
    public string Image {  get; set; }

    //! Navigation fields
    [ForeignKey("Specialization")]
    public int? SpecializationId { get; set; }
    public Specialization? Specialization { get; set; }
}
