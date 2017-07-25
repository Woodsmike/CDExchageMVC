using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CDExchangeMVC.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string CreditCard { get; set; }
        public virtual ICollection<CD> CDs { get; set; }
        public virtual ICollection<Checkout> Checkouts { get; set; }
    }
}