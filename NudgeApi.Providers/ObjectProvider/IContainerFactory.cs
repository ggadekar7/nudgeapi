using System;
using System.Collections.Generic;
using System.Text;

namespace NudgeApi.Providers.ObjectProvider
{
    public interface IContainerFactory
    {
        [Obsolete("The method is deprecated.")]
        IDependencyContainer CreateContainer(IEnumerable<Registration> registrations);
    }
}
