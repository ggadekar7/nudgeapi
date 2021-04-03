using NudgeApi.Contracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NudgeApi.Providers.ObjectProvider
{
    public class ObjectProvider : IObjectProvider
    {
        public TService GetInstance<TService>(string nameOfInstance)
        {
            return ObjectFactory.GetInstance<TService>(nameOfInstance);
        }

        public TService GetInstance<TService>()
        {
            return ObjectFactory.GetInstance<TService>();
        }
    }

    public static class ObjectFactory
    {
        private static IDependencyContainer _container;

        public static void Initialize(IContainerFactory containerFactory, IModule[] modules = null)
        {
            IEnumerable<Registration> registrations = Enumerable.Empty<Registration>();
            if (modules != null)
                registrations = ((IEnumerable<IModule>)modules).SelectMany<IModule, Registration>((Func<IModule, IEnumerable<Registration>>)(m => m.GetRegistrations()));
            ObjectFactory._container = containerFactory.CreateContainer(registrations);
        }

        public static IDependencyContainer GetContainer() => ObjectFactory._container != null ? ObjectFactory._container : throw new Exception("ObjectFactory is not intialized. Use ObjectFactory.Initialize() to setup the factory before use.");

        public static IEnumerable<object> GetAllInstances(Type serviceType) => ObjectFactory.GetContainer().GetAllInstances(serviceType);

        public static IEnumerable<TService> GetAllInstances<TService>() => ObjectFactory.GetContainer().GetAllInstances<TService>();

        public static object GetInstance(Type serviceType) => ObjectFactory.GetContainer().GetInstance(serviceType);

        public static object GetInstance(Type serviceType, string key) => ObjectFactory.GetContainer().GetInstance(serviceType, key);

        public static TService GetInstance<TService>() => ObjectFactory.GetContainer().GetInstance<TService>();

        public static TService GetInstance<TService>(string key) => ObjectFactory.GetContainer().GetInstance<TService>(key);
    }
}
