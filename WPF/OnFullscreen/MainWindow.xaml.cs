using System;
using System.Windows;
using System.Windows.Interop;

namespace OnFullscreen
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        private void Window_SourceInitialized(object sender, EventArgs e)
        {
            WindowUtils.AddExStyle(this, WindowUtils.WS_EX_NOACTIVATE);
        }

        public MainWindow()
        {
            InitializeComponent();

            WindowInteropHelper helper = new WindowInteropHelper(this);
            WindowUtils.SetWindowPos(
                helper.Handle,
                (IntPtr)SpecialWindowHandles.HWND_TOP,
                0, 0, 0, 0,
                SetWindowPosFlags.SWP_NOMOVE | SetWindowPosFlags.SWP_NOSIZE);
        }
    }
}
