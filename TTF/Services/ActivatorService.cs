using System;

namespace TTF.Services
{
    public class ActivatorService : IActivatorService
    {
        public object Create(Type type, params object[] args)
        {
            return Activator.CreateInstance(type, args);
        }
    }
}
