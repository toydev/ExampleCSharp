using System.ComponentModel;

namespace Example.ViewModels
{
    public class AnchorableViewModel : INotifyPropertyChanged
    {
        #region Property Text
        private string m_Text;
        public string Text
        {
            get
            {
                return m_Text;
            }
            set
            {
                if (m_Text != value)
                {
                    m_Text = value;
                    OnPropertyChanged("Text");
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
