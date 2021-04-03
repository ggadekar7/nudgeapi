using System;
using System.Collections.Generic;
using System.Text;

namespace NudgeApi.Providers.ObjectProvider
{
    public interface IModule
    {
        IEnumerable<Registration> GetRegistrations();
    }
}
