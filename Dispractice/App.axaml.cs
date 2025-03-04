using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using Dispractice.Extensions;
using Dispractice.Models;
using Dispractice.Services;
using Dispractice.ViewModels;
using Dispractice.Views;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

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

        // Register all the services needed for the application to run
        var collection = new ServiceCollection();
        collection.AddCommonServices();
        collection.AddSingleton<NavigationService>();
        collection.AddScoped<IServicemanService,ServicemanService>();
        collection.AddSingleton<MainViewModel>();

        collection.AddTransient<ServicemanListViewModel>();
        collection.AddTransient<ServicemanViewModel>();
        collection.AddTransient<UnitListViewModel>();
        collection.AddTransient<UnitViewModel>();
        collection.AddTransient<StructureViewModel>();
        collection.AddTransient<PositionViewModel>();



        collection.AddDbContext<MilitaryServiceContext>();


        IConfigurationBuilder builder = new ConfigurationBuilder();
        
        builder.AddJsonFile("appsettings.json");

        Configuration = builder.Build();

        // Creates a ServiceProvider containing services from the provided IServiceCollection
        Services = collection.BuildServiceProvider();


        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow
            {
                DataContext = Services.GetService<MainViewModel>()
            };
        }
        else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            singleViewPlatform.MainView = new MainWindow
            {
                DataContext = Services.GetService<MainViewModel>()
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}
