using System;
using System.Collections.Generic;
using System.Text;

namespace Challenges
{
    interface IPucturesRepository : IGenericRepository<Picture>
    {
        IEnumerable<Picture> GetUserPictures(Guid userId);
        IEnumerable<Picture> GetChallengePictures(Guid challengeId);
        IEnumerable<Picture> GetChapterPictures(Guid chapterId);
    }
}
