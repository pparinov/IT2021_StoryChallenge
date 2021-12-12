using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Challenges
{
    interface IChapterRepository : IGenericRepository<Chapter>
    {
        Task<ICollection<Chapter>> GetChapters(Guid challengeId); //главы в челлендже
        

    }
}
