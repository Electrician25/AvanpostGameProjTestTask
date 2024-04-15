using AvanpostGameProjTestTask.Items;
using AvanpostGameProjTestTask.LocationActionInterface;
using AvanpostGameProjTestTask.Locations;

namespace AvanpostGameTestTask
{
    public class Game
    {
        private Dictionary<string, Location> locations = new Dictionary<string, Location>();
        private Player player;

        public Game()
        {
            InitializeLocations();
            InitializePlayer();
        }

        private void InitializeLocations()
        {
            Location kitchen = new Location("кухня", "Ты находишься на кухне, надо собрать рюкзак и идти в универ.");
            Location corridor = new Location("коридор", "Ничего интересного.");
            Location room = new Location("комната", "Ты в своей комнате.");
            Location street = new Location("улица", "На улице весна.");

            locations.Add("кухня", kitchen);
            locations.Add("коридор", corridor);
            locations.Add("комната", room);
            locations.Add("улица", street);

            kitchen.Exits["коридор"] = corridor;
            corridor.Exits["кухня"] = kitchen;
            corridor.Exits["комната"] = room;
            room.Exits["коридор"] = corridor;
            room.Exits["улица"] = street;
            street.Exits["комната"] = room;

            room.Items.AddRange(new List<Item> { new Item("ключи"), new Item("конспекты"), new Item("рюкзак") });
        }

        private void InitializePlayer()
        {
            player = new Player(locations["кухня"]);
        }

        public string ProcessInput(string input)
        {
            string[] inputParts = input.Split(' ');

            if (inputParts.Length == 1)
            {
                return ExecuteAction(input, "");
            }
            else if (inputParts.Length == 2)
            {
                return ExecuteAction(inputParts[0], inputParts[1]);
            }
            else
            {
                return "Неправильный формат команды.";
            }
        }

        private string ExecuteAction(string action, string argument)
        {
            ILocationAction locationAction = player.CurrentLocation.Actions.FirstOrDefault(a => a.Name == action);

            if (locationAction != null)
            {
                Dictionary<string, Func<string>> actionHandlers = new Dictionary<string, Func<string>>
            {
                { "осмотреться", () => locationAction.Execute(player) },
                { "идти", () =>
                    {
                        if (player.CurrentLocation.Exits.ContainsKey(argument))
                        {
                            player.CurrentLocation = player.CurrentLocation.Exits[argument];
                            return $"Ты пришел в {player.CurrentLocation.Name}.";
                        }
                        else
                        {
                            return "Нет пути в указанную локацию.";
                        }
                    }
                },
            { "взять", () =>
                {
                    Item item = player.CurrentLocation.Items.FirstOrDefault(i => i.Name == argument);
                    if (item != null)
                    {
                        player.Inventory.Add(item);
                        player.CurrentLocation.Items.Remove(item);
                        return $"Предмет '{argument}' добавлен в инвентарь.";
                    }
                    else
                    {
                        return "Такого предмета здесь нет.";
                    }
                }
            },
            { "default", () => "Неизвестная команда." }
        };

                if (actionHandlers.ContainsKey(action))
                {
                    return actionHandlers[action]();
                }
                else
                {
                    return actionHandlers["default"]();
                }
            }
            else
            {
                return "Действие не найдено в этой локации.";
            }
        }
    }
}
