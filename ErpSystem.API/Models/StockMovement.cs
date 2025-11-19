using System.ComponentModel.DataAnnotations.Schema;

namespace ErpSystem.API.Models
{
    public class StockMovement
    {
        public int Id { get; set; }
        
        // İlişki: Hangi ürünün stoğu
        public int ProductId { get; set; } 
        [ForeignKey("ProductId")]
        public Product Product { get; set; } = null!;

        public DateTime Date { get; set; } = DateTime.Now;
        public decimal Quantity { get; set; } // Miktar
        public string Type { get; set; } = string.Empty; // Giriş, Çıkış, Sayım
        public string DocumentNumber { get; set; } = string.Empty; // Fatura/İrsaliye No
    }
}