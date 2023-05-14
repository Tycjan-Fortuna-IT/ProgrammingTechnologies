using System.ComponentModel;
using System.Windows.Input;

namespace Presentation.ViewModel
{
    public partial class MainWindowViewModel : IViewModel
    {
        private IViewModel _selectedViewModel;

        public ICommand StartAppCommand;

        public ICommand ExitAppCommand;
        
        public MainWindowViewModel()
        {
            this.StartAppCommand = new UpdateViewModel(this);
        }

        public IViewModel SelectedViewModel
        {
            get => _selectedViewModel;
            set
            {
                _selectedViewModel = value;
                OnPropertyChanged(nameof(SelectedViewModel));
            }
        }

        public void switchView()
        {
            _selectedViewModel = new ShopTabViewModel();
            //_selectedViewModel.Show();
        }
    }
}
