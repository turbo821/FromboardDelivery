using System.ComponentModel.DataAnnotations;
using FromboardDelivery.Interfaces;

namespace FromboardDelivery.Models
{
    public class Calculation : IPersonal
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "От 3 до 30 символов")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "От 3 до 30 символов")]
        public string? Name { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Ваш email (@)")]
        [EmailAddress(ErrorMessage = "Ваш email (@)")]
        public string? Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "10 символов")]
        [Phone(ErrorMessage = "10 символов")]
        public string? PhoneNumber { get; set; }

        [Range(0.001, int.MaxValue, ErrorMessage = "Размер доставки")]
        [Required(ErrorMessage = "Размер доставки")]
        public double? Square { get; set; }

        [Range(0.001, int.MaxValue, ErrorMessage = "Вес доставки")]
        [Required(ErrorMessage = "Вес доставки")]
        public double? Weight { get; set; }

        [Required(ErrorMessage = "От 3 до 30 символов")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "От 3 до 30 символов")]
        public string? BuyCountry { get; set; }

        [Required(ErrorMessage = "От 3 до 30 символов")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "От 3 до 30 символов")]
        public string? BuyCity { get; set; }

        [Required(ErrorMessage = "От 3 до 30 символов")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "От 3 до 30 символов")]
        public string? DeliveryRegion { get; set; }

        [Required(ErrorMessage = "От 3 до 30 символов")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "От 3 до 30 символов")]
        public string? DeliveryCity { get; set; }

    }
}
