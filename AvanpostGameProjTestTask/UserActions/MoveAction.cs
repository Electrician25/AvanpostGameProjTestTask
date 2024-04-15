using AvanpostGameProjTestTask.LocationActionInterface;
using AvanpostGameTestTask;

namespace AvanpostGameProjTestTask.Locations
{
    public class MoveAction : ILocationAction
    {
        public string Name { get; } = "идти";

        public string Execute(Player player)
        {
            return "Напиши 'идти <имя локации>', чтобы переместиться.";
        }
    }
}
