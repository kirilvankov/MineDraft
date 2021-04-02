using System;
using System.Collections.Generic;
using System.Text;

namespace Minedraft.Models
{
    public abstract class Harvester : IHarvester
    {
        private string id;
        private double oreoutput;
        private double energyRequirement;

        protected Harvester(string id, double oreoutput, double energyRequirement)
        {
            this.Id = id;
            this.OreOutput = oreoutput;
            this.EnergyRequirement = energyRequirement;
        }
        public string Id
        {
            get
            {
                return this.id;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException($"Harvester is not registered, because of it's {nameof(Id)}");
                }
                this.id = value;
            }
        }

        public virtual double OreOutput
        {
            get
            {
                return this.oreoutput;
            }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"Harvester is not registered, because of it's {nameof(OreOutput)}");
                }
                this.oreoutput = value;
            }
        }

        public virtual double EnergyRequirement
        {
            get
            {
                return this.energyRequirement;
            }
            protected set
            {
                if (value < 0 || value > 20000)
                {
                    throw new ArgumentException($"Harvester is not registered, because of it's {nameof(EnergyRequirement)}");
                }
                this.energyRequirement = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
                sb.AppendLine($"Ore Output: {this.OreOutput}");
                sb.AppendLine($"Energy Requirement: {this.EnergyRequirement}");
            return sb.ToString().TrimEnd();
        }

    }
}
