using Microsoft.AspNetCore.Mvc;
using Monolith.News.API.Swagger;
using Monolith.News.Core.Dto.Notes;
using Monolith.News.Core.Services.Interfaces;

namespace Monolith.News.Controllers
{
    [Route("api/notes")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly INoteService noteService;

        public NotesController(INoteService noteService)
        {
            this.noteService = noteService;
        }

        [HttpPost]
        [ProducesBadRequest]
        [ProducesOk]
        public async Task<IActionResult> Create(NoteCreateRequest request)
        {
            var result = await noteService.Create(request);
            return Ok(result);
        }

        [HttpGet]
        [ProducesOk(typeof(IEnumerable<NoteResponse>))]
        public async Task<IActionResult> GetAll(int skip = 0, int take = 100)
        {
            var result = await noteService.GetAll(skip, take);
            return Ok(result);
        }

        [HttpGet("{noteId:int}")]
        [ProducesOk(typeof(NoteResponse))]
        [ProducesBadRequest]
        [ProducesNotFound]
        public async Task<IActionResult> Get(int noteId)
        {
            var result = await noteService.Get(noteId);
            return Ok(result);
        }

        [HttpPut("{noteId:int}")]
        [ProducesBadRequest]
        [ProducesNoContent]
        [ProducesNotFound]
        public async Task<IActionResult> Update(int noteId, NoteUpdateRequest request)
        {
            await noteService.Update(noteId, request);
            return NoContent();
        }

        [HttpDelete("{noteId:int}")]
        [ProducesNotFound]
        [ProducesNoContent]
        public async Task<IActionResult> Delete(int noteId)
        {
            await noteService.Delete(noteId);
            return NoContent();
        }
    }
}
