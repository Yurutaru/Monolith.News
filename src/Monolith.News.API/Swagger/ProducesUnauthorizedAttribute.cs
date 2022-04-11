using Microsoft.AspNetCore.Mvc;
using Monolith.News.API.Dto;

namespace Monolith.News.API.Swagger
{
    public class ProducesUnauthorizedAttribute : ProducesResponseTypeAttribute
    {
        public ProducesUnauthorizedAttribute() : base(typeof(ErrorResult), StatusCodes.Status401Unauthorized)
        {
        }
    }
}
