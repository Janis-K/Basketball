using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Basketball.Web.ViewModels
{
    public class TeamCountryViewModel
    {
        public IEnumerable<TeamViewModel> Teams { get; set; }
        
        public IEnumerable<CountryViewModel> Countries { get; set; }
    }
}