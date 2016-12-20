using System;

namespace TTF.Services
{
    public interface IActivatorService
    {
        object Create(Type type, params object[] args);
    }
}
