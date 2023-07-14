using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Models;

namespace Engine.Factories
{
    public static class ItemFactory
    {
        //Readonly means the variable can only be set equal to something here where it's declared
        //or inside a constructor. Protects us from accidently setting value somewhere else.
        private static readonly List<GameItem> _standardGameItems = new List<GameItem>();

        //First time anyone uses anything in this itemfactory class, this function will run
        static ItemFactory()
        {
            

            //ID - Name - Price - MinDMG - MaxDMG
            _standardGameItems.Add(new Weapon(1001, "Bolter", 1, 1, 2));
            _standardGameItems.Add(new Weapon(1002, "Storm Bolter", 5, 2, 4));

            _standardGameItems.Add(new GameItem(9001, "Gretchin Head", 1));
            _standardGameItems.Add(new GameItem(9002, "Salvaged Gretchin Weapons", 2));
            _standardGameItems.Add(new GameItem(9003, "Toof", 3));
            _standardGameItems.Add(new GameItem(9004, "Gold Toof", 12));
            _standardGameItems.Add(new GameItem(9005, "Nobz Banner", 8));
            _standardGameItems.Add(new GameItem(9006, "WAAAGH Plans Datapad", 15));
            
        }
        //public static function that's going to return a game item
        public static GameItem CreateGameItem(int itemTypeID)
        {
            /*
             * On the _standardGameItems list variable, this will use LINQ to find the first item
             * that has an itemtypeid property value that matches the itemTypeID we passed into the function.
             * If it doesn't find a matching itemID, it will go to the default value, which is null.
             * We could have used a foreach loop to loop through the list but LINQ is handier and cleaner.
             */
            GameItem standardItem = _standardGameItems.FirstOrDefault(item => item.ItemTypeID == itemTypeID);

            if(standardItem != null)
            {
                if (standardItem is Weapon)
                {
                    //We cast the object as a Weapon rather than as a GameItem so the Clone function is the
                    //Clone function from the Weapon class not the GameItem class which means it returns
                    //a weapon object, not a gameitem object.
                    return (standardItem as Weapon).Clone();
                }
                return standardItem.Clone();
            }
            return null;

            //Instead of having return null, you can do "return standardItem?.Clone();
            //It states if anything before the ? is null then the output of the statement is null
        }
    }
}
