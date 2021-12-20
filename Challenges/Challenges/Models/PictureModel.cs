using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Challenges.Models
{
    public class PictureModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ImageInBase64 { get; set; }
        public DateTime Date { get; set; }

    }
}
