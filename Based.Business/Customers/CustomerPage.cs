using System.Collections.Generic;
using Based.Business.Interfaces;

namespace Based.Business.Customers
{
    public class CustomerPage : ICustomerPage
    {
        public IInfo Info { get; set; }
        public IEnumerable<ICustomerDto> Customers { get; set; }
    }
}
