using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace estudo.domain.DTO_s.Responses
{
    public class InternalServerErrorObjectResult : ObjectResult
    {
        public InternalServerErrorObjectResult(object error): base(error)
        {
            StatusCode = StatusCodes.Status500InternalServerError;
        }
    }
}
