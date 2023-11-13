using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Models
{
    public class Autor
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;

        // Propiedad de navegación para representar la relación 1 a muchos con libros
        public List<Libro> Libros { get; set; } = new List<Libro>();
    }
}
