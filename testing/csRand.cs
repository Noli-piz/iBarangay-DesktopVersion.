using Firebase.Storage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testing
{
    class csRand
    {

        ///Download
        private async void DownloadImage()
        {
            var webClient = new System.Net.WebClient();
            var storage = new FirebaseStorage("ibarangay-23725.appspot.com")
                .Child("systemicon")
                .Child("Normal.png")
                .GetDownloadUrlAsync();

            var url = await storage;
            DisplayImage(url);
        }

        private async void DisplayImage(String url)
        {
            var webClient = new System.Net.WebClient();
            var bytes = webClient.DownloadData(url);
            using (var ms = new MemoryStream(bytes, 0, bytes.Length))
            {
                ms.Write(bytes, 0, bytes.Length);
                var image = System.Drawing.Image.FromStream(ms, true);
                //pictureBox1.Image = image;
                ms.Dispose();
            }
        }
    }
}
