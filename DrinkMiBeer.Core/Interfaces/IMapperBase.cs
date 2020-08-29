using System;
using System.Collections.Generic;
using System.Text;

namespace DrinkMiBeer.Core.Interfaces
{
    public interface IMapperBase<T, U> where T : class where U : class
    {

        U SourceToDestination(T source);

    }
}
