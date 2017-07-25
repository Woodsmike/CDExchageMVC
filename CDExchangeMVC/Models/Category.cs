using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CDExchangeMVC.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<CD> CDs { get; set; }
    }
}