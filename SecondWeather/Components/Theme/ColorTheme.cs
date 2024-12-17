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
        public static MudTheme AppTheme(MudColor primary, bool isDark) => new MudTheme()
        {
            PaletteLight = new PaletteLight()
            {
                Primary = primary,
                TextPrimary = new MudColor("#fff"),
                AppbarBackground = primary
            },
        };
    }
}
