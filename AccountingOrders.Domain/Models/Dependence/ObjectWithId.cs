using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AccountingOrders.Domain.Models.Dependence
{
    public class ObjectWithId
    {
        [Key]
        public int Id { get; set; }

        [NotMapped]
        public bool IsSelected { get; set; }
    }
}