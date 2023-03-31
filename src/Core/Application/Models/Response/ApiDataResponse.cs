namespace Application.Models
{
    public class ApiDataResponse
    {
        public object Data { get; private set; }

        public ApiDataResponse(object data)
        {
            Data = data;
        }
    }
}
