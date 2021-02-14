using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practica.Shared.Entities
{
    public class Comuna
    {
        [Key]
        public int Id_Comuna { get; set; }
        
        [Required]
        public string NombreComuna { get; set; }

        public int Id_Ciudad { get; set; }

        public Ciudad Ciudad { get; set; }
    }
}