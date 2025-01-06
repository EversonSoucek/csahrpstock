using System.ComponentModel.DataAnnotations;

namespace api.Dtos.Comment
{
    public class CreateCommentRequestDto
    {
        [Required]
        [MinLength(5, ErrorMessage ="Title must be 5 caracthers")]
        [MaxLength(280, ErrorMessage = "Title over 280")]
        public string Title { get; set; } = string.Empty;
        [Required]
        [MinLength(5, ErrorMessage ="content must be 5 caracthers")]
        [MaxLength(280, ErrorMessage = "content over 280")]
        public string Content { get; set; } = string.Empty;
    }
}