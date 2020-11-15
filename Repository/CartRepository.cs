using DomainModel.Entity;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CartRepository : ICartRepository
    {
        private DatabaseContext _context;
        public CartRepository(DatabaseContext context)
        {
            _context = context;
        }
        public void bill(Bill b)
        {
            _context.Bills.Add(b);            
            _context.SaveChanges();
        }
        public void billdetail(BillDetail bd)
        {
            _context.BillDetails.Add(bd);
            _context.SaveChanges();
        }
    }
}
