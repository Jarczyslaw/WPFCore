using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFCore.ServiceLocator
{
    public interface IServiceLocator
    {
        void Register<TInterface, TService>() where TService : TInterface, new();
        void Register<T>(T serviceInstance);
        T Get<T>(bool createNew = false);
        void Clear();
        void Unregister<T>();
        int ServicesCount { get; }
    }
}
