using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;
using System.Diagnostics;

namespace Presentation.ViewModel.Command
{
    public class SwitchUserTabViewCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public SwitchUserTabViewCommand()
        {
            
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Trace.WriteLine("text");
            var userControl = parameter as UserControl;
            var parentWindow = Window.GetWindow(userControl);

            if (parentWindow != null)
            {
                if (parentWindow.DataContext is MainWindowViewModel mainViewModel)
                {
                    mainViewModel.SelectedViewModel = new UserTabViewModel();
                }
            }
        }
    }
}
