using Monolith.News.Core.Dto.NoteTags;
using Monolith.News.Core.Exceptions;
using Monolith.News.Core.Helpers.Interfaces;
using Monolith.News.Core.Mappers.Interfaces;
using Monolith.News.Core.Services.Interfaces;
using Monolith.News.Domain.Entities;
using Monolith.News.Domain.Entities.Interfaces;
using Monolith.News.Domain.Interfaces;

namespace Monolith.News.Core.Services
{
    public class NoteTagService : INoteTagService
    {
        private readonly IRepository<Tag> tagRepository;
        private readonly IRepository<Note> noteRepository;
        private readonly IRepository<NoteTag> noteTagRepository;
        private readonly IUnitOfWorkFactory unitOfWorkFactory;

        private readonly INoteTagMapper noteTagMapper;
        private readonly IDateTimeProvider dateTimeProvider;


        public NoteTagService(
            IRepository<Tag> tagRepository,
            IRepository<Note> noteRepository,
            IRepository<NoteTag> noteTagRepository,
            IUnitOfWorkFactory unitOfWorkFactory,
            INoteTagMapper noteTagMapper,
            IDateTimeProvider dateTimeProvider)
        {
            this.tagRepository = tagRepository;
            this.noteRepository = noteRepository;
            this.noteTagRepository = noteTagRepository;
            this.unitOfWorkFactory = unitOfWorkFactory;
            this.noteTagMapper = noteTagMapper;
            this.dateTimeProvider = dateTimeProvider;
        }

        public async Task<NoteTagResponse> Create(int noteId, int tagId)
        {
            if (noteId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(noteId));
            }

            if (tagId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(noteId));
            }

            var note = await noteRepository.GetById(noteId);
            if (note is null)
            {
                throw new ResourceNotFoundException(nameof(note));
            }

            var tag = await tagRepository.GetById(tagId);
            if (tag is null)
            {
                throw new ResourceNotFoundException(nameof(tag));
            }

            var noteTag = new NoteTag()
            {
                NoteId = noteId,
                TagId = tagId,
                CreatedDate = dateTimeProvider.GetUtcNow()
            };

            using (var transaction = unitOfWorkFactory.BeginTransaction())
            {
                await noteTagRepository.Add(noteTag);
                await transaction.CommitAsync();
            }

            var result = noteTagMapper.Map(noteTag);

            return result;
        }

        public async Task Delete(int noteId, int tagId)
        {
            if (noteId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(noteId));
            }

            if (tagId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(noteId));
            }

            var note = await noteRepository.GetById(noteId);
            if (note is null)
            {
                throw new ResourceNotFoundException(nameof(note));
            }

            var tag = await tagRepository.GetById(tagId);
            if (tag is null)
            {
                throw new ResourceNotFoundException(nameof(tag));
            }

            var entity = await noteTagRepository.GetById(tagId);
            if (entity == null)
                throw new ResourceNotFoundException(nameof(entity));

            await noteTagRepository.Delete(entity);
        }
    }
}
