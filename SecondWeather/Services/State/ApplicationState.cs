using MudBlazor.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondWeather.Services.State
{
    public class ApplicationState
    {
        public bool LoadingInProgress { get; set; } = true;
        public MudColor WeatherColor { get; set; } = default!;
    }
}
