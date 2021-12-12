using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Challenges
{
    interface IUserRepository : IGenericRepository<User>
    {
        Task<ICollection<User>> FindUsers(string searchString);
        Task<ICollection<User>> GetSubscribtions(Guid subscriberId);
        Task<ICollection<User>> GetSubscribers(Guid userId);
        Task<ICollection<User>> GetChallengeAuthors(Guid challengeId);
        Task<ICollection<User>> GetChapterAuthors(Guid chapterId);

    }
}
