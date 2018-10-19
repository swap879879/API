using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class CountryStateCity
    {
        public int CountryId { get; set; }
        public string Country { get; set; }
        public string LastUpdatedBy { get; set; }

        public int StateId { get; set; }
        public string State { get; set; }

        public int CityId { get; set; }
        public string City { get; set; }

    }
}
