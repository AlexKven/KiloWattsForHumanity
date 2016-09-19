using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace KiloWatts_For_Humanity.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            //LoadApplication(new KiloWatts_For_Humanity.App());
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            MainPolyline.Points.Clear();
            var width = RenderGrid.ActualWidth;
            var height = RenderGrid.ActualHeight;
            var numPoints = int.Parse(NumPointsBlock.Text);
            var delta = width / numPoints;
            WebRequest request = WebRequest.Create(new Uri($"http://kw4h.org:8080/render?target=03011.AD01.Battery_Voltage&format=json&from=-1d&maxDataPoints={numPoints}"));
            request.UseDefaultCredentials = true;
            request.Proxy.Credentials = request.Credentials;
            WebResponse response = (WebResponse)await request.GetResponseAsync();
            using (var s = response.GetResponseStream())
            {
                List<char> buffer = new List<char>();
                int curByte;
                while ((curByte = s.ReadByte()) != -1)
                    buffer.Add((char)curByte);

                var json = JToken.Parse(new string(buffer.ToArray()));
                //json = (json as JObject)?.Descendants().First(d => {
                //    return  (d as JProperty)?.Name == "datapoints"; }) as JObject;
                double[] values = new double[numPoints];
                int index = 0;
                foreach (var item in (((json as JArray)[0] as JObject)?["datapoints"] as JArray))
                {
                    values[index++] = (double)(item[0] as JValue).Value;
                }
                var scaling = height / values.Max();
                values = values.Select(v => height - v * scaling).ToArray();
                for (int i = 0; i < values.Length; i++)
                {
                    MainPolyline.Points.Add(new Point(width * i / (numPoints - 1), values[i]));
                }
            }
        }
    }
}
