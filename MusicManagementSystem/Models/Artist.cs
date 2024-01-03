using System.ComponentModel.DataAnnotations;

namespace MusicManagementSystem.Models
{
    public class Artist
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Gender { get; set; }

        //This will create a connection between Artist and Album into one to many relationship
        public ICollection<Album> Albums { get; set;}

        //This will create a connection between Artist and Song into one to many relationship
        public ICollection<Song> Songs { get; set; }
    }
}
