using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DrinkMiBeer.Core.Factories;
using DrinkMiBeer.Core.Interfaces;
using DrinkMiBeer.Core.Interfaces.RepositoryInterfaces; 
using DrinkMiBeer.Core.JTOs;
using DrinkMiBeer.Core.Mappers;
using DrinkMiBeer.Core.Services;
using DrinkMiBeer.Core.Models;

namespace DrinkMiBeerWeb.Controllers
{
    public class AdminController:Controller
    {
        private IBreweryRepo _brewRepo;
        private IBuildBreweryDb _buildDB;
      
        public AdminController(IBreweryRepo brewRepo, IBuildBreweryDb buildDB)
        {
            _brewRepo = brewRepo;
          
            _buildDB = buildDB;

        }




        public async Task<IActionResult> GetDB()
        {
            var url =  _buildDB.ReturnBeerApiUrl();

            var beerJson = await _buildDB.ReturnBeerApiJTO(url);

            var csv = _buildDB.ReturnCsv();

            var beerModel = _buildDB.ReturnMappedBreweries(beerJson);
            var breweryModel = _buildDB.ReturnCompletedMappedBrewery(csv, beerModel); 

            foreach(var brewery in breweryModel)
            {

                _brewRepo.Create(brewery); 


            }

          
            return null; 
        }
    }
}
