using System.ComponentModel.DataAnnotations;

namespace MusicManagementSystem.Models
{
    public class Song
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Language { get; set; }
    }
}
