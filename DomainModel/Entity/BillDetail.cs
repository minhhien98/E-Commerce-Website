using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Entity
{
    public class BillDetail
    {
        [Key,Column(Order =1)]
        public int? BillId { get; set; }
        public Bill Bill { get; set; }

        [Key,Column(Order =2)]
        public int? ProductId { get; set; }
        public Product Product { get; set; }
        public string ProductName { get; set; }

        public int ProductQuantity { get; set; }
        public double Price { get; set; }
    }
}
