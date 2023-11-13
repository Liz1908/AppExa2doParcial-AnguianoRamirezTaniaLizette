using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Models
{
    public class Libro
    {
        public int Id { get; set; }

        public string Titulo { get; set; } = null!;

        public int Capitulos { get; set; }

        public int Paginas { get; set; }

        public int Precio { get; set; }

        // Clave foránea para la relación con Autor
        public int AutorId { get; set; }

        // Propiedad de navegación para representar la relación con el autor
        public virtual Autor Autor { get; set; } = null!;
    }
}
