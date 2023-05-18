using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Presentation.ViewModel.Command
{
    public class UpdateViewModelCommand : ICommand
    {
        private IViewModel _viewModel;

        public event EventHandler CanExecuteChanged;

        public UpdateViewModelCommand(IViewModel viewModel) 
        {
            this._viewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            //Trace.WriteLine("text");
            var userControl = parameter as UserControl;
            var parentWindow = Window.GetWindow(userControl);

            if (parentWindow != null)
            {
                if (parentWindow.DataContext is MainWindowViewModel mainViewModel)
                {
                    mainViewModel.SelectedViewModel = new ShopTabViewModel();
                }
            }
        }
    }
}
