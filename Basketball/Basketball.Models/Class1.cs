using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basketball.Models
{
    public class FIBAPlayerStats
    {
        public string sMinutes { get; set; }
        public int eff_1 { get; set; }
        public int eff_2 { get; set; }
        public float eff_3 { get; set; }
        public int eff_4 { get; set; }
        public int eff_5 { get; set; }
        public int eff_6 { get; set; }
        public int eff_7 { get; set; }
        public int sFieldGoalsMade { get; set; }
        public int sFieldGoalsAttempted { get; set; }
        public int sFieldGoalsPercentage { get; set; }
        public int sThreePointersMade { get; set; }
        public int sThreePointersAttempted { get; set; }
        public int sThreePointersPercentage { get; set; }
        public int sTwoPointersMade { get; set; }
        public int sTwoPointersAttempted { get; set; }
        public int sTwoPointersPercentage { get; set; }
        public int sFreeThrowsMade { get; set; }
        public int sFreeThrowsAttempted { get; set; }
        public int sFreeThrowsPercentage { get; set; }
        public int sReboundsDefensive { get; set; }
        public int sReboundsOffensive { get; set; }
        public int sReboundsTotal { get; set; }
        public int sAssists { get; set; }
        public int sTurnovers { get; set; }
        public int sSteals { get; set; }
        public int sBlocks { get; set; }
        public int sBlocksReceived { get; set; }
        public int sFoulsPersonal { get; set; }
        public int sFoulsOn { get; set; }
        public int sPoints { get; set; }
        public int sPointsSecondChance { get; set; }
        public int sPointsFastBreak { get; set; }
        public int sPlusMinusPoints { get; set; }
        public int sEfficiencyCustom { get; set; }
        public int sPointsInThePaint { get; set; }
        public string firstName { get; set; }
        public string firstNameInitial { get; set; }
        public string familyName { get; set; }
        public string familyNameInitial { get; set; }
        public string internationalFirstName { get; set; }
        public string internationalFirstNameInitial { get; set; }
        public string internationalFamilyName { get; set; }
        public string internationalFamilyNameInitial { get; set; }
        public int active { get; set; }
        public int captain { get; set; }
        public int starter { get; set; }
        public string photoT { get; set; }
        public string photoS { get; set; }
        public string playingPosition { get; set; }
        public string shirtNumber { get; set; }
        public Comp comp { get; set; }
        public string name { get; set; }
    }

    public class Comp
    {
        public string sMinutesAverage { get; set; }
        public float sPointsAverage { get; set; }
        public float sReboundsTotalAverage { get; set; }
        public float sAssistsAverage { get; set; }
    }
}
