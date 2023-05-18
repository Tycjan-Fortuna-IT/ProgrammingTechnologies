using System;
using System.ComponentModel;
using System.Windows.Input;

namespace Presentation.ViewModel
{
    public partial class MainWindowViewModel : IViewModel
    {
        private IViewModel _selectedViewModel { get; set; }


        public MainWindowViewModel()
        {
            this._selectedViewModel = new HomeViewModel();
        }

        public new IViewModel SelectedViewModel
        {
            get => _selectedViewModel;
            set
            {
                _selectedViewModel = value;

                OnPropertyChanged(nameof(SelectedViewModel));
            }
        }
    }
}
