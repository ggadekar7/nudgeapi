using System;
using System.Collections.Generic;
using System.Text;

namespace NudgeApi.Providers.ObjectProvider
{
    public interface IDependencyContainer
    {
        IEnumerable<object> GetAllInstances(Type serviceType);

        IEnumerable<TService> GetAllInstances<TService>();

        object GetInstance(Type serviceType);

        object GetInstance(Type serviceType, string key);

        TService GetInstance<TService>();

        TService GetInstance<TService>(string key);
    }
}
