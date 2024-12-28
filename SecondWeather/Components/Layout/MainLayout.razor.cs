using Android.OS;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using MudBlazor.Utilities;
using SecondWeather.Components.Theme;
using SecondWeather.Services;
using System;
using System.Collections.Generic;
using System.IO.Pipelines;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Android.Content.Res.Resources;

namespace SecondWeather.Components.Layout
{
    public partial class MainLayout
    {
        bool _drawerOpen = true;
        bool darkMode = App.Current?.RequestedTheme == AppTheme.Dark;
        void DrawerToggle() => _drawerOpen = !_drawerOpen;
        MudColor primaryColorBasedOnWeather = ColorTheme.DefaultColor;
        MudColor primaryColorBasedOnWeatherGradient = ((MudColor)ColorTheme.DefaultColor).ColorLighten(.25);
        MudTheme? theme = ColorTheme.AppTheme(default!);
        bool stateInProgress => AppState.Value is null || (AppState.Value is not null && AppState.Value.LoadingInProgress);
        [CascadingParameter] public AppState AppState { get; set; } = default!;
        [Inject] public NavigationManager Navigation { get; set; }
        bool homePage => Navigation.Uri == Navigation.BaseUri;

        string backgroundColorStyle =>
            homePage
            ? $"background:linear-gradient(to bottom, {primaryColorBasedOnWeather} , {primaryColorBasedOnWeatherGradient})"
            : "";

        protected override Task OnInitializedAsync()
        {
            SetStatusAndNavigationBarColor(primaryColorBasedOnWeather, primaryColorBasedOnWeatherGradient);

            AppState.StateInitialized += AppState_StateInitialized;

            return Task.CompletedTask;
        }

        private void AppState_StateInitialized(object? sender, Services.State.ApplicationState e)
        {
            primaryColorBasedOnWeather = e.WeatherColor;
            primaryColorBasedOnWeatherGradient = primaryColorBasedOnWeather.ColorLighten(.25);

            theme = ColorTheme.AppTheme(primaryColorBasedOnWeather);

            Application.Current!.RequestedThemeChanged += Current_RequestedThemeChanged;

            if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
            {
                SetStatusAndNavigationBarColor(primaryColorBasedOnWeather, primaryColorBasedOnWeatherGradient);
            }
                        
            StateHasChanged();
        }

        void SetStatusAndNavigationBarColor(MudColor statusBarColor, MudColor navigationBarColor)
        {
            Platform.CurrentActivity?.Window?.SetStatusBarColor(statusBarColor.ToAndroidColor());
            Platform.CurrentActivity?.Window?.SetNavigationBarColor(navigationBarColor.ToAndroidColor());
        }

        void Current_RequestedThemeChanged(object? sender, AppThemeChangedEventArgs e)
        {
            darkMode = e.RequestedTheme == AppTheme.Dark;
            StateHasChanged();
        }
    }
}
