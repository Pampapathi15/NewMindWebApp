using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using RazorpaymentIntegration.Models;

namespace RazorpaymentIntegration.Service
{
    public interface IPaymentService
    {
        Task<MerchantOrder> ProcessMerchantOrder(PaymentRequest payRequest);
        Task<string> CompleteOrderProcess(IHttpContextAccessor _httpContextAccessor);

    }
}
