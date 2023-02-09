using System.ComponentModel.DataAnnotations;

namespace CommentsService.Data
{
    public class Comment
    {
        public int Id { get; set; }
        [Required]
        [StringLength(140)]
        public string Content { get; set; }
        public int CreatedBy { get; set; }
        public int PostId { get; set; }
        public DateTime CreatedOn { get; set; }        
    }
}
