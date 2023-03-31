using Microsoft.AspNetCore.Mvc;

namespace Application.Models
{

    public class ApiBaseController : ControllerBase
    {
        protected OkObjectResult OKReponse(IEnumerable<object> rows, int? total = null, string message = null)
        {
            var apiGridResponse = new ApiGridResponse(rows, total);
            return Ok(new ApiOkResponse(apiGridResponse, message));
        }

        protected OkObjectResult OKReponse(object data, string message = null)
        {
            var apiDataResponse = new ApiDataResponse(data);
            return Ok(new ApiOkResponse(apiDataResponse, message));
        }

        protected OkObjectResult OKReponse()
        {            
            return Ok(new ApiOkResponse());
        }

        protected OkObjectResult OKReponse(string message)
        {
            return Ok(new ApiOkResponse(message));
        }
    }
}
