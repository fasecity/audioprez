using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace audiopretzel.Models
{
    public class Music
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Artist { get; set; }
        public string Genre { get; set; }
        //the Path property inside Models.Path has to be exactly structured like : Path = "/Tunes/almost.mp3"
        //inorder to be passed into the feild in future
        public string Path { get; set; }

    }
}