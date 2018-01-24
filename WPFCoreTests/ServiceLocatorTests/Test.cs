using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFCore.ServiceLocator;
using WPFCoreTests.ServiceLocatorTests.Services;

namespace WPFCoreTests.ServiceLocatorTests
{
    [TestClass]
    public class Test
    {
        private IService1 service1 = new Service1();
        private IService2 service2 = new Service2();
        private IService3 service3 = new Service3();
        private Service4 service4 = new Service4();

        [TestInitialize]
        public void Initialize()
        {
            ServiceLocator.Instance.Clear();
        }

        [TestMethod]
        public void RegisterExistingIntances()
        {
            ServiceLocator.Instance.Register(service1);
            ServiceLocator.Instance.Register(service2);
            ServiceLocator.Instance.Register(service3);

            Assert.AreEqual(3, ServiceLocator.Instance.ServicesCount);
        }

        [TestMethod]
        public void RegisterInterfaces()
        {
            ServiceLocator.Instance.Register<IService1, Service1>();
            ServiceLocator.Instance.Register<IService2, Service2>();

            Assert.AreEqual(2, ServiceLocator.Instance.ServicesCount);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void RegisterRegisteredService()
        {
            ServiceLocator.Instance.Register(service1);
            ServiceLocator.Instance.Register(service1);
        }

        [TestMethod]
        public void RegisterWithMultipleInterfaces()
        {
            var service4 = new Service4();
            ServiceLocator.Instance.Register<IService1>(service4);
            ServiceLocator.Instance.Register<IService3>(service4);

            var s1 = ServiceLocator.Instance.Get<IService1>();
            var s2 = ServiceLocator.Instance.Get<IService3>();

            Assert.AreEqual(s1, s2);
        }

        [TestMethod]
        public void GetTheSameServiceInstance()
        {
            ServiceLocator.Instance.Register(service1);
            var s1 = ServiceLocator.Instance.Get<IService1>();
            var s2 = ServiceLocator.Instance.Get<IService1>();

            Assert.AreEqual(s1, s2);
        }

        [TestMethod]
        public void GetNewServiceInstance()
        {
            var service = new Service1();
            ServiceLocator.Instance.Register<IService1>(service);
            var s1 = ServiceLocator.Instance.Get<IService1>(true);
            var s2 = ServiceLocator.Instance.Get<IService1>(true);

            Assert.AreNotEqual(s1, s2);
        }

        [TestMethod]
        public void Unregister()
        {
            ServiceLocator.Instance.Register(service1);
            ServiceLocator.Instance.Register(service2);
            ServiceLocator.Instance.Unregister<IService1>();

            Assert.AreEqual(1, ServiceLocator.Instance.ServicesCount);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void GetUnregisteredService()
        {
            var service = ServiceLocator.Instance.Get<IService1>();
        }

        [TestMethod]
        public void ClearServices()
        {
            ServiceLocator.Instance.Register<IService1, Service1>();
            ServiceLocator.Instance.Register<IService2, Service2>();

            ServiceLocator.Instance.Clear();
            Assert.AreEqual(0, ServiceLocator.Instance.ServicesCount);
        }
    }
}
