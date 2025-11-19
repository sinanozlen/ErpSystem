namespace ErpSystem.API.Models
{
    public class Product
    {
        public int Id { get; set; } // Ürün Anahtarı
        public string Name { get; set; } = string.Empty; // Ürün Adı (Zorunlu)
        public string Code { get; set; } = string.Empty; // Ürün Kodu (SKU)
        public decimal UnitPrice { get; set; } // Satış Birim Fiyatı
        public string Unit { get; set; } = "Adet"; // Birim (Adet, Kilo, Metre)

        // Stok Takibi
        public decimal CurrentStock { get; set; }
    }
}