using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    //made public because we need it to be viewed by other projects
    public class World
    {
        //This creates a private _locations variable and stores a list of Location type objects.
        private List<Location> _locations = new List<Location>();

        //Function we use to add location. We want it to be internal because the only other class
        //we want to use this is the worldfactory.class which is inside the engine project. This 
        //function is void because we don't want to return a value, just want to add locations to the list
        //When we call this function, we're going to pass in all these properties (coordinate, name etc).
        //Whenever we call the addlocation function, whatever parameters we set will be passed into the new
        //Location object that is created.
        internal void AddLocation(int xCoordinate, int yCoordinate, string name, string description, string imageName)
        {
            Location loc = new Location();
            loc.XCoordinate = xCoordinate;
            loc.YCoordinate = yCoordinate;
            loc.Name = name;
            loc.Description = description;
            loc.ImageName = $"/Engine;component/Images/Locations/{imageName}";

            //This will put the newly created location object into our list of locations (_locations)
            _locations.Add(loc);
        }

        //Will return a location object for whatever x and y we pass in. This looks through the list to
        //find the matching value. If it doesn't have a matching value, it will return a null.
        public Location LocationAt(int xCoordinate, int yCoordinate)
        {
            //look inside each object in the _locations list and assign that to a variable called
            //loc whose datatype is location, see if it matches the object and whether or not it
            //matches our criteria
            foreach (Location loc in _locations)
            {
                if (loc.XCoordinate == xCoordinate && loc.YCoordinate == yCoordinate)
                {
                    return loc;
                }
            }

            return null;
        }
    }
}
