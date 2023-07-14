using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Need Engine.Models so that the worldfactory.class knows about the world.class
using Engine.Models;

namespace Engine.Factories
{
    //Classes are inherently internal but its good to explicitly mention it.
    internal static class WorldFactory
    {
        //Internal function that can only be used inside the engine project that returns a world object.
        internal static World CreateWorld()
        {
            //This function will instantiate a new world object and return that to whatever code called this function
            World newWorld = new World();

            newWorld.AddLocation(0, -1, "Docking Bay", 
                "PlaceHolderTextHome", 
                "DockingFix.png");
            
            newWorld.AddLocation(-1, -1, "Medical Hall", 
                "PlaceHolderTextMedical", 
                "MedicalHallFix.png");
            
            newWorld.AddLocation(-2, -1, "Chow Hall",
                "PlaceHolderTextChow",
                "ChowHallFix.png");

            //Passes in monster ID of 1, which is a gretchin, and a chance of encounter of 100
            newWorld.LocationAt(-2, -1).AddMonster(1, 100);

            //newWorld.LocationAt actually returns a location object! This means we can use
            //the properties of that object. In this case, "QuestsAvailableHere"
            //newWorld.LocationAt(-1, 0).QuestsAvailableHere.Add(QuestFactory.GetQuestByID(1));

            newWorld.AddLocation(0, 0, "Hangar",
                "PlaceHolderTextHangar",
                "HangarFix.png");

            newWorld.AddLocation(-1, 0, "Armory",
                "PlaceHolderTextArmory",
                "Armory.png");
            newWorld.LocationAt(-1, 0).QuestsAvailableHere.Add(QuestFactory.GetQuestByID(1));

            newWorld.AddLocation(1, 0, "Ornate Gateway",
                "PlaceHolderTextOrnate",
                "GateWayFix.png");

            newWorld.AddLocation(2, 0, "Chapel",
                "PlaceHolderTextChapel",
                "ChapelFix.png");

            newWorld.LocationAt(2, 0).AddMonster(3, 100);

            newWorld.AddLocation(0, 1, "Engineering",
                "PlaceHolderTextEngi",
                "EngineeringFix.png");

            newWorld.AddLocation(0, 2, "Life Support",
                "PlaceHolderTextLifeSup",
                "LifeSupportFix.png");

            newWorld.LocationAt(0, 2).AddMonster(2, 100);

            return newWorld;


        }
    }
}
