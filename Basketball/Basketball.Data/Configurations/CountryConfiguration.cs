using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Basketball.Models.Models;

namespace Basketball.Data.Configurations
{
    class CountryConfiguration : EntityTypeConfiguration<Country>
    {
        public CountryConfiguration()
        {
            ToTable("Countries");
            Property(g => g.CountryName).IsRequired().HasMaxLength(100);
        }
    }
}
