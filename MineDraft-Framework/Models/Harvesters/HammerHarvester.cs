using System;
using System.Collections.Generic;
using System.Text;

namespace Minedraft.Models
{
    public class HammerHarvester : Harvester
    {
        

        public HammerHarvester(string id, double oreoutput, double energyRequirement)
            : base(id, oreoutput, energyRequirement)
        {
        }
        public override double OreOutput
        {
            get
            {
                return base.OreOutput;
            }
            protected set
            {
                base.OreOutput = value += (value * 2);
            }
        }
        public override double EnergyRequirement
        {

            get
            {
                return base.EnergyRequirement;
            }

            protected set
            {
                base.EnergyRequirement = value *= 2;
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
                sb.AppendLine($"Hammer Harvester - {this.Id}");
                sb.AppendLine(base.ToString());
            return sb.ToString().TrimEnd();
        }
    }
}
