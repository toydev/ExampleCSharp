using System.ComponentModel;
using System.Drawing;

namespace Example.ViewModels
{
    public class AnchorableViewModel : INotifyPropertyChanged
    {
        public AnchorableViewModel(string title, Icon icon)
        {
            Title = title;
            Icon = icon;
        }

        #region Property Title
        private string m_Title;
        public string Title
        {
            get
            {
                return m_Title;
            }
            set
            {
                if (m_Title != value)
                {
                    m_Title = value;
                    OnPropertyChanged("Title");
                }
            }
        }
        #endregion

        #region Property Icon
        private Icon m_Icon;
        public Icon Icon
        {
            get
            {
                return m_Icon;
            }
            set
            {
                if (m_Icon != value)
                {
                    m_Icon = value;
                    OnPropertyChanged("Icon");
                }
            }
        }
        #endregion

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
