using AccountingOrders.Domain.Models.Dependence;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#pragma warning disable CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.

namespace AccountingOrders.Domain.Models
{
    public class OrderModel: ObjectWithId
    {
        [Required(ErrorMessage = "Вы должны ввести номер")]
        public int Number { get; set; }

        [Required(ErrorMessage = "Вы должны ввести название")]
        [RegularExpression(@"^[а-яА-Я]+$", ErrorMessage = "Название должно содержать только буквы")]
        [StringLength(int.MaxValue, MinimumLength = 1, ErrorMessage = "Название не должно быть коротким")]
        public string Name { get; set; }

        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public UserModel? UserModel { get; set; }
    }
}