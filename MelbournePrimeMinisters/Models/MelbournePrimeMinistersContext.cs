using System.Data.Entity;

namespace MelbournePrimeMinisters.Models
{
    public class MelbournePrimeMinistersContext : DbContext
    {
        public MelbournePrimeMinistersContext() : base("name=MelbournePrimeMinistersContext")
        {
        }

        public DbSet<PoliticalParty> PoliticalParties { get; set; }

        public DbSet<PrimeMinister> PrimeMinisters { get; set; }
    }
}
