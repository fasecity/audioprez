using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace audiopretzel.Models
{
    public class Music
    {
        public int Id { get; set; }
        //[Required makes properties not nullable in the database table
        [Required]
        public string Name { get; set; }
        [Required]
        public string Artist { get; set; }
        [Required]
        public string Genre { get; set; }
        //the Path property inside Models.Path has to be exactly structured like : Path = "/Tunes/almost.mp3"
        //inorder to be passed into the feild in future
        [Required]
        public string Path { get; set; }

    }
}