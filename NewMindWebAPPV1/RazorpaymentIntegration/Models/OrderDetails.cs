using System;


namespace RazorpaymentIntegration.Models
{
    public class OrderDetails
    {
        public Guid id { get; set; }
        public string rzp_paymentid { get; set; }

        public string rzp_orderid { get; set; }

        public string razorpay_signature { get; set; }          
    }
}
