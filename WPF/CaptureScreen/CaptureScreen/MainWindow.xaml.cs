using System;
using System.Drawing;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media.Imaging;

namespace CaptureScreen
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        public static extern bool DeleteObject(IntPtr hObject);

        public static BitmapSource ToWPFBitmap(System.Drawing.Bitmap bitmap)
        {
            var hBitmap = bitmap.GetHbitmap();

            BitmapSource source;
            try
            {
                source = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                    hBitmap, IntPtr.Zero, Int32Rect.Empty,
                    BitmapSizeOptions.FromEmptyOptions());
            }
            finally
            {
                DeleteObject(hBitmap);
            }
            return source;
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(
                Screen.PrimaryScreen.Bounds.Width,
                Screen.PrimaryScreen.Bounds.Height
            );
            Graphics g = Graphics.FromImage(bmp);
            g.CopyFromScreen(new System.Drawing.Point(0, 0), new System.Drawing.Point(0, 0), bmp.Size);
            g.Dispose();

            //表示
            image.Source = ToWPFBitmap(bmp);
        }
    }
}
