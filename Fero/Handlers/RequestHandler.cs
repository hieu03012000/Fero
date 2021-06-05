using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Fero.Handlers
{
    public class RequestHandler
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _accessor;
        public RequestHandler(RequestDelegate next, IConfiguration configuration, IHttpContextAccessor accessor)
        {
            _next = next;
            _configuration = configuration;
            _accessor = accessor;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            //context.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            //context.Response.Headers.Add("Access-Control-Allow-Credentials", "true");
            // Added "Accept-Encoding" to this list
            //context.Response.Headers.Add("Access-Control-Allow-Headers", "Content-Type, X-CSRF-Token, X-Requested-With, Accept, Accept-Version, Accept-Encoding, Content-Length, Content-MD5, Date, X-Api-Version, X-File-Name");
            //context.Response.Headers.Add("Access-Control-Allow-Methods", "POST,GET,PUT,PATCH,DELETE,OPTIONS");
            //if (context.Request.Method == "OPTIONS")
            //{
            //    context.Response.StatusCode = (int)HttpStatusCode.OK;
            //    await context.Response.WriteAsync(string.Empty);
            //}
            var key = context.Request.Headers["secret"];
            var secretKey = _configuration["SecretKey"];
            if (!string.IsNullOrWhiteSpace(_configuration["SecretKey"])
                && !secretKey.Equals(key)
                )
            {
                int statusCode = (int)HttpStatusCode.BadRequest;
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = statusCode;
                await context.Response.WriteAsync(JsonConvert.SerializeObject("Bad request"));
                return;
            }

            //anonymousToken ??= ip.GenerateJwtToken();
            //var ipFromToken = anonymousToken?.DeToken()?.Claims.FirstOrDefault(f => f.Type == CommonConstants.CLAIM_IP)?.Value;
            //if (!string.IsNullOrEmpty( CommonConstants.CLAIM_IP)
            //    && !ip.Equals(ipFromToken)
            //    )
            //{
            //    int statusCode = (int)HttpStatusCode.Unauthorized;
            //    context.Response.ContentType = "application/json";
            //    context.Response.StatusCode = statusCode;

            //    await context.Response.WriteAsync(JsonConvert.SerializeObject("Unauthoried."));
            //    return;
            //}
            // Call the next delegate/middleware in the pipeline
            await _next(context);
            #region cmt
            //var endpoint = context.Features.Get<IEndpointFeature>()?.Endpoint;
            //var attribute = endpoint?.Metadata.GetMetadata<TokenAttribute>();
            //if (attribute != null)
            //{
            //    return;
            //}
            //var anonymousToken = context.Request.Cookies.FirstOrDefault(w => w.Key == CommonConstants.CLAIM_IP).Value;
            //var ip = _accessor.HttpContext.Connection.RemoteIpAddress.ToString();
            //var ipFromToken = anonymousToken?.DeToken()?.Claims.FirstOrDefault(f => f.Type == CommonConstants.CLAIM_IP)?.Value;
            //if (!string.IsNullOrEmpty(CommonConstants.CLAIM_IP)
            //    && !ip.Equals(ipFromToken)
            //    )
            //{
            //    int statusCode = (int)HttpStatusCode.Unauthorized;
            //    context.Response.ContentType = "application/json";
            //    context.Response.StatusCode = statusCode;

            //    await context.Response.WriteAsync(JsonConvert.SerializeObject("Unauthoried."));
            //    return;
            //}
            #endregion



        }

    }

    public class TokenAttribute : Attribute
    {

    }
}
