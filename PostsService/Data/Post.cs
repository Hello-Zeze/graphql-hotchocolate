using System.ComponentModel.DataAnnotations;

namespace PostsService.Data
{
    public class Post
    {
        public int Id { get; set; }
        [Required]
        [StringLength(140)]
        public string Content { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }        
    }
}
