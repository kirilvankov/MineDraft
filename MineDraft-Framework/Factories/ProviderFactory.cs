using Minedraft.Models.Providers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Minedraft.Factories
{
    public class ProviderFactory
    {
        public IProvider CreateProvider(List<string> args)
        {
            IProvider provider = null;
            if (args[0] == "Pressure")
            {
                provider = new PressureProvider(args[1], float.Parse(args[2]));
            }
            else if (args[0] == "Solar")
            {
                provider = new SolarProvider(args[1], float.Parse(args[2]));
            }
            return provider;
        }
    }
}
