using System;
using System.Collections.Generic;
using System.Text;
using DrinkMiBeer.Core.Models;
using DrinkMiBeer.Core.JTOs;
using System.Threading.Tasks;
using DrinkMiBeer.Core.Entities; 
namespace DrinkMiBeer.Core.Interfaces
{
    public interface IBuildBreweryDb
    {
        UrlModel ReturnBeerApiUrl();

        Task<List<BeerApiJTO>> ReturnBeerApiJTO(UrlModel url); 
        Task<List<MapBoxJTO>> ReturnGeoLocalApiJTO(UrlModel url);

        IEnumerable<BeerApiCsvDTO> ReturnCsv();
        IList<Brewery> ReturnMappedBreweries(IEnumerable<BeerApiJTO> beerApiJTO);

        IEnumerable<Brewery> ReturnCompletedMappedBrewery(IEnumerable<BeerApiCsvDTO> csv, IList<Brewery> breweries);


    }
}
