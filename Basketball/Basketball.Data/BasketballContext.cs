using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using Basketball.Data.Configurations;
using Basketball.Models.Models;

namespace Basketball.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class BasketballContext : DbContext
    {
        public BasketballContext() : base("name=BasketballContext")
        {
           ((IObjectContextAdapter)this).ObjectContext.CommandTimeout = 180;
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Performance> Performances { get; set; }
        public DbSet<Roster> Rosters { get; set; }
        public DbSet<League> Leagues { get; set; }
        public DbSet<LeagueSeason> LeagueSeasons { get; set; }
        
        

        public virtual void Commit()
        {
           base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CountryConfiguration());
            modelBuilder.Configurations.Add(new GameConfiguration());
            modelBuilder.Configurations.Add(new PerformanceConfiguration());
            modelBuilder.Configurations.Add(new PlayerConfiguration());
            modelBuilder.Configurations.Add(new PositionConfiguration());
            modelBuilder.Configurations.Add(new RosterConfiguration());
            modelBuilder.Configurations.Add(new SeasonConfiguration());
            modelBuilder.Configurations.Add(new TeamConfiguration());
            modelBuilder.Configurations.Add(new LeagueConfiguration());
            modelBuilder.Configurations.Add(new LeagueSeasonConfiguration());
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}