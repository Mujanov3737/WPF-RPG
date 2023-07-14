using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Models;

namespace Engine.Factories
{
    public static class MonsterFactory
    {
        //Function that returns a monster object with whatever ID value we pass in for the parameter.
        public static Monster GetMonster(int monsterID)
        {
            switch (monsterID)
            {
                case 1:
                    Monster orkGretchin = new Monster("Gretchin", "orkGRETCH.png", 4, 4, 1, 1, 5, 1);

                    AddLootItem(orkGretchin, 9001, 75);
                    AddLootItem(orkGretchin, 9002, 25);

                    //each case you need to return or you need a break statement "break;"
                    //otherwise you can fall through to the other cases.
                    return orkGretchin;

                case 2:
                    Monster orkBoy = new Monster("Greenskin Ork Boy", "orkBOY.png", 6, 6, 1, 3, 7, 2);

                    AddLootItem(orkBoy, 9003, 85);
                    AddLootItem(orkBoy, 9004, 15);

                    return orkBoy;

                case 3:
                    Monster orkNob = new Monster("Greenskin Ork Nob", "orkNOBS.png", 10, 10, 3, 6, 10, 3);

                    AddLootItem(orkNob, 9005, 95);
                    AddLootItem(orkNob, 9006, 5);

                    return orkNob;

                default:
                    throw new ArgumentException(string.Format("MonsterType '0' does not exist", monsterID));
            }
        }

        private static void AddLootItem(Monster monster, int itemID, int percentage)
        {
            //If the random number we generate is less than our percentage, 
            //the item is added to the monster's inventory and has a change to drop
            if (RandomNumberGenerator.NumberBetween(1, 100) <= percentage)
            {
                monster.Inventory.Add(new ItemQuantity(itemID, 1));
            }
        }
    }
}
