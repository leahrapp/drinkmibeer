using System;
using System.Collections.Generic;
using System.Text;

namespace DrinkMiBeer.Core.JTOs
{
   public class BeerApiCsvDTO
    {
        //I only need the lat and longitute from the CSV but the column# has to match for import
        public string Lng { get; set; }
        public string Lat { get; set; }
     
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Phone { get; set; }
        public string LocationType { get; set; }
        public string Score { get; set;  }
    }
}
