using Monolith.News.Core.Dto.Tags;
using Monolith.News.Core.Exceptions;
using Monolith.News.Core.Mappers.Interfaces;
using Monolith.News.Core.Specifications.Categories;
using Monolith.News.Domain.Entities;
using Monolith.News.Domain.Entities.Interfaces;
using Monolith.News.Domain.Interfaces;

namespace Monolith.News.Core.Services
{
    public class TagService : ITagService
    {
        private readonly ITagMapper tagMapper;
        private readonly IRepository<Tag> tagRepository;
        private readonly IUnitOfWorkFactory unitOfWorkFactory;

        public TagService(ITagMapper tagMapper,
            IRepository<Tag> tagRepository,
            IUnitOfWorkFactory unitOfWorkFactory)
        {
            this.tagMapper = tagMapper;
            this.tagRepository = tagRepository;
            this.unitOfWorkFactory = unitOfWorkFactory;
        }

        public async Task<TagResponse> Create(TagCreateRequest request)
        {
            ArgumentNullException.ThrowIfNull(nameof(request));

            if (string.IsNullOrWhiteSpace(request.Name))
            {
                throw new ValidationException("Tag can't be null and length should be equal to 3 or more");
            }

            if (request.Name.Length < 3)
            {
                throw new ValidationException("Tag can't be null and length should be equal to 3 or more");
            }

            // should be validator for this

            var tag = tagMapper.Map(request);

            using (var transaction = unitOfWorkFactory.BeginTransaction())
            {
                await tagRepository.Add(tag);
                await transaction.CommitAsync();
            }

            var result = tagMapper.Map(tag);

            return result;
        }

        public async Task Delete(int tagId)
        {
            if (tagId < 0)
                throw new ArgumentOutOfRangeException(nameof(tagId));

            var entity = await tagRepository.GetById(tagId);
            if (entity == null)
                throw new ResourceNotFoundException(nameof(entity));

            await tagRepository.Delete(entity);
        }

        public async Task<IEnumerable<TagResponse>> GetAll(int skip = 0, int take = 100)
        {
            var specification = new TagSpecification();

            var tags = await tagRepository.List(specification, skip, take);

            var result = tagMapper.MapCollection(tags);
            return result;
        }

        public async Task<TagResponse> Get(int tagId)
        {
            if (tagId < 0)
                throw new ArgumentOutOfRangeException(nameof(tagId));

            var tag = await tagRepository.GetById(tagId);
            if (tag == null)
                throw new ResourceNotFoundException(nameof(tag));

            var result = tagMapper.Map(tag);

            return result;
        }

        public async Task Update(int tagId, TagUpdateRequest request)
        {
            if (tagId < 0)
                throw new ArgumentOutOfRangeException(nameof(tagId));

            if (request == null)
                throw new ArgumentNullException(nameof(request));

            if (tagId != request.Id)
            {
                throw new ValidationException("tag identifier in request and in route is not identical");
            }

            var entity = await tagRepository.GetById(tagId);
            if (entity == null)
                throw new ResourceNotFoundException(nameof(entity));

            entity.Name = request.Name;
            entity.BackgroundColor = request.BackgroundColor;
            entity.Color = request.Color;

            await tagRepository.Update(entity);
        }
    }
}
