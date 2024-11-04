using System.Net;
using DotNet.Testcontainers.Builders;
using DotNet.Testcontainers.Containers;
using DotNet.Testcontainers.Networks;
using Testcontainers.PostgreSql;

namespace Tests.Integration;

public class IntegrationTest
{
    private static readonly ushort ApiPort = 4000;
    public static readonly string ApiUrl = $"http://localhost:{ApiPort}/";
    private static readonly string ApiImage = "vanjackal/combatcritters:latest";

    private static readonly string DbName = "critter_db";
    private static readonly string DbUser = "critter_db";
    private static readonly string DbPass = "critter_db";
    private static readonly string DbHost = "postgres";
    private static readonly int DbPort = 5432;
    private static readonly string Origin = "http://combatcritters.ca";
    private static readonly string OriginDev = "http://localhost:3000";


    private IContainer _apiContainer;
    private PostgreSqlContainer _postgresContainer;
    private INetwork _network;

    [SetUp]
    public virtual async Task Setup()
    { //! this isn't really a great way of doing this but TestContainers for .NET doesn't support compose yet (java does ;-;)
        _network = new NetworkBuilder()
            .Build();
        await _network.CreateAsync();

        _postgresContainer = new PostgreSqlBuilder()
            .WithDatabase(DbName)
            .WithUsername(DbUser)
            .WithPassword(DbPass)
            .WithPortBinding(DbPort)
            .WithNetwork(_network)
            .WithNetworkAliases(DbHost)
            .Build();
        await _postgresContainer.StartAsync();

        _apiContainer = new ContainerBuilder()
            .WithImage(ApiImage)
            .WithPortBinding(4000, 8080)
            .DependsOn(_postgresContainer)
            .WithEnvironment("DB_HOST", $"{DbHost}:{DbPort}")
            .WithEnvironment("DB_USER", DbUser)
            .WithEnvironment("DB_PASS", DbPass)
            .WithEnvironment("ORIGIN", Origin)
            .WithEnvironment("ORIGIN_DEV", OriginDev)
            .WithNetwork(_network)
            .Build();
        await _apiContainer.StartAsync();
        //* this is the best worst solution I could figure out, this is terrible;
        while (true)// wait until the api is online
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(ApiUrl);
                await client.GetAsync("/ping");
                break;
            }
            catch (HttpRequestException e)
            {
                //do nothing just keep looping till this works
            }
            Thread.Sleep(50);
        }
        //! I couldn't get the intended wait conditions working using TestContainers
    }

    [TearDown]
    public virtual async Task TearDown()
    {
        await _apiContainer.DisposeAsync();
        await _postgresContainer.DisposeAsync();
        await _network.DisposeAsync();
    }
}