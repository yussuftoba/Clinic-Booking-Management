using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public class Specialization
{
    [Key]
    public int SpecializationId { get; set; }

    [Required(ErrorMessage = "{0} is required!"), Column(TypeName ="varchar(50)")]
    [DisplayName("Specialization name")]
    public string SpecializationName { get; set; }
}
