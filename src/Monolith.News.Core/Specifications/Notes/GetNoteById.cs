using Monolith.News.Domain;
using Monolith.News.Domain.Entities;

namespace Monolith.News.Core.Specifications.Notes
{
    public class GetNoteById : BaseSpecification<Note>
    {
        public GetNoteById(int noteId)
        {
            Criteria = note => note.Id == noteId;
            Includes.Add(t => t.Tags);
        }
    }
}
