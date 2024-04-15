using AvanpostGameProjTestTask.Items;
using AvanpostGameProjTestTask.LocationActionInterface;

namespace AvanpostGameProjTestTask.Locations
{
    public class Location
    {
        public string Name { get; }
        public string Description { get; }
        public Dictionary<string, Location> Exits { get; } = new Dictionary<string, Location>();
        public List<Item> Items { get; } = new List<Item>();
        public List<ILocationAction> Actions { get; } = new List<ILocationAction>();

        public Location(string name, string description)
        {
            Name = name;
            Description = description;
            Actions.Add(new InspectAction());
            Actions.Add(new MoveAction());
            Actions.Add(new TakeAction());
        }
    }
}
