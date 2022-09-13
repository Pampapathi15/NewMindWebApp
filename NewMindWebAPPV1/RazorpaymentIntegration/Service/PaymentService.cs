using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using RazorpaymentIntegration.Models;
using RazorpaymentIntegration.Service;

namespace RazorpaymentIntegration.Service
{
    public class PaymentService : IPaymentService
    {
        public Task<MerchantOrder> ProcessMerchantOrder(PaymentRequest payRequest)
        {
            try
            {
                // Generate random receipt number for order
                Random randomObj = new Random();
                string transactionId = randomObj.Next(10000000, 100000000).ToString();

                Razorpay.Api.RazorpayClient client = new Razorpay.Api.RazorpayClient("rzp_live_91Jg5cIXvomQQA", "QcyldNeXgb00x73BkJed4J0s");
                Dictionary<string, object> options = new Dictionary<string, object>();
                options.Add("amount", payRequest.Amount * 100);
                options.Add("receipt", transactionId);
                options.Add("currency", "INR");
                options.Add("payment_capture", "0");



                Razorpay.Api.Order orderResponse = client.Order.Create(options);
                string orderId = orderResponse["id"].ToString();

                MerchantOrder order = new MerchantOrder
                {
                    OrderId = orderResponse.Attributes["id"],
                    RazorpayKey = "rzp_live_91Jg5cIXvomQQA",
                    Amount = payRequest.Amount * 100,
                    Currency = "INR",
                    Name = payRequest.Name,
                    Email = payRequest.Email,
                    PhoneNumber = payRequest.PhoneNumber,
                    Address = payRequest.Address,
                    Description = "Order by Merchant"
                };
                return Task.FromResult(order);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<string> CompleteOrderProcess(IHttpContextAccessor _httpContextAccessor)
        {
            try
            {
                string paymentId = _httpContextAccessor.HttpContext.Request.Form["rzp_paymentid"];

                // This is orderId
                string orderId = _httpContextAccessor.HttpContext.Request.Form["rzp_orderid"];

               

                Razorpay.Api.RazorpayClient client = new Razorpay.Api.RazorpayClient("rzp_live_91Jg5cIXvomQQA", "QcyldNeXgb00x73BkJed4J0s");

                Razorpay.Api.Payment payment = client.Payment.Fetch(paymentId);

                // This code is for capture the payment 
                Dictionary<string, object> options = new Dictionary<string, object>();
                options.Add("amount", payment.Attributes["amount"]);
                Razorpay.Api.Payment paymentCaptured = payment.Capture(options);
                string amt = paymentCaptured.Attributes["amount"];
                return paymentCaptured.Attributes["status"];
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
