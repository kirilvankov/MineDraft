using System;
using System.Collections.Generic;
using System.Text;

namespace Minedraft.Models
{
    public class SonicHarvester : Harvester
    {
        private int sonicFactor;
        public SonicHarvester(string id, double oreoutput, double energyRequirement, int sonicFactor) 
            : base(id, oreoutput, energyRequirement)
        {
            this.SonicFactor = sonicFactor;
            this.EnergyRequirement /= this.SonicFactor;
        }
        
        public int SonicFactor
        {
            get
            {
                return this.sonicFactor;
            }
            private set
            {
                if (value < 1 || value > 10)
                {
                    throw new ArgumentException($"Harvester is not registered, because of it's {nameof(SonicFactor)}");
                }
                this.sonicFactor = value;
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
                sb.AppendLine($"Sonic Harvester - {this.Id}");
                sb.AppendLine(base.ToString());
            return sb.ToString().TrimEnd();
        }
    }
}
