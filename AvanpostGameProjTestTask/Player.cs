using AvanpostGameProjTestTask.Items;
using AvanpostGameProjTestTask.Locations;

namespace AvanpostGameTestTask
{
    public class Player
    {
        public Location CurrentLocation { get; set; }
        public List<Item> Inventory { get; } = new List<Item>();

        public Player(Location initialLocation)
        {
            CurrentLocation = initialLocation;
        }
    }
}
