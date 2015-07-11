using System;
using System.Diagnostics;
using System.Linq;
using Based.Business.Interfaces;
using Based.DataAccess.Contexts;
using Based.DataAccess.Models;
using FluentAssertions;
using Ninject;
using SharpRepository.Ioc.Ninject;
using SharpRepository.Repository.Ioc;
using Xunit;

namespace Tests.Business
{
    public class UnitTest1
    {
        [Fact]
        public void SampleTest()
        {
            // var config = new SharpRepositoryConfiguration 
            // { 
            //    Repositories = { new EfRepositoryConfiguration("efRepository", "Data Source=DEV\\DEVELOPMENT; Initial Catalog=DemoDb; Integrated Security=True;") },
            //    CachingProviders = { },
            //    CachingStrategies =
            //    {
            //        new StandardCachingStrategyConfiguration("standardCachingStrategy", generationalCachingEnabled: true, writeThroughCachingEnabled: true),
            //        new TimeoutCachingStrategyConfiguration("timeoutCachingStrategy", 300),
            //        new NoCachingStrategyConfiguration("noCaching")
            //    }
            //}; 

            var db = new DemoDbContext();

            var t1 = db.Detail.Take(10).ToList();

            Assert.NotNull(t1);
        }

        [Fact]
        public void TestMethod1()
        {
            var kernel = new StandardKernel();
            kernel.BindSharpRepository();
            RepositoryDependencyResolver.SetDependencyResolver(new NinjectDependencyResolver(kernel));
            kernel.Load("Based.DataAccess.dll", "Based.Business.dll");

            var sut = kernel.Get<ICustomerLogic>();

            var result1 = sut.GetPage(1, 9);
           
            var result2 = sut.GetPage(2, 9);

            var result3 = sut.GetPage(3, 9);
            
            var result4 = sut.GetPage(result1.Info.TotalPages, 9);
            
            var result5 = sut.GetPage(1, 9);
            
            result1.Should().NotBeNull();
            result2.Should().NotBeNull();
            result3.Should().NotBeNull();
            result4.Should().NotBeNull();
            result5.Should().NotBeNull();

            result1.Customers.Count().Should().Be(9);
            result4.Customers.Count().Should().Be(2);
        }
    }
}
