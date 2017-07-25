using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CDExchangeMVC.Models
{
    public class Checkout
    {
        [Key]
        public int Id { get; set; }
        public string ReceiptNumber { get; set; }
        public float Amount { get; set; }
        public DateTime CheckoutDate { get; set; }

        public virtual ICollection<CD> CDs { get; set; }

        [ForeignKey("Customer")]
        public int CustomerID { get; set; }
        public virtual Customer Customer { get; set; }
    }
}