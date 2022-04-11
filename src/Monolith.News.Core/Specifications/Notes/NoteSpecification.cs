using Monolith.News.Domain;
using Monolith.News.Domain.Entities;

namespace Monolith.News.Core.Specifications.Notes
{
    public class NoteSpecification : BaseSpecification<Note>
    {
        public NoteSpecification()
        {
            Includes.Add(t => t.Tags);
        }
    }
}
