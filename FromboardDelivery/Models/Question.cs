using System.ComponentModel.DataAnnotations;

namespace FromboardDelivery.Models
{
    public class Question
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "От 3 до 15 символов")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "От 3 до 15 символов")]
        public string? Name { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Ваш email (@)")]
        [EmailAddress(ErrorMessage = "Ваш email (@)")]
        public string? Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "10 символов")]
        [Phone(ErrorMessage = "10 символов")]
        public string? PhoneNumber { get; set; }

        [Required(ErrorMessage = "От 3 до 30 символов")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "От 3 до 30 символов")]
        public string? Subject { get; set; }

        [Required(ErrorMessage = "Введите сообщение")]
        [StringLength(500, MinimumLength = 1, ErrorMessage = "Сообщение содержит более 500 символов")]
        public string? Message { get; set; }
    }
}
