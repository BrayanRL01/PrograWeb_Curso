namespace FrontEnd.Models
{
    public class ShipperViewModel
    {
        public int ShipperId { get; set; }
        public string CompanyName { get; set; } = null!;
        public string? Phone { get; set; }
        public byte[]? Picture { get; set; }

    }
}
