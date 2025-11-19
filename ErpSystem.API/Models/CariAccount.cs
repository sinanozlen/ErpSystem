namespace ErpSystem.API.Models
{
    public class CariAccount
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string AccountType { get; set; } = "Müşteri"; 
        public string TaxId { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public decimal Balance { get; set; }
    }
}
