using System.Collections;
using System.ComponentModel;
using System.Windows.Input;
using Presentation.ViewModel.Command;

namespace Presentation.ViewModel
{
    public class ShopTabViewModel : IViewModel
    {        
        public ICommand SwitchUserTabViewCommand { get; set; }

        public ICommand SwitchModTabViewCommand { get; set; }

        public ShopTabViewModel()
        {
            this.SwitchUserTabViewCommand = new SwitchUserTabViewCommand();

            this.SwitchModTabViewCommand = new SwitchModTabViewCommand();
        }
    }
}
