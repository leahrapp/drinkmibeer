using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DrinkMiBeer.Core.Entities;
using DrinkMiBeer.Core.JTOs;
using DrinkMiBeer.Core.Interfaces;
using DrinkMiBeer.Core.Interfaces.RepositoryInterfaces; 
using DrinkMiBeer.Core.Factories; 
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DrinkMiBeer.Web.Pages.Admin
{
    public class AdminModel : PageModel
    {
        private IBuildBreweryDb _buildBreweries;
        private IBreweryRepo _brewRepo; 
        public AdminModel(IBuildBreweryDb buildBreweries, IBreweryRepo brewRepo)
        {
            _brewRepo = brewRepo;
            _buildBreweries = buildBreweries; 

        }

        public void OnGet()
        {

        }

        public async void OnUpdate()
        {

            var apiUrl = _buildBreweries.ReturnBeerApiUrl();
            var breweryJson = await _buildBreweries.ReturnBeerApiJTO(apiUrl);
            var coorCsv = _buildBreweries.ReturnCsv();

            var breweryEnt =_buildBreweries.ReturnMappedBreweries(breweryJson);

            var final = _buildBreweries.ReturnCompletedMappedBrewery(coorCsv, breweryEnt); 

            foreach(var fin in final)
            {

                _brewRepo.Create(fin); 


            }
        }
    }
}