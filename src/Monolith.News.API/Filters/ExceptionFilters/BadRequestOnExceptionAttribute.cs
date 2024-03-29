﻿namespace Monolith.News.API.Filters.ExceptionFilters
{
    public class BadRequestOnExceptionAttribute : HttpStatusCodeOnExceptionAttribute
    {
        public BadRequestOnExceptionAttribute(params Type[] exceptionTypes)
            : base(StatusCodes.Status400BadRequest, exceptionTypes)
        {
        }
    }
}
