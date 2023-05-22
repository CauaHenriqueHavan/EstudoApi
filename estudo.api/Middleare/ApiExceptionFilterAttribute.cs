using Abp.Json;
using estudo.domain.Auxiliar;
using estudo.domain.DTO_s.Responses;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System.Net;

namespace estudo.api.Middleare
{
    public class ApiExceptionFilteAttribute : ExceptionFilterAttribute
    {
        private readonly ILogger<ApiExceptionFilteAttribute> _logger;

        public ApiExceptionFilteAttribute(ILogger<ApiExceptionFilteAttribute> logger)
            => _logger = logger;

        public override void OnException(ExceptionContext context)
        {
            _logger.LogError(2023, context.Exception, GerarLogRequest(context));

            HandleException(context);

            base.OnException(context);
        }

        private static void HandleException(ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Result = new InternalServerErrorObjectResult(
                new ResultViewBaseModel().AddErros("Ocorreu um erro estamos tentando resolver o mais breve possível")
                );

            context.ExceptionHandled = true;
        }

        private static string GerarLogRequest(ExceptionContext context)
        {
            var request = (((object, CustomizeValidatorAttribute))context.HttpContext.Items["_FV_Customizations"]).Item1 ?? string.Empty;
            var uri = context.HttpContext.Request.Path.Value.ToString();
            return JsonConvert.SerializeObject(new ErrorLogReponse(request?.ToJsonString(), uri));
        }

        public class ErrorLogReponse
        {
            public string RequestParams { get; set; }
            public string UriPath { get; set; }
            public ErrorLogReponse(string requestParams, string uriPath)
            {
                RequestParams = requestParams;
                UriPath = uriPath;
            }
        }
    }
}
