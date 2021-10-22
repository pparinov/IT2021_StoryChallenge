using System;
using System.Collections.Generic;
using System.Text;

namespace Challenges
{
    public class Challenge
    {
        public Guid Id { get; set; }
        public string Name { get; set; } //название
        public DateTime StartDate { get; set; } //дата начала
        public DateTime EndDate { get; set; } //дата окончания
        public int NumOfChapters { get; set; } //количество глав
        public int MinWordsPerChapter { get; set; } // минимальное количество слов в главе


        public virtual List<ChallengeUser> Challengers { get; set; } //участники
        public virtual List<ChallengeSubscription> Subscribers { get; set; } //подписчики
        public virtual List<TagChallenge> TagChallenges { get; set; } //тэги
        public virtual List<ChapterChallenge> Chapters { get; set; } //главы
        public virtual List<PictureChallenge> Pictures { get; set; } //картинки

    }
}
