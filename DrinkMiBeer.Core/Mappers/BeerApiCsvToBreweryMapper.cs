using System;
using System.Collections.Generic;
using System.Text;
using DrinkMiBeer.Core.JTOs;
using DrinkMiBeer.Core.Entities;
using DrinkMiBeer.Core.Interfaces;
using System.Linq; 
namespace DrinkMiBeer.Core.Mappers
{
    public class BeerApiCsvToBreweryMapper 
    {
        public IList<Brewery> SourceToDestination(IEnumerable<BeerApiCsvDTO> csv, IList<Brewery> breweries)
        {

            foreach(var brew in breweries)
            {
                brew.GeoLocal.Lat = csv.FirstOrDefault(x => x.Name == brew.Name).Lat;
                brew.GeoLocal.Lng = csv.FirstOrDefault(x => x.Name == brew.Name).Lng;                

            }

            return breweries; 
        }

    }
}
