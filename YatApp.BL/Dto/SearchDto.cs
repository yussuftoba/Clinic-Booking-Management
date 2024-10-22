using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    public class SearchDto
    {
        public int? SpecializationId { get; set; } = null;
        public string? Name { get; set; }
    }
}
