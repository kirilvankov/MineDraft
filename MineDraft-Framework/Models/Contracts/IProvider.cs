namespace Minedraft.Models.Providers
{
    public interface IProvider
    {
        double EnergyOutput { get; }
        string Id { get; }
    }
}