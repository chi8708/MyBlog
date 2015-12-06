using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Blog.Common
{
    public class Captcha
    {
        public byte[] GetImage(int length, out string checkcode)
        {
            checkcode = RandomText.String(length);
            Random random = new Random();

            Font font = new Font("Comic Sans MS", 18, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Pixel);
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;
            Bitmap bitmap = new Bitmap((int)Math.Ceiling((double)(length * 18)), 24, PixelFormat.Format24bppRgb);
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                graphics.Clear(Color.White);
                graphics.SmoothingMode = SmoothingMode.AntiAlias;
                graphics.TextRenderingHint = TextRenderingHint.AntiAlias;

                ///画图片的背景噪音线
                for (int i = 0; i < 5; i++)
                {
                    int x1 = random.Next(bitmap.Width);
                    int x2 = random.Next(bitmap.Width);
                    int y1 = random.Next(bitmap.Height);
                    int y2 = random.Next(bitmap.Height);
                    graphics.DrawLine(new Pen(Color.Silver), x1, y1, x2, y2);
                }

                graphics.DrawString(checkcode, font, Brushes.Black, new RectangleF(0f, 0f, (float)bitmap.Width, (float)bitmap.Height), stringFormat);

                ///画图片的前景噪音点
                for (int i = 0; i < 20; i++)
                {
                    int x = random.Next(bitmap.Width);
                    int y = random.Next(bitmap.Height);

                    bitmap.SetPixel(x, y, Color.FromArgb(random.Next()));
                }
            }
            bitmap = WaveDistortion(bitmap);
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            bitmap.Dispose();

            return ms.ToArray();
        }

        /// <summary>
        /// 波纹扭曲
        /// </summary>
        private Bitmap WaveDistortion(Bitmap bitmap)
        {
            Random rnd = new Random();

            var width = bitmap.Width;
            var height = bitmap.Height;

            Bitmap destBmp = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            {
                Color foreColor = Color.FromArgb(rnd.Next(10, 100), rnd.Next(10, 100), rnd.Next(10, 100));
                Color backColor = Color.FromArgb(rnd.Next(200, 250), rnd.Next(200, 250), rnd.Next(200, 250));

                using (Graphics g = Graphics.FromImage(destBmp))
                {
                    g.Clear(Color.White);

                    // periods 时间
                    double rand1 = rnd.Next(710000, 1200000) / 10000000.0;
                    double rand2 = rnd.Next(710000, 1200000) / 10000000.0;
                    double rand3 = rnd.Next(710000, 1200000) / 10000000.0;
                    double rand4 = rnd.Next(710000, 1200000) / 10000000.0;

                    // phases  相位
                    double rand5 = rnd.Next(0, 31415926) / 10000000.0;
                    double rand6 = rnd.Next(0, 31415926) / 10000000.0;
                    double rand7 = rnd.Next(0, 31415926) / 10000000.0;
                    double rand8 = rnd.Next(0, 31415926) / 10000000.0;

                    // amplitudes 振幅
                    double rand9 = rnd.Next(330, 420) / 110.0;
                    double rand10 = rnd.Next(330, 450) / 110.0;
                    double amplitudesFactor = rnd.Next(5, 6) / 12.0;//振幅小点防止出界
                    double center = width / 2.0;

                    //wave distortion 波纹扭曲
                    BitmapData destData = destBmp.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, destBmp.PixelFormat);
                    BitmapData srcData = bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, bitmap.PixelFormat);
                    for (var x = 0; x < width; x++)
                    {
                        for (var y = 0; y < height; y++)
                        {
                            var sx = x + (Math.Sin(x * rand1 + rand5)
                                        + Math.Sin(y * rand2 + rand6)) * rand9 - width / 2 + center + 1;
                            var sy = y + (Math.Sin(x * rand3 + rand7)
                                        + Math.Sin(y * rand4 + rand8)) * rand10 * amplitudesFactor;

                            int color, color_x, color_y, color_xy;
                            Color overColor = Color.Empty;

                            if (sx < 0 || sy < 0 || sx >= width - 1 || sy >= height - 1)
                            {
                                continue;
                            }
                            else
                            {
                                color = BitmapDataColorAt(srcData, (int)sx, (int)sy).B;
                                color_x = BitmapDataColorAt(srcData, (int)(sx + 1), (int)sy).B;
                                color_y = BitmapDataColorAt(srcData, (int)sx, (int)(sy + 1)).B;
                                color_xy = BitmapDataColorAt(srcData, (int)(sx + 1), (int)(sy + 1)).B;
                            }

                            if (color == 255 && color_x == 255 && color_y == 255 && color_xy == 255)
                            {
                                continue;
                            }
                            else if (color == 0 && color_x == 0 && color_y == 0 && color_xy == 0)
                            {
                                overColor = Color.FromArgb(foreColor.R, foreColor.G, foreColor.B);
                            }

                            else
                            {
                                double frsx = sx - Math.Floor(sx);
                                double frsy = sy - Math.Floor(sy);
                                double frsx1 = 1 - frsx;
                                double frsy1 = 1 - frsy;

                                double newColor =
                                     color * frsx1 * frsy1 +
                                     color_x * frsx * frsy1 +
                                     color_y * frsx1 * frsy +
                                     color_xy * frsx * frsy;

                                if (newColor > 255) newColor = 255;
                                newColor = newColor / 255;
                                double newcolor0 = 1 - newColor;

                                int newred = Math.Min((int)(newcolor0 * foreColor.R + newColor * backColor.R), 255);
                                int newgreen = Math.Min((int)(newcolor0 * foreColor.G + newColor * backColor.G), 255);
                                int newblue = Math.Min((int)(newcolor0 * foreColor.B + newColor * backColor.B), 255);
                                overColor = Color.FromArgb(newred, newgreen, newblue);
                            }
                            BitmapDataColorSet(destData, x, y, overColor);
                        }
                    }
                    destBmp.UnlockBits(destData);
                    bitmap.UnlockBits(srcData);
                }
                if (bitmap != null)
                    bitmap.Dispose();
            }
            return destBmp;
        }

        /// <summary>
        /// 获得 BitmapData 指定坐标的颜色信息
        /// </summary>
        /// <param name="srcData">从图像数据获得颜色 必须为 PixelFormat.Format24bppRgb 格式图像数据</param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>x,y 坐标的颜色数据</returns>
        /// <remarks>
        /// Format24BppRgb 已知X，Y坐标，像素第一个元素的位置为Scan0+(Y*Stride)+(X*3)。
        /// 这是blue字节的位置，接下来的2个字节分别含有green、red数据。
        /// </remarks>
        private Color BitmapDataColorAt(BitmapData srcData, int x, int y)
        {
            byte[] rgbValues = new byte[3];
            Marshal.Copy((IntPtr)((int)srcData.Scan0 + ((y * srcData.Stride) + (x * 3))), rgbValues, 0, 3);
            return Color.FromArgb(rgbValues[2], rgbValues[1], rgbValues[0]);
        }

        /// <summary>
        /// 设置 BitmapData 指定坐标的颜色信息
        /// </summary>
        /// <param name="destData">设置图像数据的颜色 必须为 PixelFormat.Format24bppRgb 格式图像数据</param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="color">待设置颜色</param>
        /// <remarks>
        /// Format24BppRgb 已知X，Y坐标，像素第一个元素的位置为Scan0+(Y*Stride)+(X*3)。
        /// 这是blue字节的位置，接下来的2个字节分别含有green、red数据。
        /// </remarks>
        private void BitmapDataColorSet(BitmapData destData, int x, int y, Color color)
        {
            byte[] rgbValues = new byte[3] { color.B, color.G, color.R };
            Marshal.Copy(rgbValues, 0, (IntPtr)((int)destData.Scan0 + ((y * destData.Stride) + (x * 3))), 3);
        }
    }

    public class RandomText
    {
        static readonly string[] source ={"2","3","4","5","6","7","8","9",
            "A","B","C","D","E","F","G","H","J","K","M","N","P","Q","R","S","T","U","V","W","X","Y","Z"};

        private static Random _random;

        static RandomText()
        {
            _random = new Random(Environment.TickCount);
        }

        public static int Number(int minValue, int maxValue)
        {
            return _random.Next(minValue, maxValue);
        }

        public static string String(int length)
        {
            StringBuilder s = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                int index = _random.Next(0, source.Length - 1);
                s.Append(source[index]);
            }

            return s.ToString();
        }

        public static string CharOnly(int length)
        {
            StringBuilder s = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                int c = _random.Next(97, 123);

                if (_random.Next() % 2 == 0)
                    c -= 32;

                s.Append(Convert.ToChar(c));
            }

            return s.ToString();
        }


    }
}
