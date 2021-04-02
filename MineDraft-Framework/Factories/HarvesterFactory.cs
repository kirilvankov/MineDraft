using Minedraft.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Minedraft.Factories
{
    public class HarvesterFactory
    {
        public IHarvester CreateHarvester(List<string> args)
        {
            IHarvester harvester = null;
            if (args[0] == "Hammer")
            {
                harvester = new HammerHarvester(args[1], float.Parse(args[2]), float.Parse(args[3]));
            }
            else if (args[0] == "Sonic")
            {
                harvester = new SonicHarvester(args[1], float.Parse(args[2]), float.Parse(args[3]), int.Parse(args[4]));
            }
            return harvester;
        }
    }
}
