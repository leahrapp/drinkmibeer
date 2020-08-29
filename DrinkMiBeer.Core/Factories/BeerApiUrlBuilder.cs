using Microsoft.Extensions.Configuration; 
using DrinkMiBeer.Core.Models;
using DrinkMiBeer.Core.JTOs;
using DrinkMiBeer.Core.Interfaces; 

namespace DrinkMiBeer.Core.Factories
{
  public  class BeerApiUrlBuilder: IBeerApiUrlBuilder
    {
        private const string responseString = "/webservice/locstate/{0}/mi&s=json";
        private IConfiguration _iconfig;
        public BeerApiUrlBuilder (IConfiguration iconfig)
        {
            _iconfig = iconfig;
        }

        public UrlModel GetUrl()
        {

            PublicApiConfigJTO beerApi = _iconfig.GetSection("PublicApiConfiguration:BeerApiSettings").Get<PublicApiConfigJTO>();
            var urlBuilder = new UrlModel()
            {
                BaseUrl = beerApi.Url,
                ResponseString = string.Format(responseString, beerApi.ApiKey)
            };
            return urlBuilder;
        }

    }
}



