
using DrinkMiBeer.Core.Entities;
using DrinkMiBeer.Core.Interfaces.RepositoryInterfaces;
using DrinkMiBeer.Infrastructure.Data;
namespace DrinkMiBeer.Infrastructure.Data.Repository
    {
    public class BreweryRepo :RepositoryBase<Brewery>, IBreweryRepo
    {
        public BreweryRepo(RepositoryContext context):base(context)
        {
          

        }

    }
}
