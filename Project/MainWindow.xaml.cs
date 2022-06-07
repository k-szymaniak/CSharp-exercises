using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;
using System.Net;
using static Project.WeatherInfo;
using Microsoft.Win32;
using System.IO;
using Project;

namespace Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        string ApiKey = "ed9746ae7fa8eca657ecc0bc286c50f0";
        private void btnSearch_Click(object sender, EventArgs e)
        {
            getWeather();

        }

        void getWeather()
        {
            using (WebClient web = new WebClient())
            {
                string url = string.Format("https://api.openweathermap.org/data/2.5/weather?q={0}&appid={1}", TBCity.Text, ApiKey);
                var json = web.DownloadString(url);
                WeatherInfo.root Info = JsonConvert.DeserializeObject<WeatherInfo.root>(json);





                Condition.Content = Info.weather[0].main;
                Details.Content = Info.weather[0].description;
                Sunset.Content = ConvertDateTime(Info.sys.sunset).ToShortTimeString();
                Sunrise.Content = ConvertDateTime(Info.sys.sunrise).ToShortTimeString();
                Temp.Content = Kelvin2Celsius(Info.main.temp).ToString() + " C";
                WindSpeed.Content = Info.wind.speed.ToString() + " km/h";
                Pressure.Content = Info.main.pressure.ToString();
            }
        }
        DateTime ConvertDateTime(long sec)
        {
            DateTime day = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc).ToLocalTime();
            day = day.AddSeconds(sec).ToLocalTime();

            return day;
        }

        static double Kelvin2Celsius(double num) => (num - 272.15);


    }
}
