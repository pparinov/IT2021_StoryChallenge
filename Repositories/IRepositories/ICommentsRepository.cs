using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Challenges
{
    interface ICommentsRepository : IGenericRepository<Comment>
    {
        Task<ICollection<Comment>> GetChapterComments(Guid chapterId);
        Task<ICollection<Comment>> GetUserComments(Guid userId);
    }
}
