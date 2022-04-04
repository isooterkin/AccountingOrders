using AccountingOrders.Domain.Models.Dependence;
using AccountingOrders.Domain.Tools;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#pragma warning disable CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.

namespace AccountingOrders.Domain.Models
{
    public class UserModel: ObjectWithId
    {
        [Required(ErrorMessage = "Вы должны ввести фамилию")]
        [RegularExpression(@"^[а-яА-Я]+$", ErrorMessage = "Фамилия должна содержать только буквы")]
        [StringLength(int.MaxValue, MinimumLength = 1, ErrorMessage = "Фамилия не должна быть короткой")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Вы должны ввести имя")]
        [RegularExpression(@"^[а-яА-Я]+$", ErrorMessage = "Имя должно содержать только буквы")]
        [StringLength(int.MaxValue, MinimumLength = 1, ErrorMessage = "Имя не должно быть коротким")]
        public string Name { get; set; }

        [RegularExpression(@"^[а-яА-Я]+$", ErrorMessage = "Отчество должно содержать только буквы")]
        [StringLength(int.MaxValue, MinimumLength = 1, ErrorMessage = "Отчество не должно быть коротким")]
        public string? Patronymic { get; set; }

        [Required(ErrorMessage = "Вы должны указать дату рождения")]
        public DateOnly DateOfBirth { get; set; }

        [Required(ErrorMessage = "Вы должны указать пол")]
        public GenderType Gender { get; set; }

        public int? DepartmentId { get; set; }
        [ForeignKey(nameof(DepartmentId))]
        public DepartmentModel? DepartmentModel { get; set; }
    }
}