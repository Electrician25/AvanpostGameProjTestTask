using AvanpostGameProjTestTask.LocationActionInterface;
using AvanpostGameTestTask;

namespace AvanpostGameProjTestTask.Locations
{
    public class TakeAction : ILocationAction
    {
        public string Name { get; } = "взять";

        public string Execute(Player player)
        {
            return "Напиши 'взять <имя предмета>', чтобы взять предмет.";
        }
    }
}
