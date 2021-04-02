using Minedraft.Factories;
using Minedraft.Models;
using Minedraft.Models.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minedraft.Core
{
    public class DraftManager
    {
        private const double HalfModeEnergyRequirements = 0.6;
        private const double HalfModeOreOutput = 0.5;

        private HarvesterFactory harvesterFactory;
        private ProviderFactory providerfactory;
        private List<IHarvester> harvesters;
        private List<IProvider> providers;
        private string mode = "Full";

        private double totalEnergyStored;
        private double totalOreMined;
        public DraftManager()
        {
            this.harvesterFactory = new HarvesterFactory();
            this.providerfactory = new ProviderFactory();
            this.harvesters = new List<IHarvester>();
            this.providers = new List<IProvider>();
        }
        public string RegisterHarvester(List<string> arguments)
        {
            //TODO: Add some logic here …
            try
            {
                IHarvester harvester = this.harvesterFactory.CreateHarvester(arguments);
                this.harvesters.Add(harvester);
                return $"Successfully registered {arguments[0]} Harvester - {arguments[1]}";
            }
            catch (ArgumentException ae)
            {

                return ae.Message;
            }
        }
        public string RegisterProvider(List<string> arguments)
        {
            //TODO: Add some logic here …
            try
            {
                IProvider provider = this.providerfactory.CreateProvider(arguments);
                this.providers.Add(provider);
                return $"Successfully registered {arguments[0]} Provider - {arguments[1]}";
            }
            catch (ArgumentException ae)
            {

                return ae.Message;
            }
        }
        public string Day()
        {
            //TODO: Add some logic here …
            
            double dayEnergyProvided = this.providers.Sum(p => p.EnergyOutput);
            this.totalEnergyStored += dayEnergyProvided;
            double dayHarvesterEnergyRequirement = this.harvesters.Sum(h => h.EnergyRequirement);
            double dayOreMined = 0;
            if (this.mode == "Full" && dayHarvesterEnergyRequirement <= this.totalEnergyStored)                //check condition
            {
                this.totalEnergyStored -= dayHarvesterEnergyRequirement;
                dayOreMined = this.harvesters.Sum(h => h.OreOutput);
                this.totalOreMined += dayOreMined;
            }
            else if (this.mode == "Half" && dayHarvesterEnergyRequirement * HalfModeEnergyRequirements <= this.totalEnergyStored)
            {
                this.totalEnergyStored -= (dayHarvesterEnergyRequirement * HalfModeEnergyRequirements);
                dayOreMined = this.harvesters.Sum(h => h.OreOutput) * HalfModeOreOutput;
                this.totalOreMined += dayOreMined;
            }
            StringBuilder sb = new StringBuilder();
                        sb.AppendLine($"A day has passed.");
                        sb.AppendLine($"Energy Provided: {dayEnergyProvided}");
                        sb.AppendLine($"Plumbus Ore Mined: {dayOreMined}");
                     return sb.ToString().TrimEnd();
        }
        public string Mode(List<string> arguments)
        {
            string type = arguments[0];
            switch (type)
            {
                case "Full":
                    this.mode = type;
                    break;
                case "Half":
                    this.mode = type;
                    break;
                case "Energy":
                    this.mode = type;
                    break;
                default:
                    break;
            }
            return $"Successfully changed working mode to {this.mode} Mode";
            //TODO: Add some logic here …
        }
        public string Check(List<string> arguments)
        {
            //TODO: Add some logic here …
            string id = arguments[0];
            
            if (this.harvesters.Any(h=>h.Id == id))
            {
                IHarvester h = this.harvesters.First(x => x.Id == id);
                return h.ToString();
            }
            else if (this.providers.Any(p => p.Id == id))
            {
                IProvider p = this.providers.First(x => x.Id == id);
                return p.ToString();
            }
            else
            {
                return $"No element found with id - {id}";
            }
        }
        public string ShutDown()
        {
            //TODO: Add some logic here …
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"System Shutdown");
            sb.AppendLine($"Total Energy Stored: {this.totalEnergyStored}");
            sb.AppendLine($"Total Mined Plumbus Ore: {this.totalOreMined}");
            return sb.ToString().TrimEnd();

        }


    }
}
