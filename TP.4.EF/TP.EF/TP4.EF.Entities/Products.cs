using System.ComponentModel.DataAnnotations;

namespace TP4.EF.Entities
{
    public class Products
    {
        [Key]
        public int ProductID { get; set; }
        public int? SupplierID { get; set; }

    }
}
