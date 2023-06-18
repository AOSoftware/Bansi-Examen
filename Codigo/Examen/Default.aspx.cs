using apiExamen;
using Datos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.UI;

namespace Examen
{
    public partial class _Default : Page
    {
        // Variable para almacenar la cadena de conexión obtenida del archivo web.config
        public string conn = ConfigurationManager.ConnectionStrings["BdiExamenEntities"].ConnectionString;
        // Variable booleana para indicar el tipo de servicio a utilizar(DLL o WebService)
        public bool Wser = true;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Configurar estilo de filas alternadas en el DataGrid
                dgResultados.ItemStyle.CssClass = "even-row";
                dgResultados.AlternatingItemStyle.CssClass = string.Empty;
            }
        }

        /// <summary>
        /// Evento de clic para el botón "Agregar".
        /// Agrega un examen utilizando una DLL o un Web Service según la opción seleccionada.
        /// </summary>
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            int id = 0;
            string nombre = txtNombre.Text;
            string descripcion = txtDescripcion.Text;
            string servicio = chkServicios.SelectedValue; // Obtener el valor seleccionado del CheckBoxList
            string descripcionRetorno = "";

            try
            {
                if (servicio == "sps")
                {
                    // Llamar a la función de la DLL al Stored Procedure para agregar el examen
                    Wser = false;
                    clsExamen Clase = new clsExamen(conn, Wser);
                    Tuple<int, string> resultado = Clase.AgregarExamen(id, nombre, descripcion);
                    int codigoRetorno = resultado.Item1;
                    descripcionRetorno = resultado.Item2;
                }
                else if (servicio == "ws")
                {
                    // Llamar a la función de la DLL al Web Service para agregar el examen
                    clsExamen Clase = new clsExamen(conn, Wser);
                    Tuple<int, string> resultado = Clase.AgregarExamen(id, nombre, descripcion);
                    int codigoRetorno = resultado.Item1;
                    descripcionRetorno = resultado.Item2;
                }

                MostrarMensaje(descripcionRetorno);
            }
           catch
            { MostrarMensaje(descripcionRetorno); }
        }

        /// <summary>
        /// Evento de clic para el botón "Actualizar".
        /// Actualiza un examen utilizando una DLL o un Web Service según la opción seleccionada.
        /// </summary>
        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            string nombre = txtNombre.Text;
            string descripcion = txtDescripcion.Text;
            string servicio = chkServicios.SelectedValue; // Obtener el valor seleccionado del CheckBoxList
            string descripcionRetorno = "";

            try
            {
                if (servicio == "sps")
                {
                    // Llamar a la función de la DLL al Stored Procedure para actualizar el examen
                    Wser = false;
                    clsExamen Clase = new clsExamen(conn, Wser);
                    Tuple<int, string> resultado = Clase.ActualizarExamen(id, nombre, descripcion);
                    int codigoRetorno = resultado.Item1;
                    descripcionRetorno = resultado.Item2;
                }
                else if (servicio == "ws")
                {
                    // Llamar a la función de la DLL al Web Service para actualizar el examen
                    clsExamen Clase = new clsExamen(conn, Wser);
                    Tuple<int, string> resultado = Clase.ActualizarExamen(id, nombre, descripcion);
                    int codigoRetorno = resultado.Item1;
                    descripcionRetorno = resultado.Item2;
                }

                MostrarMensaje(descripcionRetorno);
            }
            catch { MostrarMensaje(descripcionRetorno); }
        }

        /// <summary>
        /// Evento de clic para el botón "Eliminar".
        /// Elimina un examen utilizando una DLL o un Web Service según la opción seleccionada.
        /// </summary>
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            string servicio = chkServicios.SelectedValue; // Obtener el valor seleccionado del CheckBoxList
            string descripcionRetorno = "";

            try
            {
                if (servicio == "sps")
                {
                    // Llamar a la función de la DLL al Stored Procedure para eliminar el examen
                    Wser = false;
                    clsExamen Clase = new clsExamen(conn, Wser);
                    Tuple<int, string> resultado = Clase.EliminarExamen(id);
                    int codigoRetorno = resultado.Item1;
                    descripcionRetorno = resultado.Item2;
                }
                else if (servicio == "ws")
                {
                    // Llamar a la función de la DLL al Web Service para eliminar el examen
                    clsExamen Clase = new clsExamen(conn, Wser);
                    Tuple<int, string> resultado = Clase.EliminarExamen(id);
                    int codigoRetorno = resultado.Item1;
                    descripcionRetorno = resultado.Item2;
                }

                MostrarMensaje("Registro eliminado satisfactoriamente");
            }
            catch { MostrarMensaje(descripcionRetorno); }
        }

        /// <summary>
        /// Evento de clic para el botón "Consultar".
        /// Consulta los exámenes utilizando una DLL o un Web Service según la opción seleccionada.
        /// </summary>
        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            List<tblExamen> Lista;
            string servicio = chkServicios.SelectedValue; // Obtener el valor seleccionado del CheckBoxList

            if (servicio == "sps")
            {
                // Llamar a la función de la DLL al Stored Procedure para consultar exámenes
                Wser = false;
                clsExamen Clase = new clsExamen(conn, Wser);
                Lista = Clase.ConsultarExamen();
            }
            else
            {
                // Llamar a la función de la DLL al Web Service para consultar los exámenes
                clsExamen Clase = new clsExamen(conn, Wser);
                Lista = Clase.ConsultarExamen();
            }

            dgResultados.DataSource = Lista;
            dgResultados.DataBind();
        }

        /// <summary>
        /// Muestra un mensaje en el label lblMensaje.
        /// </summary>
        /// <param name="mensaje">El mensaje a mostrar.</param>
        private void MostrarMensaje(string mensaje)
        {
            lblMensaje.Text = mensaje;
        }
    }
}