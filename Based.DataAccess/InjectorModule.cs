using System.Data.Entity;
using Based.DataAccess.Contexts;
using Based.DataAccess.Interfaces;
using Based.DataAccess.Models;
using Ninject.Modules;

namespace Based.DataAccess
{
    public class InjectorModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IDetail>().To<Detail>();
            Bind<DbContext>().To<DemoDb>();
        }
    }
}