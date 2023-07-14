using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Engine.Models
{
    /* "INotifyPropertyChanged" - How we implement the interface (relies on "System.ComponentModel")
     * This property change event basically states that anytime any of these properties change,
     * the player object is going to notify any other classes that the value has changed and that
     * those classes should update their value accordingly.
     * The XAML knows that the player object (as defined by the class) implements the "INotifyPropertyChanged"
     * event and it will listen for any property changed events so it can update the user interface.
     */
    public class Player : BaseNotificationClass
    {
        private string _name;
        private string _characterClass;
        private int _hitPoints;
        private int _experiencePoints;
        private int _level;
        private int _gold;

        //If you "get" a value from any of the properties it returns the value from the backing variables.
        //If you "set" a property to a new value, it saves it to the backing variable and 
        //also raises the property changed event with the correct property name
        //This is a common approach to allow model and viewmodel objects to notify the GUI(view) of changes

        //Can also be used to something like if the player kills the monster, we could raise an event that says
        //you've won the battle, here's the loot, exp etc that you will get.

        //this techinque is called the "Publish and Subscribe method" or "PubSub" because
        //the player object is "publishing" the event and the UI is "subscribing" to it so it gets
        //the notification of the change.

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public string CharacterClass
        {
            get { return _characterClass; }
            set
            {
                _characterClass = value;
                OnPropertyChanged(nameof(CharacterClass));
            }
        }
        public int HitPoints
        {
            get { return _hitPoints; }
            set
            {
                _hitPoints = value;
                OnPropertyChanged(nameof(HitPoints));
            }
        }
        public int ExperiencePoints
        {
            get { return _experiencePoints; }
            set
            {
                _experiencePoints = value;
                OnPropertyChanged(nameof(ExperiencePoints));
            }
            //This will take the value that was passed in by us in the object (0) and set it in the
            //private backing variable we made above by the setter ("_experiencePoints"). Then it will
            //call the "OnPropertyChanged" function with the "ExperiencePoints" name value as we defined when
            //we wrote the function. The function will take the property name and if anyone is listening
            //to the properties changed on the player class, it will say "The experience points have changed
            //you need to update something"
        }
        public int Level
        {
            get { return _level; }
            set
            {
                _level = value;
                OnPropertyChanged(nameof(Level));
            }
        }
        public int Gold
        {
            get { return _gold; }
            set
            {
                _gold = value;
                OnPropertyChanged(nameof(Gold));
            }
        }

        public ObservableCollection<GameItem> Inventory { get; set; }
        //Whenever something accesses the weapons property, its going to return the inventory
        //items where the item is a weapon. ToList will "materialize" the "Where". Sometimes a LINQ
        //statement doesnt finalize the result until you call ToList or something else. This is called
        //deferred execution. ToList forces it to be needed.
        public List<GameItem> Weapons => Inventory.Where(i => i is Weapon).ToList();
        public ObservableCollection<QuestStatus> Quests { get; set; }

        public Player()
        {
            Inventory = new ObservableCollection<GameItem>();
            Quests = new ObservableCollection<QuestStatus>();
        }

        //Instead of putting the item directly into the inventory, we're going to call this function,
        //pass in the item, then the function will add it to the inventory and raise the property
        //changed event for weapons, so the UI will know that new weapons are in the inventory.
        //This function is nice because we could augment this to have a weight system if we wanted.
        public void AddItemToInventory(GameItem item)
        {
            Inventory.Add(item);

            OnPropertyChanged(nameof(Weapons));
        }

        public void RemoveItemFromInventory(GameItem item)
        {
            Inventory.Remove(item);

            OnPropertyChanged(nameof(Weapons));
        }

        public bool HasAllTheseItems(List<ItemQuantity> items)
        {
            foreach (ItemQuantity item in items)
            {
                //will count the items of that ID in the players inventory and if it's less than what
                //is in the player's inventory, then it will return false.
                if(Inventory.Count(i => i.ItemTypeID == item.ItemID) < item.Quantity)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
