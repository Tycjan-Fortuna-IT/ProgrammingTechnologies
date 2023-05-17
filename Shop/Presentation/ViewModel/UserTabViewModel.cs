using System.ComponentModel;
using System.Windows.Input;
using Presentation.ViewModel.Command;

namespace Presentation.ViewModel
{
    public class UserTabViewModel : IViewModel
    {
        
        public ICommand SwitchShopTabViewCommand { get; set; }

        public ICommand SwitchModTabViewCommand { get; set; }

        public UserTabViewModel()
        {
            this.SwitchShopTabViewCommand = new SwitchShopTabViewCommand();

            this.SwitchModTabViewCommand = new SwitchModTabViewCommand();
        }


    }
}