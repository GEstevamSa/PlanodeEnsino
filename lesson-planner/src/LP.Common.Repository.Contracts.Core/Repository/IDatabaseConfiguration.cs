namespace LP.Common.Repository.Contracts.Core.Repository
{
    public interface IDatabaseConfiguration
    {
        string ConnectionString { get; set; }
    }
}