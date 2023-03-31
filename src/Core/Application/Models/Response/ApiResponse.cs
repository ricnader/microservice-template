using Newtonsoft.Json;
using System.Text.Json;

namespace Application.Models
{
    public abstract class ApiResponse
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; }
        public int StatusCode { get; }

        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        private static string GetDefaultMessageForStatusCode(int statusCode)
        {
            switch (statusCode)
            {
                case 400:
                    return "Requisição inválida";
                case 404:
                    return "Recurso não encontrado";
                case 500:
                    return "Ocorreu um erro interno";
                default:
                    return null;
            }
        }
    }
}
