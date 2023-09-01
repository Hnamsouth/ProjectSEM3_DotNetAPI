
using System;
using PayPalCheckoutSdk.Core;
using PayPalCheckoutSdk.Orders;
using PayPalHttp;
using System.Collections.Generic;
using System.Threading.Tasks;
using HttpResponse = PayPalHttp.HttpResponse;
using PayPalCheckoutSdk.Payments;

namespace ProjectSEM3.Services
{
    public class Paypal
    {
        private static readonly string ClientId = "ARhIk8S1SjumPvjUXqmKwGEGHXs7sy3qnhYMOkOdiC51L3yzfIT6Py5ZgLWkjlhf8JZGcaK1KSYzg-vb";
        private static readonly string ClientSecret = "EIPSozcM0zEzaQbefYRK4Jumr9QmUD9QQua8xpviTQsUQYvF9kJb-QqFGmTp5NDYUn5-iiaRtr5OGIhU";

         public static PayPalHttp.HttpClient client()
        {
            // Creating a sandbox environment
            PayPalEnvironment environment = new SandboxEnvironment(ClientId, ClientSecret);

            // Creating a client for the environment
            PayPalHttpClient client = new PayPalHttpClient(environment);

            return client;
        }

        async public static  Task<object> RefundOrder(string orderId)
        {
            try
            {
                Order rs = await GetOrder(orderId);
                var captureId = rs.PurchaseUnits.FirstOrDefault().Payments.Captures.FirstOrDefault().Id;
                var tf = new CapturesRefundRequest(captureId);

                RefundRequest refund = new RefundRequest
                {
                    Amount = new PayPalCheckoutSdk.Payments.Money
                    {
                        CurrencyCode = rs.PurchaseUnits.FirstOrDefault().AmountWithBreakdown.CurrencyCode,
                        Value = rs.PurchaseUnits.FirstOrDefault().AmountWithBreakdown.Value
                    },
                    InvoiceId = rs.PurchaseUnits.FirstOrDefault().InvoiceId,
                    NoteToPayer = rs.Payer.PayerId
                };
                // add request
                var rsa = tf.RequestBody(refund);
                // execute 
                var rs2 = await client().Execute(rsa);

                return new { rsa, rs2 };
            }
            catch (Exception ex)
            {
                return null;
            }
            
        }

        public async static Task<Order> GetOrder(string? orderId)
        {
            OrdersGetRequest request = new OrdersGetRequest(orderId);
            

            var response = await client().Execute(request);
            Order result = response.Result<Order>();
                
            return result;
        }


    }
}
