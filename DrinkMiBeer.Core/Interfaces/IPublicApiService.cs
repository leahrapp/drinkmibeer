using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks; 
using DrinkMiBeer.Core.Models;
namespace DrinkMiBeer.Core.Interfaces
{
    public interface IPublicApiService<T>
    {
        Task<List<T>> GetApi(UrlModel url); 

    }
}
