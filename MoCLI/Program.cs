using MoCLI.Data;
using MoCLI.Data.Repo;

namespace MoCLI;

public class Program
{
    public static void Main()
    {
        MainAsync().GetAwaiter().GetResult();
    }

    private static async Task MainAsync()
    {
        var cardRepo = new CardRepo();
        var ui = new UI(cardRepo);
        await ui.Start();
    }
}

