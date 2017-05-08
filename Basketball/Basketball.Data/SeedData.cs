using System;
using System.Collections.Generic;
using System.Data.Entity;
using Basketball.Models.Models;

namespace Basketball.Data
{
    class SeedData : DropCreateDatabaseIfModelChanges<BasketballContext>
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
            context.Commit();
        }

        private static List<Country> GetCountries()
        {
            return new List<Country>
            {
                new Country {
                    CountryName = "Latvia"
                },
                new Country {
                    CountryName = "United States of America"
                }
            };
        }

        private static List<Game> GetGames()
        {
            return new List<Game>()
            {
                new Game()
                {
                    HomeTeamId = 1,
                    AwayTeamId = 2,
                    HTeam_1Q = 13,
                    ATeam_1Q = 21,
                    HTeam_2Q = 18,
                    ATeam_2Q = 15,
                    HTeam_3Q = 16,
                    ATeam_3Q = 11,
                    HTeam_4Q = 19,
                    ATeam_4Q = 15
                },
                new Game()
                {
                    HomeTeamId = 2,
                    AwayTeamId = 1,
                    HTeam_1Q = 9,
                    ATeam_1Q = 23,
                    HTeam_2Q = 19,
                    ATeam_2Q = 23,
                    HTeam_3Q = 25,
                    ATeam_3Q = 16,
                    HTeam_4Q = 19,
                    ATeam_4Q = 22
                }
            };
        }

        private static List<Team> GetTeams()
        {
            return new List<Team>
            {
                new Team
                {
                    City = "Rīga",
                    CountryId = 1,
                    TeamName = "TTT Rīga"
                },
                new Team
                {
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
                    FirstName = "Ieva",
                    LastName = "Krastiņa",
                    Heigth = 172,
                    NationalityId = 1,
                    PositionId = 1
                },
                new Player()
                {
                    FirstName = "Kristīne",
                    LastName = "Silarāja",
                    Heigth = 172,
                    NationalityId = 1,
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
                    Time = new DateTime(0,0,0,0,36,38),
                    TwoPtfga = 2,
                    TwoPtfgm = 1,
                    ThreePtfga = 9,
                    ThreePtfgm = 3,
                    Fta = 1,
                    Ftm = 0
                },
                new Performance
                {
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
                    Time = new DateTime(0,0,0,0,38,34),
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
                    PositionName = "PG"
                },
                new Position()
                {
                    PositionName = "SG"
                },
                new Position()
                {
                    PositionName = "SF"
                },
                new Position()
                {
                    PositionName = "PF"
                },
                new Position()
                {
                    PositionName = "C"
                }
            };
        }

        private static List<Season> GetSeasons()
        {
            return new List<Season>()
            {
                new Season()
                {
                    SeasonName = "2015/16"
                },
                new Season()
                {
                    SeasonName = "2016"
                },
                new Season()
                {
                    SeasonName = "2016/17"
                }
            };
        }

        private static List<Roster> GetRosters()
        {
            return new List<Roster>
            {
                new Roster()
                {
                    SeasonId = 3,
                    TeamId = 1,
                }
            };
        }
    }
}
