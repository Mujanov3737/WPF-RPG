using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    public class Weapon : GameItem
    {
        public int MinimumDamage { get; set; }
        public int MaximumDamage { get; set; }
        public Weapon(int itemTypeID, string name, int price, int minDmg, int maxDmg) 
            : base(itemTypeID, name, price)
        {
            MinimumDamage = minDmg;
            MaximumDamage = maxDmg;
        }

        //We need "new" here because the Clone method exists in GameItem and Weapon.class
        //and Weapon is a child of GameItem
        public new Weapon Clone()
        {
            return new Weapon(ItemTypeID, Name, Price, MinimumDamage, MaximumDamage);
        }

    }
}
