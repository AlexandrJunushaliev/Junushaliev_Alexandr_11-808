using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Models
{
    public class CommentaryViewModel
    {
        public int CommentaryId { get; set; }
        public int BlogId { get; set; }
        [Required(ErrorMessage = "Заполните поле")]
        [StringLength(500,
            MinimumLength = 2, ErrorMessage = "Значение {0} должно содержать не менее {2} не более {1} символов.")]
        [DataType(DataType.Text)]
        [Display(Name = "Текст комментария")]
        public string Text { get; set; }
    }
}