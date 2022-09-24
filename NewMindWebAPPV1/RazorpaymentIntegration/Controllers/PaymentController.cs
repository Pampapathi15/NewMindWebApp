using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RazorpaymentIntegration.Models;
using RazorpaymentIntegration.Service;
using System;
using System.Linq;
using System.Threading.Tasks;

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
       
        public  IActionResult Index()
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
        public async Task<IActionResult> CompleteOrderProcess(RequestOrderDetails requestOrderDetails)
        {            
            string PaymentMessage = await _service.CompleteOrderProcess(_httpContextAccessor);
            if (PaymentMessage == "captured")
            {
                OrderDetails orderDetails = new OrderDetails()
                {
                    id = Guid.NewGuid(),
                    rzp_paymentid = requestOrderDetails.rzp_paymentid,
                    rzp_orderid = requestOrderDetails.rzp_orderid,
                    razorpay_signature = requestOrderDetails.razorpay_signature,
                };
                await dbContext.orderDetailss.AddAsync(orderDetails);
                await dbContext.SaveChangesAsync();
                return RedirectToAction("Success");            
            }
            else
            {
                return RedirectToAction("Failed");
            }
        }

        [HttpGet]
        public  IActionResult Success()
        {            
            var details = dbContext.orderDetailss.ToList();
            return View(details);
   
        }


        //Compare Signature between user and razorpay

        public IActionResult Failed()
        {
            return View();
        }

        [HttpGet]
        public IActionResult PaymentDetails()
        {
            var details =  dbContext.orderDetailss.ToList(); 
            return View(details);
        }

        public IActionResult Payment2()
        {
            return View();
        }
        
       
    }
}
