using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MusicStoreAPI.Models
{
    [Table("Album")]
    public class Album
    {
        [Key]
        public int AlbumId { get; set; }
        [Required]
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int ArtistId { get; set; }
        public int GenreId { get; set; }
    }
}
