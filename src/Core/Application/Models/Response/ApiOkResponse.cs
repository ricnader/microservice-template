using Newtonsoft.Json;

namespace Application.Models
{
    public class ApiOkResponse : ApiResponse
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public object Response { get; }

        public ApiOkResponse(object response, string message = null)
            : base(200, message)
        {
            Response = response;
        }

        public ApiOkResponse()
            : base(200)
        {
           
        }

        public ApiOkResponse(string message)
            : base(200, message)
        {

        }
    }
}
