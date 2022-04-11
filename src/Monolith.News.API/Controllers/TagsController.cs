using Microsoft.AspNetCore.Mvc;
using Monolith.News.API.Swagger;
using Monolith.News.Core.Dto.Tags;
using Monolith.News.Core.Services;

namespace Monolith.News.API.Controllers
{
    [Route("api/tags")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly ITagService tagService;

        public TagsController(ITagService tagService)
        {
            this.tagService = tagService;
        }

        [HttpPost]
        [ProducesBadRequest]
        [ProducesOk]
        public async Task<IActionResult> Create(TagCreateRequest request)
        {
            var result = await tagService.Create(request);
            return Ok(result);
        }

        [HttpGet]
        [ProducesOk(typeof(IEnumerable<TagResponse>))]
        public async Task<IActionResult> GetAll(int skip = 0, int take = 100)
        {
            var result = await tagService.GetAll(skip, take);
            return Ok(result);
        }

        [HttpGet("{tagId:int}")]
        [ProducesOk(typeof(TagResponse))]
        [ProducesBadRequest]
        [ProducesNotFound]
        public async Task<IActionResult> Get(int tagId)
        {
            var result = await tagService.Get(tagId);
            return Ok(result);
        }

        [HttpPut("{tagId:int}")]
        [ProducesBadRequest]
        [ProducesNoContent]
        [ProducesNotFound]
        public async Task<IActionResult> Update(int tagId, TagUpdateRequest request)
        {
            await tagService.Update(tagId, request);
            return NoContent();
        }

        [HttpDelete("{tagId:int}")]
        [ProducesNotFound]
        [ProducesNoContent]
        public async Task<IActionResult> Delete(int tagId)
        {
            await tagService.Delete(tagId);
            return NoContent();
        }
    }
}
