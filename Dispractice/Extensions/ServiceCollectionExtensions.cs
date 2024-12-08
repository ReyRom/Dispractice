using Dispractice.Models;
using Dispractice.Services;
using Dispractice.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace Dispractice.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddCommonServices(this IServiceCollection collection)
    {
        collection.AddSingleton<MilitaryServiceContext>();
        collection.AddSingleton<ServicemanService>();
        collection.AddTransient<MainViewModel>();
        collection.AddTransient<DisCardViewModel>();
    }
}
