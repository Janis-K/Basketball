using System;
using System.Collections.Generic;
using System.Data.Entity;
using Basketball.Models.Models;

namespace Basketball.Data
{
    public class SeedData : DropCreateDatabaseIfModelChanges<BasketballContext>
    {
        protected override void Seed(BasketballContext context)
        {
            GetCountries().ForEach(c => context.Countries.Add(c));
            GetTeams().ForEach(c => context.Teams.Add(c));
            GetGames().ForEach(g => context.Games.Add(g));
            GetPositions().ForEach(g => context.Positions.Add(g));
            GetPlayers().ForEach(g => context.Players.Add(g));
            GetPerformances().ForEach(g => context.Performances.Add(g));
            GetSeasons().ForEach(c => context.Seasons.Add(c));
            GetRosters().ForEach(c => context.Rosters.Add(c));
            GetLeagues().ForEach(g => context.Leagues.Add(g));
            GetLeagueSeasons().ForEach(g => context.LeagueSeasons.Add(g));
            context.Commit();
        }

        private static List<Country> GetCountries()
        {
            return new List<Country>
            {
                new Country {
                    Id = 1,
                    CountryName = "Latvia"
                },
                new Country {
                    Id = 2,
                    CountryName = "United States of America"
                }
            };
        }

        private static List<Season> GetSeasons()
        {
            return new List<Season>()
            {
                new Season()
                {
                    Id = 1,
                    SeasonName = "2015/16"
                },
                new Season()
                {
                    Id = 2,
                    SeasonName = "2016"
                },
                new Season()
                {
                    Id = 3,
                    SeasonName = "2016/17"
                }
            };
        }

        private static List<League> GetLeagues()
        {
            return new List<League>()
            {
                new League()
                {
                    Id = 1,
                    CountryId = 1,
                    LeagueName = "Latvijas sieviešu basketbola līga"
                },
                new League()
                {
                    Id = 2,
                    CountryId = 2,
                    LeagueName = "Women's National Basketball Association"
                }

            };
        }

        private static List<LeagueSeason> GetLeagueSeasons()
        {
            return new List<LeagueSeason>()
            {
                new LeagueSeason
                {
                    Id = 1,
                    LeagueId = 1,
                    SeasonId = 3
                },
                new LeagueSeason()
                {
                    Id = 2,
                    LeagueId = 1,
                    SeasonId = 1
                }
            };
        }

        private static List<Game> GetGames()
        {
            return new List<Game>()
            {
                new Game()
                {
                    Id = 1,
                    HomeTeamId = 1,
                    AwayTeamId = 2,
                    HTeam_1Q = 13,
                    ATeam_1Q = 21,
                    HTeam_2Q = 18,
                    ATeam_2Q = 15,
                    HTeam_3Q = 16,
                    ATeam_3Q = 11,
                    HTeam_4Q = 19,
                    ATeam_4Q = 15,
                    DateTime = DateTime.Now,
                    LeagueSeasonId = 1
                },
                new Game()
                {
                    Id = 2,
                    HomeTeamId = 2,
                    AwayTeamId = 1,
                    HTeam_1Q = 9,
                    ATeam_1Q = 23,
                    HTeam_2Q = 19,
                    ATeam_2Q = 23,
                    HTeam_3Q = 25,
                    ATeam_3Q = 16,
                    HTeam_4Q = 19,
                    ATeam_4Q = 22,
                    DateTime = DateTime.Now,
                    LeagueSeasonId = 1
                }
            };
        }

        private static List<Team> GetTeams()
        {
            return new List<Team>
            {
                new Team
                {
                    Id = 1,
                    City = "Rīga",
                    CountryId = 1,
                    TeamName = "TTT Rīga"
                },
                new Team
                {
                    Id = 2,
                    City = "Liepāja",
                    CountryId = 1,
                    TeamName = "Vega 1/Liepāja"
                }
            };
        }

        private static List<Player> GetPlayers()
        {
            return new List<Player>
            {
                new Player()
                {
                    Id = 1,
                    FirstName = "Ieva",
                    LastName = "Krastiņa",
                    Heigth = 172,
                    CountryId = 1,
                    PositionId = 1
                },
                new Player()
                {
                    Id = 2,
                    FirstName = "Kristīne",
                    LastName = "Silarāja",
                    Heigth = 172,
                    CountryId = 1,
                    PositionId = 3
                }
            };
        }

        private static List<Performance> GetPerformances()
        {
            return new List<Performance>
            {
                new Performance
                {
                    Id = 1,
                    PlayerId = 1,
                    GameId = 1,
                    As = 4,
                    Bl = 0,
                    Dreb = 5,
                    Oreb = 1,
                    Fo = 2,
                    Foa = 3,
                    To = 1,
                    St = 1,
                    PlusMinus = -1,
                    Time = new TimeSpan(0,36,38),
                    TwoPtfga = 2,
                    TwoPtfgm = 1,
                    ThreePtfga = 9,
                    ThreePtfgm = 3,
                    Fta = 1,
                    Ftm = 0
                },
                new Performance
                {
                    Id = 2,
                    PlayerId = 2,
                    GameId = 1,
                    As = 5,
                    Bl = 1,
                    Dreb = 8,
                    Oreb = 0,
                    Fo = 2,
                    Foa = 5,
                    To = 3,
                    St = 3,
                    PlusMinus = -9,
                    Time = new TimeSpan(0,38,34),
                    TwoPtfga = 11,
                    TwoPtfgm = 4,
                    ThreePtfga = 6,
                    ThreePtfgm = 4,
                    Fta = 5,
                    Ftm = 3
                }
            };
        }

        private static List<Position> GetPositions()
        {
            return new List<Position>
            {
                new Position()
                {
                    Id = 1,
                    PositionName = "PG"
                },
                new Position()
                {
                    Id = 2,
                    PositionName = "SG"
                },
                new Position()
                {
                    Id = 3,
                    PositionName = "SF"
                },
                new Position()
                {
                    Id = 4,
                    PositionName = "PF"
                },
                new Position()
                {
                    Id = 5,
                    PositionName = "C"
                }
            };
        }

        

        private static List<Roster> GetRosters()
        {
            return new List<Roster>
            {
                new Roster()
                {
                    Id = 1,
                    SeasonId = 3,
                    TeamId = 1,
                }
            };
        }

        
    }
}
