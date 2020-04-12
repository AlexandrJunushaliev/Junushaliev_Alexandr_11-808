using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Models
{
    public class BlogViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Заполните поле")]
        [StringLength(48,
            MinimumLength = 2, ErrorMessage = "Значение {0} должно содержать не менее {2} и не более {1} символов.")]
        [DataType(DataType.Text)]
        [Display(Name = "Название блога")]
        public string BlogName { get; set; }
        
        [Required(ErrorMessage = "Заполните поле")]
        [StringLength(500,
            MinimumLength = 2, ErrorMessage = "Значение {0} должно содержать не менее {2} не более {1} символов.")]
        [DataType(DataType.Text)]
        [Display(Name = "Текст")]
        public string Text { get; set; }
    }
}