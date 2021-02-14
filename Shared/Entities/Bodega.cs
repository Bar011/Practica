using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Practica.Shared.Entities
{
    public class Bodega
    {
        [Key]
        public int ID_Bodega { get; set; }

        public string NombreBodega { get; set; }

        public int Id_Sucursal { get; set; }

        public Sucursal Sucursal { get; set; }

    }
}
