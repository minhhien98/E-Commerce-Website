using DomainModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface ICartRepository
    {
        void bill(Bill b);
        void billdetail(BillDetail bd);
    }
}
