using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Examen1.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductID {  get; set; }
        [Display(Name = "Product Name")]
        [StringLength(60, MinimumLength = 3)]
        public string ? ProductName { get; set; }

        // Clave foránea para Supplier
        [ForeignKey("SupplierId")]
        public int ? SupplierID { get; set; }
        //public Supplier Supplier { get; set; }

        // Clave foránea para Category
        [ForeignKey("CategoryID")]
        public int? CategoryID { get; set; }
        //public Category Category { get; set; }
        [Display(Name = "Quantity Per Unit")]
        public int  QuantityPerUnit { get; set;}
        [Display(Name = "Unit Price")]
        public decimal? UnitPrice { get; set;}
        [Display(Name = "Units In Stock")]
        public int UnitsInStock { get; set; }
        [Display(Name = "Units On Order")]
        public int UnitsOnOrder { get; set; }
        [Display(Name = "Reorder Level")]
        public int ReorderLevel { get; set; }
        public int Discontinued { get; set; }
    }
}
