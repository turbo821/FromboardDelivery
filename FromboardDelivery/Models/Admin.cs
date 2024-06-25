using System.ComponentModel.DataAnnotations;

namespace FromboardDelivery.Models
{
    public class Admin
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        [Required(ErrorMessage = "Введите почту")]
        [EmailAddress(ErrorMessage = "Некорректный адрес")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;
        [Required(ErrorMessage = "Введите пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
    }
}
