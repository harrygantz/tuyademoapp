using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TuYaDataAccess;
using TuYaDemo.Helpers;


namespace TuYaDemo.Controllers
{
    /// <summary>
    /// Information regarding current and past orders with tuya
    /// </summary>
    public class OrderController : ApiController
    {
        /// <summary>
        /// Returns all of the orders
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/Orders/GetAllOrders")]
        // GET: api/Order
        public IEnumerable<Order> GetAllOrders()
        {
            using (TUYAEntities context = new TUYAEntities())
            {
                return context.Orders.ToList();
            }

        }

        /// <summary>
        /// Returns a specific order based on a specific OrderId
        /// </summary>
        /// <param name="orderId">The order ID</param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/Orders/GetOrder/{orderId:int}")]
        public Order GetOrder(int orderId)
        {
            using (TUYAEntities context = new TUYAEntities())
            {
                return context.Orders.FirstOrDefault(x => x.OrderID == orderId);
            }

        }

        /// <summary>
        /// Returns all orders within 24 hours of the date that have the same order number
        /// </summary>
        /// <param name="orderId">The order number</param>
        /// <param name="completionDte">The date (string) the order was completed</param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/Orders/GetOrder/{orderId:int}/{completionDte}")]
        public Order GetOrder(int orderId, string completionDte)
        {
            var dt = FormattingHelper.GetDateTime(completionDte);
            var dtTomorrow = dt.AddDays(1);
            using (TUYAEntities context = new TUYAEntities())
            {
                return context.Orders.FirstOrDefault(x => x.OrderID == orderId && (x.CompletionDte >= dt && x.CompletionDte < dtTomorrow));
            }

        }

        /// <summary>
        /// Returns all orders within 24 hours of the date that have the specified msa and status
        /// </summary>
        /// <param name="msa"></param>
        /// <param name="status"></param>
        /// <param name="completionDte"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/Orders/GetOrder/{msa:int}/{status:int}/{completionDte}")]
        public Order GetOrder(int msa, int status, string completionDte)
        {
            var dt = FormattingHelper.GetDateTime(completionDte);
            var dtTomorrow = dt.AddDays(1);
            using (TUYAEntities context = new TUYAEntities())
            {
                return context.Orders.FirstOrDefault(x => x.MSA == msa && x.Status == status && (x.CompletionDte >= dt && x.CompletionDte < dtTomorrow));
            }

        }

    }
}
