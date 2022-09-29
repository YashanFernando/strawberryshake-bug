using Client.GraphQL;
using Microsoft.Extensions.DependencyInjection;
using StrawberryShake;

namespace Client;

public class Program
{
    public static async Task Main()
    {
        var container = new ServiceCollection();
        container.AddGraphClient()
                .ConfigureHttpClient(client =>
                    client.BaseAddress = new Uri("https://localhost:7228/graphql"));
        var provider = container.BuildServiceProvider();

        var result = await provider.GetRequiredService<IGraphClient>().GetBook.ExecuteAsync();
        result.EnsureNoErrors();

        if (result.Data!.Book.Citation.Publisher is null)
            throw new Exception("The publisher should not be null");
    }
}