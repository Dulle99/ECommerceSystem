using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProductCatalogService.DTOs
{
    public class ProductDTO
    {
        #region Fields

        public string Name { get; set; }

        public string Description { get; set; }

        public int Price { get; set; }

        public int Stock { get; set; }

        #endregion Fields

        #region Constructor

        public ProductDTO(string name, string description, int price, int stock)
        {
            this.Name = name;
            this.Description = description;
            this.Price = price;
            this.Stock = stock;
        }

        #endregion Constructor
    }
}
