using System;
using System.Collections.Generic;
using System.Text;
using DrinkMiBeer.Core.Models;
namespace DrinkMiBeer.Core.Interfaces
{
    public interface IUrlBuilder
    {
        UrlModel GetUrl(); 
    }
}
