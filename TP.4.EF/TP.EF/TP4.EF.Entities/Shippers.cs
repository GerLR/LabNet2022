namespace TP4.EF.Logic
{
    using System.ComponentModel.DataAnnotations;

    public partial class Shippers
    {
        [Key]
        public int ShipperID { get; set; }

        [Required(ErrorMessage ="Debe indicarse un nombre de la compañía")]
        [StringLength(40, ErrorMessage="El nombre de la empresa no debe superar los 40 caracteres")]
        public string CompanyName { get; set; }

        [StringLength(24,ErrorMessage = "El teléfono no debe superar los 40 caracteres")]
        public string Phone { get; set; }

        public override bool Equals(object o)
        {
            var result = false;
            var project = o as Shippers;
            if (project != null)
            {
                result = ShipperID == project.ShipperID;
                result &= CompanyName.Equals(project.CompanyName);
                result &= Phone.Equals(project.Phone);
                return result;
            }
            return false;
        }
    }
}
