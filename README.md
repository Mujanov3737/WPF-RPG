# Project Demo
![anim6](https://github.com/Mujanov3737/WPF-RPG/assets/75598761/a6146343-86ad-4af2-a746-afd56b6a8237)

# WPF-RPG
This program is a fork of Scott Lilly's simple RPG. It is built with WPF and the C# language. A few important design patterns and concepts were explored in this project: 
* Factory pattern so that specific classes create objects
* Publish/subscribe pattern for model components to raise events as values change and UI components to subscribe to these changes and update the interface
* MVC or MVVM (model-viewmodel-view or model view controller) to create a separation of concerns. The models contain the data (for instance the player character), the view presents the data, and the viewmodel acts as a sort of mediator to separate the data and what is presented to the user.
* Constructing a UI with XAML and integrating the UI with the codebase.
* The use of C# properties over C# fields, which have built in accessor and mutators.

# The Game
The player starts at a location in a coordinate-based grid, which each location containing a name, image, and description. The player can use the provided buttons to navigate to a cardinal direction on the gameboard, with only valid directions presented to the player. The player can enter locations that have nothing, quests, or a monster encounter. When the user encounters the monster, they can select a weapon from their inventory to battle the monster in turn based combat. Player object's also contain and inventory that will fill up as they defeat enemies. If the player's health points fall to 0, they are returned to the home position on the game board. There is currently 1 quest to complete, 1 quest reward to earn, 3 monsters to face, and no end to the game.
