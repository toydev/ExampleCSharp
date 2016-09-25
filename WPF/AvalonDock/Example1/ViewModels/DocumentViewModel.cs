using System.ComponentModel;

namespace Example.ViewModels
{
    public class DocumentViewModel : INotifyPropertyChanged
    {
        #region Implements INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
