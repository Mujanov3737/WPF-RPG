using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Factories;

namespace Engine.Models
{
    public class Location
    {
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageName { get; set; }
        //Public List of Quest objects because we want to be able to have multiple quests in a location
        //The new List with initialize an empty list automatically so we don't need a constructor.
        //This is basically saying now each location has a new property that is a list of quests.
        public List<Quest> QuestsAvailableHere { get; set; } = new List<Quest>();

        //MonsterEncounter object has a "monsterID" and a "chance of encounter"
        public List<MonsterEncounter> MonstersHere { get; set; } = new List<MonsterEncounter>();

        //To add a monster to a location, we call this function and pass in the ID and encounter chance
        public void AddMonster(int monsterID, int chanceOfEncountering)
        {
            // MonstersHere is the list of MonsterEncounter objects
            if(MonstersHere.Exists(m => m.MonsterID == monsterID))
            {
                // This monster has already been added to this location so overwrite
                // the ChanceofEncountering with the new number
                MonstersHere.First(m => m.MonsterID == monsterID).ChanceOfEncounter = chanceOfEncountering;
            }
            else
            {
                //This monster is not already at this location, so add a new MonsterEncounter object
                //to the MonstersHere property
                MonstersHere.Add(new MonsterEncounter(monsterID, chanceOfEncountering));
            }
        }

        public Monster GetMonster()
        {
            //Looks at MonstersHere list and checks if there aren't any MonsterEncounter objects there.
            //If there isn't any, it just returns null.
            if (!MonstersHere.Any())
            {
                return null;
            }

            // Total the percentages of all monsters at this location
            // Use this to pick which monster we return
            int totalChances = MonstersHere.Sum(m => m.ChanceOfEncounter);

            //Selects a random number between 1 and the total (in case the total chances is not 100)
            int randomNumber = RandomNumberGenerator.NumberBetween(1, totalChances);

            //Loop through monster list, add monsters percent chance of appearing to running total variable
            //When random number is lower than runningTotal, that is the monster to return
            int runningTotal = 0;

            foreach(MonsterEncounter monsterEncounter in MonstersHere)
            {
                runningTotal += monsterEncounter.ChanceOfEncounter;

                if(randomNumber <= runningTotal)
                {
                    return MonsterFactory.GetMonster(monsterEncounter.MonsterID);
                }    
            }

            //If there was a problem, return the last monster in the list
            return MonsterFactory.GetMonster(MonstersHere.Last().MonsterID);
        }
    }
}
