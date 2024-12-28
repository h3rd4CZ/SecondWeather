using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MudBlazor;
using MudBlazor.Services;
using SecondWeather.Data;
using SecondWeather.Data.Data;

namespace SecondWeather
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();
            RegisterServices(builder.Services);

#if DEBUG
    		builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            AddDatabase(builder.Services);

            return builder.Build();
        }

        static void AddDatabase(IServiceCollection services)
        {
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, DataConstants.DbFileName);
            ApplicationDbContext.appDataDirPath = FileSystem.AppDataDirectory;
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite($"Filename={dbPath}"));
        }

        static void RegisterServices(IServiceCollection services)
        {
            services.AddMudServices(config =>
            {
                config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomRight;
            });
        }
    }
}
