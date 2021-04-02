namespace Minedraft.Models
{
    public interface IHarvester
    {
        double EnergyRequirement { get; }
        string Id { get; }
        double OreOutput { get; }
    }
}