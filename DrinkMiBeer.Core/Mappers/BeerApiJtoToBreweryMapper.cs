using DrinkMiBeer.Core.Entities;
using DrinkMiBeer.Core.JTOs;
using DrinkMiBeer.Core.Interfaces;
using System.Collections.Generic;

namespace DrinkMiBeer.Core.Mappers
{

    public class BeerApiJtoToBreweryMapper : IMapperBase<IEnumerable<BeerApiJTO>, IList<Brewery>>
    {

        public IList<Brewery> SourceToDestination(IEnumerable<BeerApiJTO> beerJTO)
        {
            var brewList = new List<Brewery>(); 

            foreach(var item in beerJTO)
            {
                var brewery = new Brewery()
                {
                    Name = item.name,
                    BeerApiId = item.id,
                    Url = item.url,
                    LocalType = item.status,
                    BreweryAddress = new Address()
                    {
                        State = item.state,
                        Street = item.street,
                        Zip = item.zip,
                        PhoneNumber = item.phone
                    }
                   
                };
                brewList.Add(brewery); 
            }
            return brewList;

        }
    }
}