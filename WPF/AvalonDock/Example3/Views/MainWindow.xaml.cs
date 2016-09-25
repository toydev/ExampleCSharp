using System.Drawing;
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
            DocumentViewModel model = new DocumentViewModel(
                "DocumentTitle" + (ViewModel.Documents.Count + 1),
                SystemIcons.Information);
            model.Text = "Document" + (ViewModel.Documents.Count + 1);
            ViewModel.Documents.Add(model);
        }

        private void addAnchorableButton_Click(object sender, RoutedEventArgs e)
        {
            AnchorableViewModel model = new AnchorableViewModel(
                "AnchorableTitle" + (ViewModel.Anchorables.Count + 1),
                SystemIcons.Information);
            model.Text = "Anchorable" + (ViewModel.Anchorables.Count + 1);
            ViewModel.Anchorables.Add(model);
        }
    }
}
