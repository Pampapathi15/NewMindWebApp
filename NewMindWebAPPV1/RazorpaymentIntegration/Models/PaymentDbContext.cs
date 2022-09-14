using Microsoft.EntityFrameworkCore;

namespace RazorpaymentIntegration.Models
{
    public class PaymentDbContext : DbContext
    {
        public DbSet<PaymentRequest> PaymentRequest { get; set; }

        public DbSet<MerchantOrder> MerchantOrders { get; set; }

        public DbSet<OrderDetails> orderDetailss { get; set; }

        public PaymentDbContext(DbContextOptions<PaymentDbContext> options) : base(options)
        { }
    }
}
