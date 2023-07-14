using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    // Need to be a child of Base so we can notify UI when the monster's hitpoints change
    public class Monster : BaseNotificationClass
    {
        private int _hitPoints;

        public string Name { get; private set; }
        public string ImageName { get; private set; }
        public int MaximumHitPoints { get; private set; }

        //uses backing variable because this is the only property we need the UI to update
        public int HitPoints
        {
            get { return _hitPoints; }
            set
            {
                _hitPoints = value;
                OnPropertyChanged(nameof(HitPoints));
            }
        }

        public int MinimumDamage { get; set; }
        public int MaximumDamage { get; set; }

        public int RewardExperiencePoints { get; private set; }
        public int RewardGold { get; private set; }

        public ObservableCollection<ItemQuantity> Inventory { get; set; }

        public Monster(string name, string imageName, int maximumHitPoints, int hitPoints,
                       int minimumDamage, int maximumDamage,
                       int rewardXP, int rewardGold)
        {
            Name = name;
            ImageName = ($"/Engine;component/Images/Monsters/{imageName}");
            MaximumHitPoints = maximumHitPoints;
            HitPoints = hitPoints;
            MinimumDamage = minimumDamage;
            MaximumDamage = maximumDamage;
            RewardExperiencePoints = rewardXP;
            RewardGold = rewardGold;

            //if we don't do this, "Inventory" will be null, rather than empty.
            Inventory = new ObservableCollection<ItemQuantity>();
        }


    }
}
