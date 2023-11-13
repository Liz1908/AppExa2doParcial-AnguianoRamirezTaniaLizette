using AccesoDatos.Context;
using AccesoDatos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Operaciones
{
    public class LibroDAO
    {
        //Creamos un objeto de contexto de BD
        public ProyectoContext contexto = new ProyectoContext();

        //Método para seleccionar a todos los libros
        public List<Libro> seleccionarTodos()
        {
            var profesor = contexto.Libros.ToList<Libro>();
            return profesor;
        }
        // 1.- Método para crear nuevo Libro: Creará un nuevo libro, aportando todos sus datos incluido el autor a la BD
        public bool insertar(Libro nuevoLibro)
        {
            try
            {
                // Verifica si el autor ya existe en la base de datos
                Autor autorExistente = contexto.Autores.FirstOrDefault(a => a.Nombre == nuevoLibro.Autor.Nombre);

                if (autorExistente == null)
                {
                    // Si el autor no existe, agrega el nuevo autor a la base de datos
                    contexto.Autores.Add(nuevoLibro.Autor);
                    contexto.SaveChanges();
                }
                else
                {
                    // Si el autor ya existe, asigna el autor existente al nuevo libro
                    nuevoLibro.AutorId = autorExistente.Id;
                }
                // Agrega el nuevo libro a la base de datos
                contexto.Libros.Add(nuevoLibro);
                contexto.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        //2.- Método para obtener todos los libros: Deberá devolver un listado de libros con sus autores.
        public List<LibroConAutor> seleccionarLibrosAutores()
        {
            // Consulta LINQ para obtener todos los libros con sus autores
            var query = from book in contexto.Libros
                        join author in contexto.Autores on book.AutorId
                        equals author.Id
                        select new LibroConAutor
                        {
                            TituloLibro = book.Titulo,
                            NombreAutor = author.Nombre,
                            CapitulosLibro = book.Capitulos,
                            PaginasLibro = book.Paginas,
                            PrecioLibro = book.Precio
                        };

            return query.ToList();
        }
        //3.- Método para seleccionar un libro en especifico por id
        //3. Consultar libro: Deberá devolver todos los datos de un libro en específico con base a 
        ///su id.
        public Libro seleccionar(int id)
        {
            var libro = contexto.Libros.Where(p => p.Id == id).FirstOrDefault();
            return libro;
        }
        //Adicional Campo de busqueda 
        public List<LibroConAutor> adicionalCampoDeBusqueda(string tituloBusqueda)
        {
                // Obtén la lista de libros según la búsqueda
                var libros = from libro in contexto.Libros
                             join autor in contexto.Autores on libro.AutorId equals autor.Id
                             where string.IsNullOrEmpty(tituloBusqueda) || libro.Titulo.Contains(tituloBusqueda)
                             select new LibroConAutor
                             {
                                 TituloLibro = libro.Titulo,
                                 NombreAutor = autor.Nombre,
                                 CapitulosLibro = libro.Capitulos,
                                 PaginasLibro = libro.Paginas,
                                 PrecioLibro = libro.Precio
                             };

                return libros.ToList();
            }


        //Método para actualizar los datos de un libros a la BD
        public bool actualizar(int id, string titulo, int capitulos, int paginas, int precio, int autorId)
        {
            try
            {
                //Seleccionamos al libro
                var libro = seleccionar(id);
                if (libro == null)
                {
                    return false;
                }
                else
                {
                    libro.Id = id;
                    libro.Titulo = titulo;
                    libro.Capitulos = capitulos;
                    libro.Paginas = paginas;
                    libro.Precio = precio;
                    libro.AutorId = autorId;

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
