using DotNet.Testcontainers.Builders;
using DotNet.Testcontainers.Containers;
using Testcontainers.PostgreSql;

namespace Tests.Integration;

public class IntegrationTest
{
    public static readonly string ApiUrl = "http://localhost:4000";
    private static readonly string ApiImage = "vanjackal/combatcritters:latest";

    private static readonly string DbName = "critter_db";
    private static readonly string DbUser = "critter_db";
    private static readonly string DbPass = "critter_db";
    private static readonly string DbHost = "localhost:5432";

    private IContainer _apiContainer;
    private PostgreSqlContainer _postgresContainer;
    
    [SetUp]
    public virtual async Task Setup()
    { //! this isn't really a great way of doing this but TestContainers for .NET doesn't support compose yet (java does ;-;)
        _postgresContainer = new PostgreSqlBuilder()
            .WithDatabase(DbName)
            .WithUsername(DbUser)
            .WithPassword(DbPass)
            .WithPortBinding(5432)
            .Build();
        await _postgresContainer.StartAsync();
        _apiContainer = new ContainerBuilder()
            .WithImage(ApiImage)
            .WithPortBinding(4000, 8080)
            .DependsOn(_postgresContainer)
            .WithEnvironment("DB_HOST",_postgresContainer.Hostname)
            .WithEnvironment("DB_USER",DbUser)
            .WithEnvironment("DB_PASS",DbPass)
            .Build();
        await _apiContainer.StartAsync();
    }

    [TearDown]
    public virtual async Task TearDown()
    {
        await _apiContainer.DisposeAsync();
        await _postgresContainer.DisposeAsync();
    }
}