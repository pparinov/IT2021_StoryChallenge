using System;
using System.Collections.Generic;
using System.Text;

namespace Challenges
{
    public class Picture
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ImageInBase64 { get; set; }
        public DateTime Date { get; set; }

        
        public virtual PictureUser PictureOwner { get; set; } //"владелец"
        public virtual List<PictureChallenge> Challenges { get; set; } //челленджи
        public virtual List<PictureChapter> Chapters { get; set; } //главы
    }
}
