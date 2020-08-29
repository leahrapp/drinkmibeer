using System;
using System.Collections.Generic;
using System.Text;

namespace DrinkMiBeer.Core.Entities
{
    public class Brewery
    {
        public int Id { get; set; }
        public int BeerApiId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string LocalType { get; set; }
        public Address BreweryAddress { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateModified { get; set; }
        public int LastModifiedBy { get; set; }
        public GeoLocation GeoLocal { get; set; }

    }
}
