using System;
using System.Collections.Generic;
using System.Text;

namespace Challenges
{
    public class Chapter
    {
        public Guid Id { get; set; }
        public string Name { get; set; } //заголовок
        public string Text { get; set; } //текст главы
        public DateTime Date { get; set; } //дата публикации


        public virtual List<ChapterUser> Authors { get; set; } //авторы
        public virtual List<PictureChapter> Pictures { get; set; } //картинки
        public virtual ChapterChallenge Challenge { get; set; } //челлендж
        public virtual List<Comment> Comments { get; set; } //комментарии
    }
}
