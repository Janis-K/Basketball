using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Basketball.Web.ViewModels
{
    public class TeamViewModel
    {
        public int TeamId { get; set; }

        public string TeamName { get; set; }

        public string City { get; set; }

        public int CountryId { get; set; }

        public string CountryName { get; set; }
    }
}