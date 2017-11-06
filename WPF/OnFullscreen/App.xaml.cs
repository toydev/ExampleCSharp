using System;
using System.Threading;
using System.Windows;

namespace OnFullscreen
{
    /// <summary>
    /// App.xaml の相互作用ロジック
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            Thread.Sleep(5 * 1000);
            Console.Beep();
        }
    }
}
