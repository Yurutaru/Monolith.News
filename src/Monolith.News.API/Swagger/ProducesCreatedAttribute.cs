using Microsoft.AspNetCore.Mvc;

namespace Monolith.News.API.Swagger
{
    public class ProducesCreatedAttribute : ProducesResponseTypeAttribute
    {
        public ProducesCreatedAttribute(Type responseType) : base(responseType, StatusCodes.Status201Created)
        {
        }
    }
}
