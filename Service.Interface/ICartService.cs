using DomainModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface ICartService
    {
        void AddtoCart(IEnumerable<object> cart);
        void bill(Bill b,double total, string username);
        void billdetail(BillDetail bd);
    }
}
