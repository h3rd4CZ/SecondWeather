using Android.OS;
using MudBlazor.Utilities;
using SecondWeather.Components.Theme;
using SecondWeather.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondWeather.Components.Layout
{
    public partial class MainLayout
    {
        bool _drawerOpen = true;
        bool darkMode = App.Current?.RequestedTheme == AppTheme.Dark;
        void DrawerToggle() => _drawerOpen = !_drawerOpen;
        MudColor primaryColorBasedOnWeather = default!;
        MudColor primaryColorBasedOnWeatherGradient = default!;

        protected override Task OnInitializedAsync()
        {
            primaryColorBasedOnWeather = MudBlazor.Colors.Indigo.Default;
            primaryColorBasedOnWeatherGradient = primaryColorBasedOnWeather.ColorLighten(.25);

            Application.Current!.RequestedThemeChanged += Current_RequestedThemeChanged;

            if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
            {
                var activity = Platform.CurrentActivity;
                activity?.Window?.SetStatusBarColor(darkMode 
                    ? ColorTheme.AppTheme(primaryColorBasedOnWeather, darkMode).PaletteDark.AppbarBackground.ToAndroidColor()
                    : ColorTheme.AppTheme(primaryColorBasedOnWeather, darkMode).PaletteLight.Primary.ToAndroidColor());

                if(!darkMode) activity?.Window?.SetNavigationBarColor(primaryColorBasedOnWeatherGradient.ToAndroidColor());
            }
            return Task.CompletedTask;
        }

        private void Current_RequestedThemeChanged(object? sender, AppThemeChangedEventArgs e)
        {
            darkMode = e.RequestedTheme == AppTheme.Dark;
            StateHasChanged();
        }
    }
}
