using System.ComponentModel.DataAnnotations;

namespace MusicManagementSystem.Models
{
    public class Album
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public int ArtistId { get; set; }

        //This will create a connection between Album and Song into one to many relationship
        public ICollection<Song> Songs { get; set; }
    }
}
