using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DrinkMiBeer.Core.Factories;
using DrinkMiBeer.Core.Interfaces;
using DrinkMiBeer.Core.JTOs;
using DrinkMiBeer.Core.Mappers;
using DrinkMiBeer.Core.Services;
using DrinkMiBeer.Core.Models;


namespace DrinkMiBeer.Api.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private IBuildBreweryDb _buildDB;
        //private IUrlBuilder _builUrl; 
        //private IBeerApiUrlBuilder _beerUrl;


        public ValuesController(IBuildBreweryDb buildDB)
        {
            //IUrlBuilder builUrl, IBeerApiUrlBuilder beerUrl,
            //_builUrl = builUrl;
            //_beerUrl = beerUrl; 
            _buildDB = buildDB;

        }
       


        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var url = _buildDB.ReturnBeerApiUrl();

            // var bleh =_buildDB.ReturnBeerApiJTO(url);
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
