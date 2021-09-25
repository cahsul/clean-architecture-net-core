﻿using FluentValidation;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Shared._.Exceptions;
using Shared._.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API._.Filters
{
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        private readonly IWebHostEnvironment _env;

        public ExceptionFilter(IWebHostEnvironment env)
        {
            _env = env;
        }

        public override void OnException(ExceptionContext context)
        {

            var type = context.Exception.GetType();

            // ValidationException fluent valiadtion
            if (type == typeof(ValidationException))
            {
                var exception = context.Exception as ValidationException;

                var validationError = new ResponseBuilder<List<string>>
                {
                    IsError = true,
                    ErrorsMessage = exception.Errors.Select(s => s.ErrorMessage).ToList()
                };

                context.Result = new BadRequestObjectResult(validationError);

                context.ExceptionHandled = true;
                return;
            }

            // BadRequestException
            if (type == typeof(BadRequestException))
            {
                var exception = context.Exception as BadRequestException;

                var badRequestException = new ResponseBuilder<List<string>>
                {
                    IsError = true,
                    ErrorsMessage = exception.ErrorsMessage.ToList()
                };

                context.Result = new BadRequestObjectResult(badRequestException);

                context.ExceptionHandled = true;
                return;
            }

            // UnauthorizedAccessException
            if (type == typeof(UnauthorizedAccessException))
            {
                var exception = context.Exception as UnauthorizedAccessException;

                var unauthorizedAccessException = new ResponseBuilder<List<string>>
                {
                    IsError = true,
                    ErrorsMessage = new List<string> { exception.Message }
                };

                if (_env.EnvironmentName.ToLower().Contains("dev"))
                {
                    unauthorizedAccessException.ErrorsMessage.Add(context.Exception.StackTrace);
                }


                context.Result = new UnauthorizedObjectResult(unauthorizedAccessException);

                context.ExceptionHandled = true;
                return;
            }


            // untuk error yang belum di handle
            var unknownError = new ResponseBuilder<List<string>>
            {
                IsError = true,
                ErrorsMessage = new List<string> { "Internal Server Error" }
            };

            if (_env.EnvironmentName.ToLower().Contains("dev"))
            {
                unknownError.ErrorsMessage.Add(context.Exception.Message);
                unknownError.ErrorsMessage.Add(context.Exception.StackTrace);
            }

            context.Result = new ObjectResult(unknownError)
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };
            context.ExceptionHandled = true;


        }

    }
}
