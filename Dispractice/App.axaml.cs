using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using Dispractice.Extensions;
using Dispractice.Models;
using Dispractice.Services;
using Dispractice.ViewModels;
using Dispractice.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Dispractice;

public partial class App : Application
{
    public static ServiceProvider Services { get; private set; }
    public static IConfiguration Configuration { get; private set; }
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        // Line below is needed to remove Avalonia data validation.
        // Without this line you will get duplicate validations from both Avalonia and CT
        BindingPlugins.DataValidators.RemoveAt(0);

        IConfigurationBuilder builder = new ConfigurationBuilder();
        builder.AddJsonFile("appsettings.json");
        Configuration = builder.Build();

        // Register all the services needed for the application to run
        var collection = new ServiceCollection();

        collection.AddDbContext<MilitaryServiceContext>(options =>
        {
            options.UseSqlite(Configuration["ConnectionStrings:DefaultConnection"]);
        });


        collection.AddCommonServices();
        collection.AddSingleton<NavigationService>();
        collection.AddTransient<IServicemanService, ServicemanService>();
        collection.AddSingleton<MainViewModel>();

        collection.AddTransient<ServicemanListViewModel>();
        collection.AddTransient<ServicemanViewModel>();
        collection.AddTransient<UnitListViewModel>();
        collection.AddTransient<UnitViewModel>();
        collection.AddTransient<StructureViewModel>();
        collection.AddTransient<PositionViewModel>();

        collection.AddTransient<CommendationViewModel>();


        // Creates a ServiceProvider containing services from the provided IServiceCollection
        Services = collection.BuildServiceProvider();

        var db = Services.GetRequiredService<MilitaryServiceContext>();

        db.Database.Migrate();

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow
            {
                DataContext = Services.GetService<MainViewModel>()
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}