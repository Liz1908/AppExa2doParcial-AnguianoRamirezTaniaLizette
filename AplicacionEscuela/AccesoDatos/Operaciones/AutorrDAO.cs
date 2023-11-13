using AccesoDatos.Context;
using AccesoDatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Operaciones
{
    public class AutorrDAO
    {
        //Creamos un objeto de contexto de BD
        public ProyectoContext contexto = new ProyectoContext();

        //Método para seleccionar todas las asignaturas
        public List<Autor> seleccionarTodos()
        {
            var asignatura = contexto.Autores.ToList<Autor>();
            return asignatura;
        }
        //Método para seleccionar una autor en especifico por id
        public Autor seleccionar(int id)
        {
            var autor = contexto.Autores.Where(a => a.Id == id).FirstOrDefault();
            return autor;
        }

        //4.- Método para crear un autor: Creará un nuevo autor a la BD
        public bool insertar(string nombre)
        {
            try
            {
                Autor autor = new Autor();
                autor.Nombre = nombre;

                contexto.Autores.Add(autor);
                contexto.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //5.- Método para obtener todos los autores: Deberá devolver un listado de todos los autores con los libros que tengan.
        public List<LibroConAutor> seleccionarAutoresConLibros()
        {

            // Consulta LINQ para obtener todos los autores con los libros que tienen
            var query = from author in contexto.Autores
                            join book in contexto.Libros on author.Id equals book.AutorId
                            select new LibroConAutor 
                            {
                                NombreAutor = author.Nombre,
                                TituloLibro = book.Titulo,
                                Capitulos = book.Capitulos,
                                Paginas = book.Paginas,
                                Precio = book.Precio
                            };

            return query.ToList();
        }

        //Método para actuaizar los datos de un autor a la BD
        public bool actualizar(int id, string nombre)
        {
            try
            {
                //Seleccionamos al alumno
                var autor = seleccionar(id);
                if (autor == null)
                {
                    return false;
                }
                else
                {
                    autor.Id = id;
                    autor.Nombre = nombre;

                    contexto.SaveChanges();

                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
///API: Deberás de crear los siguientes endpoints:
///1.Nuevo Libro: Creará un nuevo libro, aportando todos sus datos incluido el autor.
///2. Obtener todos los libros: Deberá devolver un listado de libros con sus autores.
///3. Consultar libro: Deberá devolver todos los datos de un libro en específico con base a 
///su id.
///4. Crear un autor: Creará un nuevo autor.
///5. Obtener todos los autores: Deberá devolver un listado de todos los autores con los 
///libros que tengan.
//6. Generar una vista html en la que se muestre el listado de libros, con todos sus datos. 
//Utilizando JavaScript para realizar la petición (fetch) de los datos.
//
