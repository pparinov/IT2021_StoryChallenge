using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Challenges.Models
{
    public class ChapterModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } //заголовок
        public string Text { get; set; } //текст главы
        public DateTime Date { get; set; } //дата публикации

    }
}
