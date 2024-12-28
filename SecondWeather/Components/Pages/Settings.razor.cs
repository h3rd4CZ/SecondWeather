using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using SecondWeather.Data.Data;
using SecondWeather.Data.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondWeather.Components.Pages
{
    public partial class Settings
    {
        [Inject] public ApplicationDbContext Db { get; set; }

        UserSettings subKey = new();
        UserSettings notificationWorkWeekFrom = new();
        UserSettings notificationWorkWeekTo = new();
        UserSettings notificationWeekendFrom = new();
        UserSettings notificationWeekendTo = new();

        protected override async Task OnInitializedAsync()
        {
            try
            {
                await LoadSettings();
            }
            catch (Exception ex)
            {
                Snackbar.Add("Chyba načítání nastavení", MudBlazor.Severity.Error);
            }
        }

        private async Task LoadSettings()
        {
            var allSettings = await Db.UserSettings.ToListAsync();
            subKey = allSettings.FirstOrDefault(s => s.Key == nameof(subKey)) ?? new UserSettings { Key = nameof(subKey) };
            notificationWorkWeekFrom
                = allSettings.FirstOrDefault(s => s.Key == nameof(notificationWorkWeekFrom)) ?? new UserSettings { Key = nameof(notificationWorkWeekFrom) };
            notificationWorkWeekTo
                = allSettings.FirstOrDefault(s => s.Key == nameof(notificationWorkWeekTo)) ?? new UserSettings { Key = nameof(notificationWorkWeekTo) };
            notificationWeekendFrom
                = allSettings.FirstOrDefault(s => s.Key == nameof(notificationWeekendFrom)) ?? new UserSettings { Key = nameof(notificationWeekendFrom) };
            notificationWeekendTo
                = allSettings.FirstOrDefault(s => s.Key == nameof(notificationWeekendTo)) ?? new UserSettings { Key = nameof(notificationWeekendTo) };
        }

        async Task subKeyChanged(string newValue)
        {
            subKey.Value = newValue;
            await SaveSettingsValue(subKey);
        }

        async Task notificationWorkWeekFromChanged(TimeSpan? newFrom)
        {
            if (newFrom.HasValue)
            {
                notificationWorkWeekFrom.Value = newFrom.Value.ToString();
                await SaveSettingsValue(notificationWorkWeekFrom);
            }
        }

        async Task notificationWorkWeekToChanged(TimeSpan? newTo)
        {
            if (newTo.HasValue)
            {
                notificationWorkWeekTo.Value = newTo.Value.ToString();
                await SaveSettingsValue(notificationWorkWeekTo);
            }
        }

        async Task notificationWeekendFromChanged(TimeSpan? newFrom)
        {
            if (newFrom.HasValue)
            {
                notificationWeekendFrom.Value = newFrom.Value.ToString();
                await SaveSettingsValue(notificationWeekendFrom);
            }
        }

        async Task notificationWeekendToChanged(TimeSpan? newTo)
        {
            if (newTo.HasValue)
            {
                notificationWeekendTo.Value = newTo.Value.ToString();
                await SaveSettingsValue(notificationWeekendTo);
            }
        }

        async Task SaveSettingsValue(UserSettings settings)
        {
            if(settings.Id > 0) Db.UserSettings.Update(settings);
            else Db.UserSettings.Add(settings);

            await Db.SaveChangesAsync();
        }
    }
}
