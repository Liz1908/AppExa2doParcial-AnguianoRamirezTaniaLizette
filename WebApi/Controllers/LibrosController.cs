using AccesoDatos.Models;
using AccesoDatos.Operaciones;
using Microsoft.AspNetCore.Mvc;


namespace WebApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class LibrosController : ControllerBase
    {
        private LibroDAO libroDAO = new LibroDAO();

        /**
         * Endpoint para consultar a todos los libros de la BD.
         */
        [HttpGet("libros/todos")]
        public List<Libro> getTodosLibros()
        {
            var libro = libroDAO.seleccionarTodos();
            return (libro);
        }

        /**
         * Endpoint para crear un nuevo autor.
         * 1.- Método para crear nuevo Libro: Creará un nuevo libro,
         * aportando todos sus datos incluido el autor a la BD
         */

        [HttpPost("libro/insertar")]
        public bool insertar([FromBody] Libro libro)
        {
            return libroDAO.insertar(libro);//libro.Titulo, libro.Capitulos, libro.Paginas, libro.Precio, libro.AutorId
        }

        /**
            * Endpoint para consultar a todas los libros de la BD.
            * 2.- Método para obtener todos los libros: Deberá devolver un listado de libros con sus autores.
            */
        [HttpGet("LibrosConAutores/todos")]
        public List<LibroConAutor> getTodosLibrosConAutores()
        {
            var libro = libroDAO.seleccionarLibrosAutores();
            return libro;
        }
        /**
         * Endpoint para consultar una autor específica por ID.
         * 3. Consultar libro: Deberá devolver todos los datos de un libro en específico con base a su id
         */
        [HttpGet("libro/id")]
        public Libro getLibro(int id)
        {
            return libroDAO.seleccionar(id);
        }
        /**
            * Endpoint para consultar un libro Adicional Campo de busqueda 
         */
        [HttpGet("libro/tituloBusqueda")]
        public List<LibroConAutor> getAdicionalCampoDeBusqueda(string tituloBusqueda)
        {
            return libroDAO.adicionalCampoDeBusqueda(tituloBusqueda);
        }

        /**
         * Endpoint para actualizar los datos de un autor.
         

        [HttpPut("libro/actualizar")]
        public bool actualizar([FromBody] Libro libro)
        {
            return libroDAO.actualizar(libro.Id, libro.Titulo, libro.Capitulos, libro.Paginas, libro.Precio, libro.AutorId);
        }
        */
    }
}
