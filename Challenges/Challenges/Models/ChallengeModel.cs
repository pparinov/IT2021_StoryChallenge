using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Challenges.Models
{
    public class ChallengeModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } //название
        public DateTime StartDate { get; set; } //дата начала
        public DateTime EndDate { get; set; } //дата окончания
        public int NumOfChapters { get; set; } //количество глав
        public int MinWordsPerChapter { get; set; } // минимальное количество слов в главе

    }
}
