using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Practica.Shared.Entities
{
    public class Sucursal
    {
        [Key]
        public int IdSucursal { get; set; }
        
        [Required]

        public string NombreSucursal { get; set; }
        
        public string DireccionSucursal { get; set; }
        
        public int Id_Comuna { get; set; }
    }
}
