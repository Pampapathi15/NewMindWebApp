using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using RazorpaymentIntegration.Models;
using RazorpaymentIntegration.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;


namespace RazorpaymentIntegration.Controllers
{
    public class PaymentController : Controller
    {
        private readonly PaymentDbContext dbContext;

       /*  public PaymentController(PaymentDbContext dbContext)
        {
            this.dbContext = dbContext;
        } */

        private readonly ILogger<PaymentController> _logger;
        private readonly IPaymentService _service;
        private IHttpContextAccessor _httpContextAccessor;
        public PaymentController(ILogger<PaymentController> logger, IPaymentService service, IHttpContextAccessor httpContextAccessor, PaymentDbContext dbContext)
        {
            _logger = logger;
            _service = service;
            _httpContextAccessor = httpContextAccessor;
            this.dbContext = dbContext;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ProcessRequestOrder(PaymentRequest _paymentRequest)
        {
            MerchantOrder _marchantOrder = await _service.ProcessMerchantOrder(_paymentRequest);
            return View("Payment", _marchantOrder);
        }
        [HttpPost]
        public async Task<IActionResult> CompleteOrderProcess()
        {
            string PaymentMessage = await _service.CompleteOrderProcess(_httpContextAccessor);
           

            if (PaymentMessage == "captured")
            {              
                return RedirectToAction("Success");
             
            }
            else
            {
                return RedirectToAction("Failed");
            }
        }
        public async Task<IActionResult> Success(RequestOrderDetails requestOrderDetails)
        {
            var orderDetails = new OrderDetails()
            {
                id = Guid.NewGuid(),
                rzp_paymentid = requestOrderDetails.rzp_paymentid,
                rzp_orderid = requestOrderDetails.rzp_orderid,
                razorpay_signature = requestOrderDetails.razorpay_signature,
            };
            await dbContext.orderDetailss.AddAsync(orderDetails);
            await dbContext.SaveChangesAsync();
           
            return Ok(orderDetails);
        }

        public IActionResult Failed()
        {
            return View();
        }
    }
}
