using DomainModel.Entity;
using Repository;
using Repository.Interface;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Service
{
    public class CartService : ICartService
    {
        private ICartRepository _repository;
        public CartService(ICartRepository cartRepository)
        {
            _repository = cartRepository;
        }
        public void AddtoCart(IEnumerable<object> cart)
        {

        }
        public void bill(Bill b, double total, string username)
        {           
            b.Date = DateTime.Now;
            b.TotalPrice = total;
            b.UserName = username;
            _repository.bill(b);
        }
        public void billdetail (BillDetail bd)
        {
            _repository.billdetail(bd);
        }
    }
}
