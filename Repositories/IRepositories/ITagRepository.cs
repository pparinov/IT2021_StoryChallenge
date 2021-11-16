using System;
using System.Collections.Generic;
using System.Text;

namespace Challenges
{
    interface ITagRepository : IGenericRepository<Tag>
    {
        IEnumerable<Tag> FindTags(string name);
        IEnumerable<Tag> GetSubscribtions(Guid userId);
        IEnumerable<Tag> GetChallengeTags(Guid challengeId);
    }
}
