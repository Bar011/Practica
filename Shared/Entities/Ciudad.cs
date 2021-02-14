using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Practica.Shared.Entities
{
    public class Ciudad
    {
        [Key]
        public int Id_Ciudad { get; set; }

        [Required]
        public string NombreCiudad { get; set; }
    }
}
