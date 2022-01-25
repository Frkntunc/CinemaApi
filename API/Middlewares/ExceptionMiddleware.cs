using Core.LoggerServices.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace API.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILoggerService _loggerService;
        public ExceptionMiddleware(RequestDelegate next,ILoggerService loggerService)
        {
            _next = next;
            _loggerService = loggerService;
        }

        public async Task Invoke(HttpContext context)
        {
            var stopwacth = Stopwatch.StartNew();
            try
            {
                string message = "[Request] HTTP " + context.Request.Method + "-" + context.Request.Path;
                await _loggerService.Write(message);

                await _next(context);
                stopwacth.Stop();

                message = "[Request] HTTP " + context.Request.Method + "-" + context.Request.Path + " responded with " 
                    + context.Response.StatusCode + " code in " + stopwacth.Elapsed.TotalMilliseconds + "ms";
                await _loggerService.Write(message);
            }
            catch (Exception ex)
            {
                stopwacth.Stop();
                await HandleException(context, ex, stopwacth);
            }
        }

        private Task HandleException(HttpContext context, Exception ex, Stopwatch stopwacth)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            string message = "[Error] HTTP " + context.Request.Method + "-" + context.Response.StatusCode + "Error Message = " + ex.Message + " in " + stopwacth.Elapsed.TotalMilliseconds + "ms";
            _loggerService.Write(message);

            var result = JsonConvert.SerializeObject(new { error = ex.Message }, Formatting.None);
            return context.Response.WriteAsync(result);
        }
    }
}
