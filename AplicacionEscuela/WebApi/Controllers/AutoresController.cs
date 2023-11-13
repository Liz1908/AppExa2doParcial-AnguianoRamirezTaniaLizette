using AccesoDatos.Models;
using AccesoDatos.Operaciones;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;



namespace WebApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class AutoresController : ControllerBase
    {
        private AutorrDAO autorDAO = new AutorrDAO();

        /**
         * Endpoint para consultar a todas los autores de la BD.
         */
        [HttpGet("autores/todos")]
        public List<Autor> getTodosLibro()
        {
            var autor = autorDAO.seleccionarTodos();
            return autor;
        }
        /**
         * Endpoint para crear un nuevo autor.
         * //4.- Método para crear un autor: Creará un nuevo autor a la BD
         */

        [HttpPost("autor/insertar")]
        public bool insertar([FromBody] Autor autor)
        {
            return autorDAO.insertar(autor.Nombre);
        }

        /**
            * Endpoint para consultar a todas los autores de la BD.
            * 5.- Método para obtener todos los autores: Deberá devolver un listado 
            * de todos los autores con los libros que tengan.
            */
        [HttpGet("autoreslibros/todos")]
        public List<LibroConAutor> getTodosAutoresConLibros()
        {
            var autor = autorDAO.seleccionarAutoresConLibros();
            return autor;
        }
        /**
         * Endpoint para consultar una autor específica por ID.
         * 
         */
        [HttpGet("autor/id")]
        public Autor getAutor(int id)
        {
            return autorDAO.seleccionar(id);
        }
        /**
         * Endpoint para actualizar los datos de un autor.
         */

        [HttpPut("autor/actualizar")]
        public bool actualizar([FromBody] Autor autor)
        {
            return autorDAO.actualizar(autor.Id, autor.Nombre);
        }
    }
}
