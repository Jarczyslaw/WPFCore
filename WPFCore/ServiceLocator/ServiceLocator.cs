using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFCore.ServiceLocator
{
    public sealed class ServiceLocator : IServiceLocator
    {
        private static readonly Lazy<ServiceLocator> instance = new Lazy<ServiceLocator>(() => new ServiceLocator(), true);
        public static ServiceLocator Instance
        {
            get
            {
                return instance.Value;
            }
        }

        private Dictionary<Type, Type> services;
        private Dictionary<Type, object> instances;

        public int ServicesCount
        {
            get { return services.Count; }
        }

        private ServiceLocator()
        {
            services = new Dictionary<Type, Type>();
            instances = new Dictionary<Type, object>();
        }

        public void Register<TInterface, TService>() 
            where TService : TInterface, new()
        {
            var newType = typeof(TInterface);
            CheckExistingType(newType);

            services.Add(newType, typeof(TService));
        }

        public void Register<T>(T serviceInstance)
        {
            var newType = typeof(T);
            CheckExistingType(newType);

            services.Add(newType, serviceInstance.GetType());
            instances.Add(newType, serviceInstance);
        }

        public void Unregister<T>()
        {
            var type = typeof(T);
            if (services.ContainsKey(type))
                services.Remove(type);

            if (instances.ContainsKey(type))
                instances.Remove(type);
        }

        public T Get<T>(bool createNew = false)
        {
            var requestedType = typeof(T);
            if (!services.ContainsKey(requestedType))
                throw new Exception(string.Format("Can not get {0} because it is not registered yet", requestedType.Name));

            var targetType = services[requestedType];
            if (createNew)
                return (T)Activator.CreateInstance(targetType);
            else
            {
                if (instances.ContainsKey(requestedType))
                    return (T)instances[requestedType];
                else
                {
                    var newInstance = (T)Activator.CreateInstance(targetType);
                    instances.Add(requestedType, newInstance);
                    return newInstance;
                }
            }
        }

        public void Clear()
        {
            services.Clear();
            instances.Clear();
        }

        private void CheckExistingType(Type type)
        {
            if (services.ContainsKey(type))
                throw new Exception(string.Format("Can not register {0} because it is already registered", type.Name));
        }
    }
}
