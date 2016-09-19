using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace KiloWatts_For_Humanity.Views.Pages
{
    public partial class MainPage : ContentPage
    {
        //Size ImageSize;
        //private ImageSource PendingSource;
        public MainPage()
        {
            InitializeComponent();
        }

        //bool ImageDownloading = false;
        //private async void MainImage_SizeChanged(object sender, EventArgs e)
        //{
        //    if (!(MainImage.Width > 0 && MainImage.Height > 0))
        //        return;
        //    ImageSize = new Size(MainImage.Width, MainImage.Height);
        //    await Task.Delay(100);
        //    if (ImageSize.Width == MainImage.Width && ImageSize.Height == MainImage.Height)
        //    {
        //        if (ImageDownloading)
        //            return;
        //        else
        //        {
        //            ImageDownloading = true;
        //            try
        //            {
        //                while (MainImage.IsLoading)
        //                    await Task.Delay(100);
        //                WebRequest request = WebRequest.Create(new Uri($"http://kw4h.org:8080/render?target=03011.AD01.Battery_Voltage&height={ImageSize.Height}&width={ImageSize.Width}"));
        //                request.UseDefaultCredentials = true;
        //                request.Proxy.Credentials = request.Credentials;
        //                WebResponse response = (WebResponse)await request.GetResponseAsync();
        //                using (var s = response.GetResponseStream())
        //                {
        //                    List<byte> buffer = new List<byte>();
        //                    int curByte;
        //                    while ((curByte = s.ReadByte()) != -1)
        //                        buffer.Add((byte)curByte);
        //                    using (var ras = new System.IO.MemoryStream(buffer.ToArray()))
        //                    {
        //                        MainImage.Source = ImageSource.FromStream(() => ras);
        //                        System.Diagnostics.Debug.WriteLine("Image Downloaded!");
        //                        while (MainImage.IsLoading)
        //                            await Task.Delay(100);
        //                    }
        //                }
        //            }
        //            finally
        //            {
        //                ImageDownloading = false;
        //            }
        //        }
        //    }
        //}
    }
}
