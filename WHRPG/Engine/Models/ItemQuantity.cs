using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    //We're creating this class to help with items for quests. The itemID is what item we need to complete
    //the quest and the quantity is how many of each item we need to complete the quest.
    //This class serves as an intermediate class for the inventory
    public class ItemQuantity
    {
        public int ItemID { get; set; }
        public int Quantity { get; set; }

        public ItemQuantity(int itemID, int quantity)
        {
            ItemID = itemID;
            Quantity = quantity;
        }
    }
}
