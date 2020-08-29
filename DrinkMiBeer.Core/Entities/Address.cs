using System;
using System.Collections.Generic;
using System.Text;

namespace DrinkMiBeer.Core.Entities
{
    public class Address
    {
        public string Id { get; set; }
        public string Street { get; set; }
        public string LineTwo { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string State { get; set; }
        public string PhoneNumber { get; set; }
        public string CollectionId { get; set; }
        //public string AddressString
        //{
        //    get{ return $"{Street},{City},"


        //    } }
    }
}
