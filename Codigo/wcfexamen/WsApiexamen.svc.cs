using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace wcfexamen
{
    public class WsApiexamen : IWsApiexamen
    {
        private BdiExamenEntities dbContext = new BdiExamenEntities(); // Crear DbContext

        /// <summary>
        /// Agrega un nuevo examen a la base de datos mediante Entity Framework.
        /// </summary>
        /// <param name="id">ID del examen</param>
        /// <param name="nombre">Nombre del examen</param>
        /// <param name="descripcion">Descripción del examen</param>
        /// <returns>Objeto de respuesta que indica si la operación fue exitosa y un mensaje descriptivo</returns>
        public Response AgregarExamen(int id, string nombre, string descripcion)
        {
            try
            {
                using (var scope = new TransactionScope())
                {
                    tblExamen examen = new tblExamen();

                    examen.idExamen = id;
                    examen.Nombre = nombre;
                    examen.Descripcion = descripcion;

                    dbContext.tblExamen.Add(examen);
                    dbContext.SaveChanges();

                    scope.Complete(); // Confirma la transacción

                    return new Response(true, "Examen agregado exitosamente.");
                }
            }
            catch (Exception ex)
            {
                return new Response(false, "Error al agregar el examen: " + ex.Message);
            }

        }

        /// <summary>
        /// Actualiza un examen existente en la base de datos mediante Entity Framework.
        /// </summary>
        /// <param name="id">ID del examen a actualizar</param>
        /// <param name="nombre">Nuevo nombre del examen</param>
        /// <param name="descripcion">Nueva descripción del examen</param>
        /// <returns>Objeto de respuesta que indica si la operación fue exitosa y un mensaje descriptivo</returns>
        public Response ActualizarExamen(int id, string nombre, string descripcion)
        {
            try
            {
                using (var scope = new TransactionScope())
                {
                    // Busca el examen en la base de datos por su ID
                    var examen = dbContext.tblExamen.FirstOrDefault(e => e.idExamen == id);

                    if (examen == null)
                        return new Response(false, "No se encontró el examen especificado.");

                    // Actualiza las propiedades del examen
                    examen.Nombre = nombre;
                    examen.Descripcion = descripcion;

                    // Guarda los cambios en la base de datos
                    dbContext.SaveChanges();

                    scope.Complete(); // Confirma la transacción

                    return new Response(true, "Examen actualizado exitosamente.");
                }
            }
            catch (Exception ex)
            {
                return new Response(false, "Error al actualizar el examen: " + ex.Message);
            }
        }

        /// <summary>
        /// Consulta todos los exámenes de la base de datos mediante Entity Framework.
        /// </summary>
        /// <returns>Lista de objetos Examen que representan los resultados de la consulta</returns>
        public List<tblExamen> ConsultarExamenes()
        {
            // Obtiene todos los registros de la tabla "tblExamen" en la base de datos
            var examenes = dbContext.tblExamen.ToList();
            return examenes;
        }

        /// <summary>
        /// Elimina un examen de la base de datos mediante Entity Framework.
        /// </summary>
        /// <param name="id">ID del examen a eliminar</param>
        /// <returns>Objeto de respuesta que indica si la operación fue exitosa y un mensaje descriptivo</returns>
        public Response EliminarExamen(int id)
        {
            try
            {
                using (var scope = new TransactionScope())
                {
                    // Busca el examen en la base de datos por su ID
                    var examen = dbContext.tblExamen.FirstOrDefault(e => e.idExamen == id);

                    if (examen == null)
                        return new Response(false, "No se encontró el examen especificado.");

                    // Elimina el examen de la base de datos
                    dbContext.tblExamen.Remove(examen);
                    dbContext.SaveChanges();

                    scope.Complete(); // Confirma la transacción

                    return new Response(true, "Examen eliminado exitosamente.");
                }
            }
            catch (Exception ex)
            {
                return new Response(false, "Error al eliminar el examen: " + ex.Message);
            }
        }
    }
}
