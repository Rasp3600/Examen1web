using System.ComponentModel.DataAnnotations;

namespace Examen1.Models
{
    public class Supplier
    {
        [Key]
        public int SuppliersID {  get; set; }
        [StringLength(60, MinimumLength = 3)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [Display(Name = "Company Name")]
        public string ? CompanyName { get; set;}
        [StringLength(60, MinimumLength = 3)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [Display(Name = "Contact Name")]
        public int? ContactName { get; set; }
        [Display(Name = "Contact Title")]
        public string ? ContactTitle { get; set;}

        public string? Address { get; set;} 

        public string? City { get; set;}

        public string? Region { get; set;}
        [Display(Name = "Postal Code")]
        public string? PostalCode { get; set;}

        public string? Country { get; set;}

        public string? Phone { get; set;}

        public string? Fax { get; set;}
        public string? HomePage { get; set; }
    }
}
