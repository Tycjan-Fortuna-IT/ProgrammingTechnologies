using System.ComponentModel;

namespace Presentation.ViewModel
{
    public class IViewModel : INotifyPropertyChanged
    {
        public IViewModel SelectedViewModel;

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
