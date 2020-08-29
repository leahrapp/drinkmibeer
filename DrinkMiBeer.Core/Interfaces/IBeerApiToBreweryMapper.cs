using System;
using System.Collections.Generic;
using System.Text;

namespace DrinkMiBeer.Core.Interfaces
{
    public interface IBeerApiToBreweryMapper<T, U> : IMapperBase<T, U> where T : class where U : class
    {
    }
}
