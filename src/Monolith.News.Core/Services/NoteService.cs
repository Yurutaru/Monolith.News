using Monolith.News.Core.Dto.Notes;
using Monolith.News.Core.Exceptions;
using Monolith.News.Core.Mappers.Interfaces;
using Monolith.News.Core.Services.Interfaces;
using Monolith.News.Core.Specifications.Notes;
using Monolith.News.Core.Specifications.Tags;
using Monolith.News.Domain.Entities;
using Monolith.News.Domain.Entities.Interfaces;
using Monolith.News.Domain.Interfaces;

namespace Monolith.News.Core.Services
{
    public class NoteService : INoteService
    {
        private readonly IUnitOfWorkFactory unitOfWorkFactory;
        private readonly IRepository<Note> noteRepository;
        private readonly IRepository<Tag> tagRepository;
        private readonly INoteMapper noteMapper;

        public NoteService(IUnitOfWorkFactory unitOfWorkFactory,
            IRepository<Note> noteRepository,
            IRepository<Tag> tagRepository,
            INoteMapper noteMapper)
        {
            this.unitOfWorkFactory = unitOfWorkFactory;
            this.noteRepository = noteRepository;
            this.tagRepository = tagRepository;
            this.noteMapper = noteMapper;
        }

        public async Task<NoteResponse> Create(NoteCreateRequest request)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var requestTags = request.Tags ?? Array.Empty<int>();

            var tags = await tagRepository.List(new GetTagsById(requestTags), 0, requestTags.Length);
            if (tags.Length != requestTags.Length)
            {
                throw new ValidationException("Some tags with ids (There are should be ids) are incorrect");
            }

            var note = noteMapper.Map(request);

            var noteTags = tags.Select(tag => new NoteTag() { NoteId = note.Id, TagId = tag.Id }).ToList();
            note.NoteTags = noteTags;

            using (var transaction = unitOfWorkFactory.BeginTransaction())
            {
                await noteRepository.Add(note);
                await transaction.CommitAsync();
            }

            var result = noteMapper.Map(note);

            return result;
        }

        public async Task Delete(int noteId)
        {
            if (noteId < 0)
                throw new ArgumentOutOfRangeException(nameof(noteId));

            var entity = await noteRepository.GetById(noteId);
            if (entity == null)
                throw new ResourceNotFoundException(nameof(entity));

            await noteRepository.Delete(entity);
        }

        public async Task<NoteResponse> Get(int noteId)
        {
            if (noteId < 0)
                throw new ArgumentOutOfRangeException(nameof(noteId));

            var tag = await noteRepository.Get(new GetNoteById(noteId));
            if (tag == null)
                throw new ResourceNotFoundException(nameof(tag));

            var result = noteMapper.Map(tag);

            return result;
        }

        public async Task<IEnumerable<NoteResponse>> GetAll(int skip = 0, int take = 100)
        {
            var specification = new NoteSpecification();

            var notes = await noteRepository.List(specification, skip, take);

            var result = noteMapper.MapCollection(notes);
            return result;
        }

        public async Task Update(int noteId, NoteUpdateRequest request)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var requestTags = request.Tags ?? Array.Empty<int>();

            var tags = await tagRepository.List(new GetTagsById(requestTags), 0, requestTags.Length);
            if (tags.Length != requestTags.Length)
            {
                throw new ValidationException("Some tags with ids (There are should be ids) are incorrect");
            }

            var note = await noteRepository.Get(new GetNoteById(noteId));
            if (note is null)
            {
                throw new ResourceNotFoundException(nameof(note));
            }

            var noteTags = tags.Select(tag => new NoteTag() { NoteId = note.Id, TagId = tag.Id }).ToList();

            using (var transaction = unitOfWorkFactory.BeginTransaction())
            {
                note.Subject = request.Subject;
                note.Body = request.Body;
                note.NoteTags = noteTags;

                await noteRepository.Update(note);
                await transaction.CommitAsync();
            }
        }
    }
}
