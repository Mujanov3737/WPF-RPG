using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Models;

namespace Engine.Factories
{
    internal static class QuestFactory
    {
        private static readonly List<Quest> _quests = new List<Quest>();

        static QuestFactory()
        {
            // Declare the items needed to complete the quest and the reward items
            List<ItemQuantity> itemsToComplete = new List<ItemQuantity>();
            List<ItemQuantity> rewardItems = new List<ItemQuantity>();

            // Temporary variables to add items to complete and pass in as parameter
            itemsToComplete.Add(new ItemQuantity(9001, 5));
            rewardItems.Add(new ItemQuantity(1002, 1));

            // Create the actual quest
            // 25 = xp, 10 = gold
            _quests.Add(new Quest(1, 
                                  "Clear the Mess",
                                  "The Commissar has asked that you exterminate the Gretchins " +
                                  "that have overrun the Mess Hall. Bring back 5 of their heads as proof",
                                  itemsToComplete, 25, 10, rewardItems));
        }

        internal static Quest GetQuestByID(int id)
        {
            // Takes a parameter of an ID then looks in the _quest static variable which contains our
            // list of quests and try to find the corresponding quest ID or the default which is null.
            return _quests.FirstOrDefault(quest => quest.ID == id);
        }
    }
}
