using System;
using System.Collections.Generic;
using System.Text;

namespace Minedraft.Models.Providers
{
    public abstract class Provider : IProvider
    {
        private string id;
        private double energyOutput;

        protected Provider(string id, double energyOutput)
        {
            this.Id = id;
            this.EnergyOutput = energyOutput;
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
                    throw new ArgumentException($"Provider is not registered, because of it's {nameof(Id)}");
                }
                this.id = value;
            }

        }
        public virtual double EnergyOutput
        {
            get
            {
                return this.energyOutput;
            }
            protected set
            {
                if (value < 1 || value >= 10000)
                {
                    throw new ArgumentException($"Provider is not registered, because of it's {nameof(EnergyOutput)}");
                }
                this.energyOutput = value;
            }
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
                sb.AppendLine($"Energy Output: {this.EnergyOutput}");
            
            return sb.ToString().TrimEnd();
            
        }
    }
}
