using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicCollection.Models
{
    /// <summary>
    /// BandCD model Class
    /// </summary>
    public class BandCD
    {
    
        [Key]
        public int BandCDId { get; set; }
        [Required(ErrorMessage = "Band Name Required")]
        public string BandName { get; set; }
        [Required(ErrorMessage = "Album Name Required")]
        public string AlbumName { get; set; }

        public virtual ICollection<Track> Track { get; set; }

    }
}