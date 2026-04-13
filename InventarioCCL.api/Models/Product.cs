using System.ComponentModel.DataAnnotations.Schema;

namespace InventarioCCL.api.Models
{
    [Table("products")]
    public class Product
    {
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
        public int quantity { get; set; }
    }
}
