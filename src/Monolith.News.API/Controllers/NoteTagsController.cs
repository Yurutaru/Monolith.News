using Microsoft.AspNetCore.Mvc;
using Monolith.News.API.Swagger;
using Monolith.News.Core.Services.Interfaces;

namespace Monolith.News.Controllers
{
    [Route("api/noteTags")]
    [ApiController]
    public class NoteTagsController : ControllerBase
    {
        private readonly INoteTagService noteTagService;

        public NoteTagsController(INoteTagService noteTagService)
        {
            this.noteTagService = noteTagService;
        }

        [HttpPost]
        [ProducesBadRequest]
        [ProducesOk]
        public async Task<IActionResult> Create(int noteId, int tagId)
        {
            var result = await noteTagService.Create(noteId, tagId);
            
            return Ok(result);
        }

        [HttpDelete("notes/{noteId:int}/tags/{tagId:int}")]
        [ProducesNotFound]
        [ProducesNoContent]
        public async Task<IActionResult> Delete(int noteId, int tagId)
        {
            await noteTagService.Delete(noteId, tagId);
            return NoContent();
        }
    }
}
