namespace TP4.EF.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Suppliers
    {
        // Se utlizarán 3 propiedades (CompanyName, ContactName y ContactTitle de la entidad suppliers para simplificar

        [Key]
        public int SupplierID { get; set; }

        [Required(ErrorMessage ="Debe indicarse un nombre de empresa obligatoriamente")]
        [StringLength(40, ErrorMessage = "El nombre de la empresa no debe superar los 40 caracteres")]
        public string CompanyName { get; set; }

        [StringLength(30, ErrorMessage = "El nombre del contacto no debe superar los 30 caracteres")]
        public string ContactName { get; set; }

        [StringLength(30, ErrorMessage = "El título del contacto no debe superar los 30 caracteres")]
        public string ContactTitle { get; set; }

        [StringLength(60)]
        public string Address { get; set; }

        [StringLength(15)]
        public string City { get; set; }

        [StringLength(15)]
        public string Region { get; set; }

        [StringLength(10)]
        public string PostalCode { get; set; }

        [StringLength(15)]
        public string Country { get; set; }

        [StringLength(24)]
        public string Phone { get; set; }

        [StringLength(24)]
        public string Fax { get; set; }

        [Column(TypeName = "ntext")]
        public string HomePage { get; set; }
        public override bool Equals(object o)
        {
            var result = false;
            var project = o as Suppliers;
            if (project != null)
            {
                result = SupplierID == project.SupplierID;
                result &= CompanyName.Equals(project.CompanyName);
                result &= ContactName.Equals(project.ContactName);
                result &= ContactTitle.Equals(project.ContactTitle);
                return result;
            }
            return false;
        }

        public override int GetHashCode()
        {
            int hashCode = -2143704812;
            hashCode = hashCode * -1521134295 + SupplierID.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(CompanyName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ContactName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ContactTitle);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Address);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(City);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Region);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(PostalCode);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Country);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Phone);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Fax);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(HomePage);
            return hashCode;
        }
    }
}
