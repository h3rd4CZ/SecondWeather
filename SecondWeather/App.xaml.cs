using SecondWeather.Data;
using SecondWeather.Data.Data;

namespace SecondWeather
{
    public partial class App : Application
    {
        public App(IServiceProvider serviceProvider)
        {
            InitializeComponent();

            using (var scope = serviceProvider.CreateScope())
            {
                DatabaseInitializer.Initialize(serviceProvider);
            }
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new MainPage()) { Title = "SecondWeather" };
        }
    }
}
