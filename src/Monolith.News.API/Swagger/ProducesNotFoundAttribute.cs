using Microsoft.AspNetCore.Mvc;
using Monolith.News.API.Dto;

namespace Monolith.News.API.Swagger
{
    public class ProducesNotFoundAttribute : ProducesResponseTypeAttribute
    {
        public ProducesNotFoundAttribute() : base(typeof(ErrorResult), StatusCodes.Status404NotFound)
        {
        }
    }
}
