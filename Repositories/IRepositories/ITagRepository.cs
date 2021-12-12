using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Challenges
{
    interface ITagRepository : IGenericRepository<Tag>
    {
        Task<ICollection<Tag>> FindTags(string searchString);
        Task<ICollection<Tag>> GetSubscribtions(Guid userId);
        Task<ICollection<Tag>> GetChallengeTags(Guid challengeId);
    }
}
