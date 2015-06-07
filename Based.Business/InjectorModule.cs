using Based.Business.Customers;
using Based.Business.Interfaces;
using Ninject.Modules;

namespace Based.Business
{
    public class InjectorModule : NinjectModule
    {
        public override void Load()
        {            
            Bind<ICustomerLogic>().To<CustomerLogic>();
            Bind<ICustomerDto>().To<CustomerDto>();            
        }
    }
}