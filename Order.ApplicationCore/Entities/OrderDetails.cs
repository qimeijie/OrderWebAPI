using System.ComponentModel.DataAnnotations.Schema;

namespace Order.ApplicationCore.Entities
{
    public class OrderDetails
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int? ProductId { get; set; }
        public string? ProductName { get; set; }
        public int? Qty { get; set; }
        [Column(TypeName = "DECIMAL(5,2)")]
        public decimal? Price { get; set; }
        [Column(TypeName = "DECIMAL(5,2)")]
        public decimal? Discount { get; set; }

        public Orders Order { get; set; }
    }
}
