using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Models
{
    public class SingUpViewModel
    {
        
      
        [Required(ErrorMessage = "Заполните поле")]
        [StringLength(48,
            MinimumLength = 2, ErrorMessage = "Значение {0} должно содержать не менее {2} и не более {1} символов.")]
        [DataType(DataType.Text)]
        [Display(Name = "Имя пользователя")]
        public string UserName { get; set; }
        
        [Required(ErrorMessage = "Заполните поле")]
        [StringLength(500,
            MinimumLength = 2, ErrorMessage = "Значение {0} должно содержать не менее {2} не более {1} символов.")]
        [DataType(DataType.Text)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }
    }
}