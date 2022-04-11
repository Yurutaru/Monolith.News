using Microsoft.AspNetCore.Mvc;

namespace Monolith.News.API.Swagger
{
    public class ProducesNoContentAttribute : ProducesResponseTypeAttribute
    {
        public ProducesNoContentAttribute() : base(StatusCodes.Status204NoContent)
        {
        }
    }
}
