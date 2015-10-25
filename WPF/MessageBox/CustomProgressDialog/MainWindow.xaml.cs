using System;
using System.Threading;
using System.Windows;

namespace CustomProgressDialog
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

        private void ShowProgressDialogButton_Click(object sender, RoutedEventArgs e)
        {
            ProgressDialog dialog = new ProgressDialog(
                this,
                "プログレスダイアログのタイトル",
                "プログレスダイアログに表示するメッセージをここに入力する。",
                new System.Action<ProgressDialog>((x) =>
                {
                    // 処理内容をここに入力する
                    for (int i = 0; i < 100; ++i)
                    {
                        Thread.Sleep(100);
                        x.NotifyProgress(0, 100, i);
                    }
                }));
            dialog.ShowDialog();
        }
    }
}
