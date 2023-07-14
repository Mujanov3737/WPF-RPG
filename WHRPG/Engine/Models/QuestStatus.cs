using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    public class QuestStatus
    {
        //PlayerQuest will hold the quest so we know which quest it is. We can do this by getting
        //the ID from the Quest class
        public Quest PlayerQuest { get; set; }
        public bool IsCompleted { get; set; }

        //Constructor here will pass in the specific quest. Always false because it isn't already
        //completed when given to the player
        public QuestStatus(Quest quest)
        {
            PlayerQuest = quest;
            IsCompleted = false;
        }
    }
}
