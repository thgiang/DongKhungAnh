using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DongKhungAnh
{
    class Helper
    {
        public string DownloadImage(string PictureUrl)
        {
            try
            {
                string randomPath = Path.GetTempFileName();
                if (PictureUrl.Contains("http") == false)
                {
                    PictureUrl = "https:" + PictureUrl;
                }
                using (WebClient webClient = new WebClient())
                {
                    webClient.DownloadFile(PictureUrl, randomPath);
                    return randomPath;
                }
            }
            catch
            {
                Console.WriteLine("ERROR: Không tải đc file " + PictureUrl);
                return "CANNOT_DOWNLOAD_FILE";
            }

        }

        // Sinh ra captcha
        public static string GenCaptcha(string text)
        {
            Random random = new Random();
            Bitmap myBitmap = new Bitmap(300, 100);
            Graphics g = Graphics.FromImage(myBitmap);
            char[] chars = text.ToCharArray();
            int i = 0;
            foreach (char c in chars)
            {
                g.DrawString(c.ToString(), new Font("Segoe Script", random.Next(25, 35)), Brushes.Black, new PointF(55 + i * 27, random.Next(10, 20)));
                i++;
            }

            string path = Path.GetTempFileName();
            myBitmap.Save(path);
            return path;
        }

        public static string LowerFisrtLetter(string s)
        {
            if (s != string.Empty && char.IsUpper(s[0]))
            {
                s = char.ToLower(s[0]) + s.Substring(1);
            }
            return s;
        }

        public static string AddFrameToImage(string framePath, string photoPath)
        {
            Image frame = Image.FromFile(framePath);
            Image photo = Image.FromFile(photoPath);
            using (frame)
            {
                var width = photo.Width; //Set the final image width. Usually it'll be photo.width
                var height = photo.Height; //The same with height
                using (var bitmap = new Bitmap(width, height))
                {
                    using (var canvas = Graphics.FromImage(bitmap))
                    {
                        canvas.InterpolationMode = InterpolationMode.High;
                        canvas.DrawImage(photo,
                            new Rectangle(0,
                                0,
                                width,
                                height),
                            new Rectangle(0,
                                0,
                                photo.Width,
                                photo.Height),
                            GraphicsUnit.Pixel);
                        canvas.DrawImage(frame, new Rectangle(0,
                            0,
                            width,
                            height), new Rectangle(0,
                            0,
                            frame.Width,
                            frame.Height), GraphicsUnit.Pixel);

                        canvas.Save();
                    }
                    //string randomPath = Path.GetTempFileName();
                    string randomPath = photoPath + Path.GetRandomFileName() + ".png"; 
                    bitmap.Save(randomPath, ImageFormat.Png);
                    return randomPath;
                }
            }
        }
    }
}
