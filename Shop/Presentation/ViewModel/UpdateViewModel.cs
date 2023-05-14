using System;
using System.Windows.Input;

namespace Presentation.ViewModel
{
    class UpdateViewModel : ICommand
    {
        private IViewModel _viewModel;

        public event EventHandler CanExecuteChanged;

        public UpdateViewModel(IViewModel viewModel) 
        {
            this._viewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }

        public void Execute(object parameter)
        {
            this._viewModel.SelectedViewModel = new ShopTabViewModel();
        }
    }
}
