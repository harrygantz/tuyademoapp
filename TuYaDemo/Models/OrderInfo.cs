using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TuYaDemo.Models
{
    /// <summary>
    /// Information regarding a tuya order that has been placed
    /// </summary>
    public class OrderInfo
    {
        /// <summary>
        /// The unique ID of the order 
        /// </summary>
        [Display(Name = "Order Id")]
        [Range(1, 9999999999, ErrorMessage = "You have entered an invalid Order ID")]
        public int OrderID { get; set; }
        /// <summary>
        /// The unique ID of the shipper
        /// </summary>
        [Display(Name = "Shipper Id")]
        public int ShipperID { get; set; }
        /// <summary>
        /// The unique ID of the driver
        /// </summary>
        [Display(Name = "Driver Id")]
        public int DriverID { get; set; }
        /// <summary>
        /// The date and time of the order completion
        /// </summary>
        [Display(Name = "Completion Date")]
        public DateTime CompletionDte { get; set; }
        /// <summary>
        /// The status of the order
        /// </summary>
        [Display(Name = "Status")]
        public int Status { get; set; }
        /// <summary>
        /// The order code
        /// </summary>|
        [Display(Name = "Code")]
        public string Code { get; set; }
        /// <summary>
        /// Master Service Agreement type? (Actually not sure what this is...)
        /// </summary>
        [Display(Name = "MSA")]
        public int MSA { get; set; }
        /// <summary>
        /// The amount of time in minutes the order took to complete
        /// </summary>
        [Display(Name = "Duration")]
        public string Duration { get; set; }
        /// <summary>
        /// The offer type
        /// </summary>
        [Display(Name = "Offer Type")]
        public int OfferType { get; set; }
    }
}