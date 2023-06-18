using Datos;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace wcfexamen
{
    [ServiceContract]
    public interface IWsApiexamen
    {
        [OperationContract]
        Response AgregarExamen(int id, string nombre, string descripcion);

        [OperationContract]
        Response ActualizarExamen(int id, string nombre, string descripcion);

        [OperationContract]
        Response EliminarExamen(int id);

        [OperationContract]
        List<tblExamen> ConsultarExamenes();
    }

    /// <summary>
    /// Clase de respuesta que indica el resultado de una operación y un mensaje descriptivo.
    /// </summary>
    [DataContract]
    public class Response
    {
        [DataMember]
        public bool Success { get; set; }
        [DataMember]
        public string Message { get; set; }

        public Response(bool success, string message)
        {
            Success = success;
            Message = message;
        }
    }

}
