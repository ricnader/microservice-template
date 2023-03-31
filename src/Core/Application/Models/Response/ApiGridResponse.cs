using Newtonsoft.Json;

namespace Application.Models
{
    public class ApiGridResponse
    {
        public IEnumerable<object> Rows { get; private set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? Total { get; private set; }

        public  ApiGridResponse(IEnumerable<object> rows, int? total)
        {
            Rows = rows;
            Total = total;
        }
    }
}
