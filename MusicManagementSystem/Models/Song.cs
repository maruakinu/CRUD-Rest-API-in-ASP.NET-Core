using System.ComponentModel.DataAnnotations;

namespace MusicManagementSystem.Models
{
    public class Song
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is Required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Language is Required")]
        public string Language { get; set; }

        [Required(ErrorMessage = "Duration is Required")]
        public string Duration { get; set; }
    }
}
