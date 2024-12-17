using MudBlazor.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondWeather.Services;

public static class ColorExtensions
{
    public static Android.Graphics.Color ToAndroidColor(this MudColor mudColor)
    {
        // Convert MudColor to RGBA values
        var r = (int)(mudColor.R);  // Red
        var g = (int)(mudColor.G);  // Green
        var b = (int)(mudColor.B);  // Blue
        var a = (int)(mudColor.A);  // Alpha

        // Convert to Android.Graphics.Color
        return Android.Graphics.Color.Argb(a, r, g, b);
    }
}