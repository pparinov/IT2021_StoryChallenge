using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Challenges
{
    interface IPucturesRepository : IGenericRepository<Picture>
    {
        Task<ICollection<Picture>> GetUserPictures(Guid userId);
        Task<ICollection<Picture>> GetChallengePictures(Guid challengeId);
        Task<ICollection<Picture>> GetChapterPictures(Guid chapterId);
    }
}
