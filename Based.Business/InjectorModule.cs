using Based.Business.Customers;
using Based.Business.Interfaces;
using Based.DataAccess;
using Ninject.Modules;
using SharpRepository.Repository;

namespace Based.Business
{
    public class InjectorModule : NinjectModule
    {
        public override void Load()
        {            
            Bind<ICustomerLogic>().To<CustomerLogic>();
            Bind<ICustomerDto>().To<CustomerDto>();
            Bind<DetailRepository>().ToSelf();
        }
    }
}