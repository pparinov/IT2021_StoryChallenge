using System;
using System.Collections.Generic;
using System.Text;

namespace Challenges
{
    interface IChapterRepository : IGenericRepository<Chapter>
    {
        IEnumerable<Chapter> GetChapters(Guid challengeId); //главы в челлендже
        

    }
}
