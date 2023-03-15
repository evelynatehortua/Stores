using System.Net;

namespace Stores.WEB.Repositories
{
    public class HttpResponseWrapper<T>
    {
        // Constructor
        public HttpResponseWrapper(T? response, bool error, HttpResponseMessage httpResponseMessage)
        {
            Error = error;
            Response = response;
            HttpResponseMessage = httpResponseMessage;
        }

        // Propiedades
        public bool Error { get; set; }

        public T? Response { get; set; }

        public HttpResponseMessage HttpResponseMessage { get; set; }

        public async Task<string?> GetErrorMessage()
        {
            if (!Error)
            {
                return null;
            }
            var codigoEstatus = HttpResponseMessage.StatusCode;
            if (codigoEstatus == HttpStatusCode.NotFound)
            {
                return "Recurso no encontrado";
            }
            else if (codigoEstatus == HttpStatusCode.BadRequest)
            {
                return await HttpResponseMessage.Content.ReadAsStringAsync();
            }
            else if (codigoEstatus == HttpStatusCode.Unauthorized)
            {
                return " Debes loguearte para realizar esta acción";
            }
            else if (codigoEstatus == HttpStatusCode.Forbidden)
            {
                return " No tienes permisos para ejecutar esta acción";
            }
            return "Ha ocurrido un error inesperado";
        }
    }
}