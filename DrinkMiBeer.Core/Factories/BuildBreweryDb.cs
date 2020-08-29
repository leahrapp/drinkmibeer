using System.Collections.Generic;
using System.Threading.Tasks; 
using DrinkMiBeer.Core.Interfaces;
using DrinkMiBeer.Core.JTOs;
using DrinkMiBeer.Core.Models;
using DrinkMiBeer.Core.Entities; 
using DrinkMiBeer.Core.Services;
using DrinkMiBeer.Core.Mappers; 
namespace DrinkMiBeer.Core.Factories
{
    public class BuildBreweryDb : IBuildBreweryDb
    {

        private IMapBoxApiUrlBuilder _buildGeoUrl;
        private IPublicApiService<BeerApiJTO> _beerApi;
        private IPublicApiService<MapBoxJTO> _geoApi;
        private IBeerApiUrlBuilder _beerUrl;
        private IMapperBase<IEnumerable<BeerApiJTO>, IList<Brewery>> _mapBrewery;
        public BuildBreweryDb(IPublicApiService<BeerApiJTO> beerApi,
            IBeerApiUrlBuilder beerUrl,
            IMapBoxApiUrlBuilder buildGeoUrl,
            IPublicApiService<MapBoxJTO> geoApi,
            IMapperBase<IEnumerable<BeerApiJTO>, IList<Brewery>> mapBrewery
            )
        {
            _mapBrewery = mapBrewery;
            _geoApi = geoApi;
            _beerApi = beerApi;
            _buildGeoUrl = buildGeoUrl;
            _beerUrl = beerUrl;
        }
        public UrlModel ReturnBeerApiUrl()
        {
            return _beerUrl.GetUrl();
        }
        public UrlModel ReturnGeoApiUrl()
        {
            return _buildGeoUrl.GetUrl();
        }

        public Task<List<BeerApiJTO>> ReturnBeerApiJTO(UrlModel url)
        {
            return _beerApi.GetApi(url);
        }
        public Task<List<MapBoxJTO>> ReturnGeoLocalApiJTO(UrlModel url)
        {
            return _geoApi.GetApi(url);
        }

        public IEnumerable<BeerApiCsvDTO> ReturnCsv()
        {
            var csv = new CsvImporter().GetCsv();
            return csv;


        }


        public IList<Brewery> ReturnMappedBreweries(IEnumerable<BeerApiJTO> beerApiJTO)
        {

            return _mapBrewery.SourceToDestination(beerApiJTO);



        }


        public IEnumerable<Brewery> ReturnCompletedMappedBrewery(IEnumerable<BeerApiCsvDTO> csv, IList<Brewery> breweries)
        {
            var breweryList = new BeerApiCsvToBreweryMapper().SourceToDestination(csv, breweries);
            return breweryList; 
        }
    }
}
