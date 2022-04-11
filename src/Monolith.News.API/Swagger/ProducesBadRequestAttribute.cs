using Microsoft.AspNetCore.Mvc;
using Monolith.News.API.Dto;

namespace Monolith.News.API.Swagger
{
    public class ProducesBadRequestAttribute : ProducesResponseTypeAttribute
    {
        public ProducesBadRequestAttribute() : base(typeof(ErrorResult), StatusCodes.Status400BadRequest)
        {
        }
    }
}
