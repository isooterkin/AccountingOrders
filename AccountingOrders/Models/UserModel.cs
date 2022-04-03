using AccountingOrders.Tools;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AccountingOrders.Models
{
    public class UserModel
    {
        [Key]
        public int Id { get; set; }
        public string? Surname { get; set; }
        public string? Name { get; set; }
        public string? Patronymic { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public GenderType? Gender { get; set; }
        public int? DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public DepartmentModel? DepartmentModel { get; set; }
    }
}