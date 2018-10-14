using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicCollection.Models
{
    /// <summary>
    /// Track model Class
    /// </summary>
    public class Track
    {
        [Key]
        public int TrackId { get; set; }
        public int BandCDId { get; set; }
        [Required(ErrorMessage = "Track Title Required")]
        public string TrackName { get; set; }

        public virtual BandCD BandCD { get; set; }
    }
}