using System;
using System.Collections.Generic;
using System.Text;
using DrinkMiBeer.Core.Models; 
using DrinkMiBeer.Core.Interfaces; 
namespace DrinkMiBeer.Core.Factories
{
   public class UrlBuilder
    {
        private IUrlBuilder _buildUrl;

        public UrlBuilder(IUrlBuilder buildUrl) => _buildUrl = buildUrl; 


        public UrlModel ReturnUrl()
        {

            return _buildUrl.GetUrl(); 
        }


    }
}
