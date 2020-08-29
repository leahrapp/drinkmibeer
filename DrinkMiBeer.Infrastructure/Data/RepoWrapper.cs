using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DrinkMiBeer.Core.Interfaces.RepositoryInterfaces;
using DrinkMiBeer.Infrastructure.Data.Repository; 

namespace DrinkMiBeer.Infrastructure.Data
{
    public class RepoWrapper : IRepoWrapper
    {
        private   RepositoryContext _context;
        private IBreweryRepo _breweryRepo; 

        public IBreweryRepo Brewery
        {
            get {
                if (_breweryRepo == null)
                {
                    _breweryRepo = new BreweryRepo(_context); 
                }
                return _breweryRepo; 
            }
        } 



        public RepoWrapper(RepositoryContext context)
        {

            _context = context; 
        }
    }
}
