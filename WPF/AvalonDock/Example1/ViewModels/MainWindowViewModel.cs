using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Example.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        #region Property Documents
        private ObservableCollection<object> m_Documents = new ObservableCollection<object>();
        public ObservableCollection<object> Documents
        {
            get
            {
                return m_Documents;
            }
            set
            {
                if (m_Documents != value)
                {
                    m_Documents = value;
                    OnPropertyChanged("Documents");
                }
            }
        }
        #endregion

        #region Property Anchorables
        private ObservableCollection<object> m_Anchorables = new ObservableCollection<object>();
        public ObservableCollection<object> Anchorables
        {
            get
            {
                return m_Anchorables;
            }
            set
            {
                if (m_Anchorables != value)
                {
                    m_Anchorables = value;
                    OnPropertyChanged("Anchorables");
                }
            }
        }
        #endregion

        #region Implements INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
