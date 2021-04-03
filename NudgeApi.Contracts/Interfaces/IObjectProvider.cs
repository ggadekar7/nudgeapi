using System;
using System.Collections.Generic;
using System.Text;

namespace NudgeApi.Contracts.Interfaces
{
    public interface IObjectProvider
    {
        TService GetInstance<TService>(string nameOfInstance);
        TService GetInstance<TService>();
    }
}
