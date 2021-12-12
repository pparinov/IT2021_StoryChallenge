using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Challenges
{
    public class Comment
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }

        
        public virtual User User { get; set; } //"автор"
        public virtual Chapter Chapter { get; set; }  //глава
    }
}
