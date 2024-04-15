using AvanpostGameTestTask;

class Program
{
    static void Main(string[] args)
    {
        Game game = new Game();

        while (true)
        {
            var str = Console.ReadLine();
            Console.WriteLine(game.ProcessInput(str));
        }
    }
}
