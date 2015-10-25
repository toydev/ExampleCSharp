using System.Threading.Tasks;
using System.Windows;

namespace CustomProgressDialog
{

    /// <summary>
    /// ProgressDialog.xaml の相互作用ロジック
    /// </summary>
    public partial class ProgressDialog : Window
    {

        System.Action<ProgressDialog> m_action;

        public ProgressDialog(Window parent, string title, string message, System.Action<ProgressDialog> action)
        {
            InitializeComponent();

            this.Owner = parent;
            this.Title = title;
            messageLabel.Text = message;
            m_action = action;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Task task = Task.Factory.StartNew(() =>
            {
                m_action.Invoke(this);
                Dispatcher.BeginInvoke(new System.Action(() =>
                {
                    DialogResult = true;
                }));
            });
        }

        public void NotifyProgress(int min, int max, int value)
        {
            Dispatcher.BeginInvoke(new System.Action(() =>
            {
                progressBar.Minimum = min;
                progressBar.Maximum = max;
                progressBar.Value = value;
            }));
        }
    }

}
