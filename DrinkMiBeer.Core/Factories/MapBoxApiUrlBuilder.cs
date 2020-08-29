using Microsoft.Extensions.Configuration;
using DrinkMiBeer.Core.Models;
using DrinkMiBeer.Core.JTOs;
using DrinkMiBeer.Core.Interfaces;
namespace DrinkMiBeer.Core.Factories
{
    public class MapBoxApiUrlBuilder : IMapBoxApiUrlBuilder
    {
        private const string responseString = "/geocoding /v5/mapbox.places/{0}.json?access_token=";
        private IConfiguration _iconfig;
        public MapBoxApiUrlBuilder(IConfiguration iconfig)
        {
            _iconfig = iconfig;
        }

        public UrlModel GetUrl()
        {


            PublicApiConfigJTO geoApi = _iconfig.GetSection("PublicApiConfiguration:MapBox").Get<PublicApiConfigJTO>();
            var urlBuilder = new UrlModel()
            {
                BaseUrl = geoApi.Url,
                ResponseString = string.Format(responseString, geoApi.ApiKey)
            };
            return urlBuilder;
        }




    }
}
