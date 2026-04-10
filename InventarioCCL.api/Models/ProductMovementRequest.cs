namespace InventarioCCL.api.Models
{
    public class ProductMovementRequest
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string Type { get; set; } = string.Empty; // entrada o salida
    }
}
