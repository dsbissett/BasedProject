using System.Collections.Generic;

namespace Based.Business.Interfaces
{
    public interface ICustomerPage
    {
        IInfo Info { get; set; }
        IEnumerable<ICustomerDto> Customers { get; set; }
    }
}