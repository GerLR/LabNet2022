using System.ComponentModel.DataAnnotations;

namespace TP4.EF.Entities
{
    public class Orders
    {
        [Key]
        public int OrderID { get; set; }
        public int? ShipVia { get; set; }

    }
}
