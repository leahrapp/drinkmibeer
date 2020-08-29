using System;
using System.Collections.Generic;
using System.Text;

namespace DrinkMiBeer.Core.JTOs
{
   public class MapBoxJTO
    {
      
    

    public string documentation { get; set; }
        public License[] licenses { get; set; }
        public Rate rate { get; set; }
        public Result[] results { get; set; }
        public Status status { get; set; }
        public Stay_Informed stay_informed { get; set; }
        public string thanks { get; set; }
        public Timestamp timestamp { get; set; }
        public int total_results { get; set; }
    }

    public class Rate
    {
        public int limit { get; set; }
        public int remaining { get; set; }
        public int reset { get; set; }
    }

    public class Status
    {
        public int code { get; set; }
        public string message { get; set; }
    }

    public class Stay_Informed
    {
        public string blog { get; set; }
        public string twitter { get; set; }
    }

    public class Timestamp
    {
        public string created_http { get; set; }
        public int created_unix { get; set; }
    }

    public class License
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Result
    {
        public Bounds bounds { get; set; }
        public Components components { get; set; }
        public int confidence { get; set; }
        public string formatted { get; set; }
        public Geometry geometry { get; set; }
    }

    public class Bounds
    {
        public Northeast northeast { get; set; }
        public Southwest southwest { get; set; }
    }

    public class Northeast
    {
        public float lat { get; set; }
        public float lng { get; set; }
    }

    public class Southwest
    {
        public float lat { get; set; }
        public float lng { get; set; }
    }

    public class Components
    {
        public string ISO_31661_alpha2 { get; set; }
        public string ISO_31661_alpha3 { get; set; }
        public string _type { get; set; }
        public string attraction { get; set; }
        public string city { get; set; }
        public string city_district { get; set; }
        public string commercial { get; set; }
        public string continent { get; set; }
        public string country { get; set; }
        public string country_code { get; set; }
        public string house_number { get; set; }
        public string pedestrian { get; set; }
        public string political_union { get; set; }
        public string postcode { get; set; }
        public string state { get; set; }
        public string state_code { get; set; }
        public string suburb { get; set; }
    }

    public class Geometry
    {
        public float lat { get; set; }
        public float lng { get; set; }
    }

}

