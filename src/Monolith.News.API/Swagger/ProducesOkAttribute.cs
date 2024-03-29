﻿using Microsoft.AspNetCore.Mvc;

namespace Monolith.News.API.Swagger
{
    public class ProducesOkAttribute : ProducesResponseTypeAttribute
    {
        public ProducesOkAttribute() : base(StatusCodes.Status200OK)
        {
        }

        public ProducesOkAttribute(Type responseType) : base(responseType, StatusCodes.Status200OK)
        {
        }
    }
}
