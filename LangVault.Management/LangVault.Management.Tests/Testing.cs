using FluentValidation;
using LangVault.Management.Application.Common.Behaviors;
using LangVault.Management.Infrastructure;
using LangVault.Management.Infrastructure.Interceptors;
using LangVault.Management.Infrastructure.Interfaces;
using LangVault.Management.Web;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Npgsql;
using Respawn;

namespace LangVault.Management.Tests;
[SetUpFixture]
public class Testing
{
    private static string _currentUserId;
    private static Respawner _respawner;
    private static NpgsqlConnection DefaultConnection; //
    private static IServiceScopeFactory _scopeFactory;
    private static AutoMapper.IConfigurationProvider _configurationProvider;
    private static IMapper _mapper;

    public static IConfiguration _configuration;

    [OneTimeSetUp]
    public async Task Setup() //
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", true, true)
            .AddEnvironmentVariables();
        _configuration = builder.Build();
        var services = new ServiceCollection();
        services.AddSingleton(_configuration); // 

        {
            // services
            // to methods
            services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(Application.DependencyInjection).Assembly));
            //services.RegisterGenericMediatRHandlers(typeof(GenericHandlerBase).Assembly);
            services.AddValidatorsFromAssembly((typeof(Application.DependencyInjection).Assembly));

            // pipeline
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            // automapper
            _configurationProvider = new MapperConfiguration(config => config.AddProfile<MappingProfile>());
            _mapper = _configurationProvider.CreateMapper();
            services.AddSingleton(_configurationProvider.CreateMapper());

            services.AddSingleton<ICurrentUserProvider, CurrentUserProvider>();
            services.AddHttpContextAccessor();

            services.AddSingleton<AuditableInterceptor>();
            services.AddDbContextFactory<ApplicationDbContext>((sp, options) =>
                options.UseNpgsql(_configuration.GetConnectionString("DefaultConnection"))
                .AddInterceptors(sp.GetRequiredService<AuditableInterceptor>()));


            {
                // User CurrnetUserProvider
                // Replace service registration for IcurrentUserService
                // Remvoe existing registration
                //var currentUserServiceDesctiptor = services.FirstOrDefault(x=>x.ServiceType == typeof(IUserService))
                //services.Remove(currentUserServiceDesctiptor)

                // Register testing version
                //services.AddTransient(x=>x.Mock.of<ICurrentUserServie>(x=>x.Userid ==  _currentUserId));
            }
            services.AddScoped(options =>
                options.GetRequiredService<IDbContextFactory<ApplicationDbContext>>()
                .CreateDbContext());
            services.AddScoped<IInitialiser, ApplicationDbContextInitialiser>();
            services.AddSingleton(Mock.Of<IWebHostEnvironment>(x =>
                x.EnvironmentName == "Development" && x.ApplicationName == "LangVault.Admin"));
            _scopeFactory = services.BuildServiceProvider().GetService<IServiceScopeFactory>();
        }

        EnsureDatabase();
        await InitialiseDatabaseAsync();
    }

    private void EnsureDatabase()
    {
        using var scope = _scopeFactory.CreateScope();
        var dbContextFactory = scope.ServiceProvider.GetService<IDbContextFactory<ApplicationDbContext>>();
        using var dbContext = dbContextFactory.CreateDbContext();
        dbContext.Database.EnsureCreated();
    }

    private async Task InitialiseDatabaseAsync()
    {
        DefaultConnection = new(_configuration.GetConnectionString("DefaultConnection"));
        await DefaultConnection.OpenAsync();
        _respawner = await Respawner.CreateAsync(DefaultConnection, new RespawnerOptions { DbAdapter = DbAdapter.Postgres });
        await SeedDataAsync();
    }

    private async Task SeedDataAsync()
    {
        using var scope = _scopeFactory.CreateScope();
        var initialiser = scope.ServiceProvider.GetService<IInitialiser>();
        await initialiser.SeedAsync();
    }

    public static async Task ResetDatabaseAsync()
    {
        if (DefaultConnection is not null)
        {
            await _respawner.ResetAsync(DefaultConnection); // ignore __efhistory?
        }
        _currentUserId = null!;
    }

    public static async Task AddAsync<TEntity>(TEntity entity) where TEntity : class
    {
        using var scope = _scopeFactory.CreateScope();
        var dbContextFactory = scope.ServiceProvider.GetService<IDbContextFactory<ApplicationDbContext>>();
        using var dbContext = await dbContextFactory.CreateDbContextAsync();
        dbContext.Set<TEntity>().Add(entity);
        await dbContext.SaveChangesAsync();
    }

    public static async Task AddRangeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
    {
        using var scope = _scopeFactory.CreateScope();
        var dbContextFactory = scope.ServiceProvider.GetService<IDbContextFactory<ApplicationDbContext>>();
        using var dbContext = await dbContextFactory.CreateDbContextAsync();
        await dbContext.Set<TEntity>().AddRangeAsync(entities);
        await dbContext.SaveChangesAsync();
    }

    public static async Task<TEntity> FindAsync<TEntity>(int id) where TEntity : class
    {
        using var scope = _scopeFactory.CreateScope();
        var dbContextFactory = scope.ServiceProvider.GetService<IDbContextFactory<ApplicationDbContext>>();
        using var dbContext = await dbContextFactory.CreateDbContextAsync();
        return await dbContext.FindAsync<TEntity>(id);
    }

    public static async Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request)
    {
        using var scope = _scopeFactory.CreateScope();
        var mediator = scope.ServiceProvider.GetService<IMediator>()!;
        return await mediator.Send(request);
    }

    public static async Task<string> RunAsDefaultUserAsync()
    {
        return await RunAsUserAsync("Test@local", "Testing123@");
    }

    public static async Task<string> RunAsUserAsync(string userName, string password)
    {
        using var scope = _scopeFactory.CreateScope();
        //var userManager = scope.ServiceProvider.GetService<UserManager<User>>();
        //var user = new User { }
        //var result = await userManager.CreateAsync(user, password);
        //_currentUserId = user.Id;
        return null;
    }
}