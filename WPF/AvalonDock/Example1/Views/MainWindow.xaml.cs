using System.Windows;

using Example.ViewModels;

namespace Example.Views
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindowViewModel ViewModel { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = ViewModel = new MainWindowViewModel();
        }

        private void addDocumentButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.Documents.Add(new DocumentViewModel());
        }

        private void addAnchorableButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.Anchorables.Add(new AnchorableViewModel());
        }
    }
}
