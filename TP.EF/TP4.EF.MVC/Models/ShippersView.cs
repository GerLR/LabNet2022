using System.ComponentModel.DataAnnotations;

namespace TP4.EF.MVC.Models
{
    public class ShippersView
    {
        public int ShipperID { get; set; }
        [Required(ErrorMessage = "Debe indicarse un nombre de la compañía")]
        [StringLength(40, ErrorMessage = "El nombre de la empresa no debe superar los 40 caracteres")]
        public string CompanyName { get; set; }
        [StringLength(24, ErrorMessage = "El teléfono no debe superar los 40 caracteres")]
        public string Phone { get; set; }
        public string Modificar { get; set; }
    }
}