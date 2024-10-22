using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models;

public class City
{
    public int Id { get; set; }
    [Column(TypeName ="varchar(30)")]
    public string Name { get; set; }
}
