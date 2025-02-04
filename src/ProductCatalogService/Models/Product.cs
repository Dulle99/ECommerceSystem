using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductCatalogService.Models
{
    public class Product
    {
        #region Fields

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }    

        public string Description { get; set; }

        [Required]
        public int Price { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Stock must be positive number")]
        public int Stock { get; set; }

        #endregion Fields

        #region Constructor
        
        public Product()
        {
            this.Price = 0;
            this.Stock = 0;
        }

        public Product(string name, string description, int price, int stock)
        {
            this.Name = name;
            this.Description = description; 
            this.Price = price;
            this.Stock = stock; 
        }

        #endregion Constructor
    }
}
