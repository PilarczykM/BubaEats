﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace BubaEats.Api.Common.Filter;

public class ErrorHandlingFilterAttribute : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        var exception = context.Exception;

        var problemDetails = new ProblemDetails
        {
            Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1",
            Title = "An error occurred while processing your request.",
            Status = (int?)HttpStatusCode.InternalServerError,
            Instance = context.HttpContext.Request.Path,
        };

        context.Result = new ObjectResult(problemDetails);
        context.ExceptionHandled = true;
    }
}
