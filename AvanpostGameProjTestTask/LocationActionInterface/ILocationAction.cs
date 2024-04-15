using AvanpostGameTestTask;

namespace AvanpostGameProjTestTask.LocationActionInterface
{
    public interface ILocationAction
    {
        string Name { get; }
        string Execute(Player player);
    }
}