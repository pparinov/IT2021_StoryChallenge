using System;
using System.Collections.Generic;
using System.Text;

namespace Challenges
{
    interface IUserRepository : IGenericRepository<User>
    {
        IEnumerable<User> FindUsers(string searchString);
        IEnumerable<User> GetSubscribtions(Guid subscriberId);
        IEnumerable<User> GetSubscribers(Guid userId);
        IEnumerable<User> GetChallengeAuthors(Guid challengeId);
        IEnumerable<User> GetChapterAuthors(Guid chapterId);

    }
}
