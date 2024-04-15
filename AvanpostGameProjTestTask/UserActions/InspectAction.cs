using AvanpostGameProjTestTask.LocationActionInterface;
using AvanpostGameTestTask;

namespace AvanpostGameProjTestTask.Locations
{
    public class InspectAction : ILocationAction
    {
        public string Name { get; } = "осмотреться";

        public string Execute(Player player)
        {
            var loc = player.CurrentLocation.Items;
            var li = new List<string>();

            foreach (var e in loc)
            {
                li.Add(e.Name);
            }

            return $"Ты находишься в {player.CurrentLocation.Name}. в {player.CurrentLocation.Name} есть {string.Join(", ", li)}  Можно пройти - {string.Join(", ", player.CurrentLocation.Exits.Keys)}";
        }
    }
}
