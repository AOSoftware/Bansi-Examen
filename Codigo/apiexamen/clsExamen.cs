using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using wcfexamen;
using Datos;

namespace apiExamen
{
    public class clsExamen
    {
        private string connectionString; // Cadena de conexión a la base de datos
        private bool useWebServices;     // Indicador para usar WebServices o procedimientos almacenados
        private int codigoRetorno;       // Codigo retorno indicador de resultado
        private string descripcionRetorno; // Descripcion de resultado 

        // Constructor de la clase
        public clsExamen(string connectionString, bool useWebServices)
        {
            this.connectionString = connectionString;
            this.useWebServices = useWebServices;
        }

        /// <summary>
        /// Agrega un examen a la base de datos.
        /// </summary>
        /// <param name="nombre">El nombre del examen.</param>
        /// <param name="Descripcion">La descripcion del examen.</param>
        /// <exception cref="ArgumentException">Se lanza cuando el nombre o Descripcion está vacío o nulo.</exception>
        public Tuple<int, string> AgregarExamen(int id, string nombre, string Descripcion)
        {
            // Validar los datos de entrada
            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new ArgumentException("El nombre no puede estar vacío.");
            }

            if (string.IsNullOrWhiteSpace(Descripcion))
            {
                throw new ArgumentException("La descripción no puede estar vacía.");
            }

            if (useWebServices)
            {
                // Llamar al WebService correspondiente para agregar el examen
               WsApiexamen wsClient = new WsApiexamen();
               wsClient.AgregarExamen(id, nombre, Descripcion);
            }
            else
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("spAgregar", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Configurar los parámetros del procedimiento 
                        command.Parameters.AddWithValue("@Id", id);
                        command.Parameters.AddWithValue("@nombre", nombre);
                        command.Parameters.AddWithValue("@Descripcion", Descripcion);

                        // Configurar los parámetros de salida
                        SqlParameter codigoRetornoParam = new SqlParameter("@CodigoRetorno", SqlDbType.Int);
                        codigoRetornoParam.Direction = ParameterDirection.Output;
                        command.Parameters.Add(codigoRetornoParam);

                        SqlParameter descripcionRetornoParam = new SqlParameter("@DescripcionRetorno", SqlDbType.VarChar, 100);
                        descripcionRetornoParam.Direction = ParameterDirection.Output;
                        command.Parameters.Add(descripcionRetornoParam);

                        // Ejecutar el comando
                        command.ExecuteNonQuery();

                        codigoRetorno = (int)codigoRetornoParam.Value;
                        descripcionRetorno = descripcionRetornoParam.Value.ToString();
                    }
                }

            }
              return new Tuple<int, string>(codigoRetorno, descripcionRetorno);
        }

        /// <summary>
        /// Actualiza un examen en la base de datos.
        /// </summary>
        /// <param name="Id">El ID del examen a actualizar.</param>
        /// <param name="nombre">El nuevo nombre del examen.</param>
        /// <param name="Descripcion">La nueva descripción del examen.</param>
        /// <exception cref="ArgumentException">Se lanza cuando el nombre está vacío o nulo.</exception>
        public Tuple<int, string> ActualizarExamen(int Id, string nombre, string Descripcion)
        {
            // Validar los datos de entrada
            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new ArgumentException("El nombre no puede estar vacío.");
            }

            if (string.IsNullOrWhiteSpace(Descripcion))
            {
                throw new ArgumentException("La descripción no puede estar vacía.");
            }

            if (useWebServices)
            {
                // Llamar al WebService correspondiente para actualizar el examen
                WsApiexamen wsClient = new WsApiexamen();
                wsClient.ActualizarExamen(Id, nombre, Descripcion);
            }
            else
            {
                // Ejecutar el procedimiento almacenado correspondiente para actualizar el examen
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("spActualizar", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Configurar los parámetros del procedimiento almacenado
                        command.Parameters.AddWithValue("@Id", Id);
                        command.Parameters.AddWithValue("@nombre", nombre);
                        command.Parameters.AddWithValue("@Descripcion", Descripcion);

                        // Configurar los parámetros de salida
                        SqlParameter codigoRetornoParam = new SqlParameter("@CodigoRetorno", SqlDbType.Int);
                        codigoRetornoParam.Direction = ParameterDirection.Output;
                        command.Parameters.Add(codigoRetornoParam);

                        SqlParameter descripcionRetornoParam = new SqlParameter("@DescripcionRetorno", SqlDbType.VarChar, 100);
                        descripcionRetornoParam.Direction = ParameterDirection.Output;
                        command.Parameters.Add(descripcionRetornoParam);

                        // Ejecutar el comando
                        command.ExecuteNonQuery();

                        codigoRetorno = (int)codigoRetornoParam.Value;
                        descripcionRetorno = descripcionRetornoParam.Value.ToString();
                    }
                }
            }
              return new Tuple<int, string>(codigoRetorno, descripcionRetorno);
        }

        /// <summary>
        /// Elimina un examen de la base de datos.
        /// </summary>
        /// <param name="Id">El ID del examen a eliminar.</param>
        public Tuple<int, string> EliminarExamen(int Id)
        {
            if (useWebServices)
            {
                // Llamar al WebService correspondiente para eliminar el examen
                WsApiexamen wsClient = new WsApiexamen();
                wsClient.EliminarExamen(Id);
            }
            else
            {
                // Ejecutar el procedimiento almacenado correspondiente para eliminar el examen
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("spEliminar", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Configurar los parámetros del procedimiento almacenado
                        command.Parameters.AddWithValue("@Id", Id);

                        // Configurar los parámetros de salida
                        SqlParameter codigoRetornoParam = new SqlParameter("@CodigoRetorno", SqlDbType.Int);
                        codigoRetornoParam.Direction = ParameterDirection.Output;
                        command.Parameters.Add(codigoRetornoParam);

                        SqlParameter descripcionRetornoParam = new SqlParameter("@DescripcionRetorno", SqlDbType.VarChar, 100);
                        descripcionRetornoParam.Direction = ParameterDirection.Output;
                        command.Parameters.Add(descripcionRetornoParam);

                        // Ejecutar el comando
                        command.ExecuteNonQuery();
                    }
                }
            }
             return new Tuple<int, string>(codigoRetorno, descripcionRetorno);
        }

        /// <summary>
        /// Consulta examenes en la base de datos y devuelve un DataTable con los resultados.
        /// </summary>
        /// <returns>Una Lista con los resultados de la consulta.</returns>
        public List<tblExamen> ConsultarExamen()
        {
            List<tblExamen> examen = new List<tblExamen>();
            DataTable tabla = new DataTable();

            if (useWebServices)
            {
                // Llamar al WebService correspondiente para consultar el examen
                WsApiexamen wsClient = new WsApiexamen();
                examen = wsClient.ConsultarExamenes();
            }
            else
            {
                // Ejecutar el procedimiento almacenado correspondiente para consultar el examen
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("spConsultar", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Configurar los parámetros del procedimiento almacenado
                        command.Parameters.AddWithValue("@Nombre", null);
                        command.Parameters.AddWithValue("@Descripcion", null);

                        // Ejecutar el comando y obtener los resultados en un DataTable
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(tabla);
                        }

                        // Llenar Lista con resultados obtenidos
                        foreach (DataRow row in tabla.Rows)
                        {
                            tblExamen registro = new tblExamen();
                            registro.idExamen = (int)row["idExamen"];
                            registro.Nombre = row["Nombre"].ToString();
                            registro.Descripcion = row["Descripcion"].ToString();

                            examen.Add(registro);
                        }
                    }
                }
            }

            return examen;
        }
    }
}
