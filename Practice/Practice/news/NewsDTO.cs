using System.ComponentModel.DataAnnotations;

namespace Practice.news
{
    public class NewsCreateDTO
    {
        [Required]
        [MinLength(10)]
        public string Title { get; set; }
        [Required]
        [MinLength(30)]
        public string Content { get; set; }
    }
}
