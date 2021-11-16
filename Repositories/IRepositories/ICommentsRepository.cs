using System;
using System.Collections.Generic;
using System.Text;

namespace Challenges
{
    interface ICommentsRepository : IGenericRepository<Comment>
    {
        IEnumerable<Comment> GetChapterComments(Guid chapterId);
        IEnumerable<Comment> GetUserComments(Guid userId);
    }
}
