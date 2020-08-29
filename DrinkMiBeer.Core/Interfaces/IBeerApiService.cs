using System;
using System.Collections.Generic;
using System.Text;
using DrinkMiBeer.Core.Interfaces;
using DrinkMiBeer.Core.JTOs; 

namespace DrinkMiBeer.Core.Interfaces
{
    public interface IBeerApiService<T> : IPublicApiService<T>
    {
    }
}
