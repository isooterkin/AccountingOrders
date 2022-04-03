using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingOrders.Models
{
    public class DepartmentModel
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? UserId { get; set; }
        [ForeignKey("UserId")]
        public UserModel? UserModel { get; set; }
    }
}