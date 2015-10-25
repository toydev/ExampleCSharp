using System.Windows;

namespace SimpleMessageBox
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

        private void ShowMessageBoxButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("メッセージボックスに表示するメッセージをここに入力する。", "メッセージボックスのタイトル");
        }
    }
}
