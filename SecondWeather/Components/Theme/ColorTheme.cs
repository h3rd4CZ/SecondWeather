using Microsoft.Maui.Controls;
using MudBlazor;
using MudBlazor.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Colors = MudBlazor.Colors;

namespace SecondWeather.Components.Theme
{
    public static class ColorTheme
    {
        public const string DefaultColor = "#5C6BC0";
        public static MudTheme AppTheme(MudColor primary)
        {
            var theme = new MudTheme();

            theme.PaletteLight.AppbarBackground = primary ?? (MudColor)DefaultColor;
            theme.PaletteDark.AppbarBackground = primary ?? (MudColor)DefaultColor;


            return theme;
        }
    }
}
