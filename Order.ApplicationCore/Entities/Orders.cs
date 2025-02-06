using System.ComponentModel.DataAnnotations.Schema;

namespace Order.ApplicationCore.Entities
{
    public class Orders
    {
        public int Id { get; set; }
        public DateTime? OrderDate { get; set; }
        public int CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public int? PaymentMethodId { get; set; }
        public string? PaymentName { get; set; }
        public string? ShippingAddress { get; set; }
        public string? ShippingMethod {  get; set; }
        [Column(TypeName = "DECIMAL(18,4)")]
        public decimal? BillAmount { get; set; }
        public string? OrderStatus { get; set; }
    }
}
