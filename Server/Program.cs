namespace Server;

public static class Program
{
    public static void Main()
    {
        var builder = WebApplication.CreateBuilder();

        builder.Services
            .AddGraphQLServer()
            .AddQueryType<Query>();

        var app = builder.Build();

        app.MapGraphQL();

        app.Run();
    }
}

public class Book
{
    public Guid Id => new("CD378B8C-7E35-4711-B478-66AC24424BA9");
    public string Title { get; set; }
    public string Publisher { get; set; }
    public Book Citation { get; set; }
}

public class Query
{
    public Book GetBook() =>
        new Book
        {
            Title = "C# in depth.",
            Publisher = "ChilliCream",
            Citation = new Book
            {
                Title = "Graphql Mastery",
                Publisher = "ChilliCream",
            }
        };
}
