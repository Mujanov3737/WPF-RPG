using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    //if a location only has 1 monster that can be encountered, we'd only create 1 MonsterEncounter
    //object. If there is more, we'd need 2 with different objects with 2 ID's and different chances of encountering
    public class MonsterEncounter
    {
        public int MonsterID { get; set; }
        public int ChanceOfEncounter { get; set; }

        public MonsterEncounter(int monsterID, int chanceofEncountering)
        {
            MonsterID = monsterID;
            ChanceOfEncounter = chanceofEncountering;
        }
    }
}
