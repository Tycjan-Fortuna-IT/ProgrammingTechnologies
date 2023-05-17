using System.ComponentModel;
using System.Windows.Input;
using Presentation.ViewModel.Command;

namespace Presentation.ViewModel
{
    public class ModTabViewModel : IViewModel
    {
        
        public ICommand SwitchShopTabViewCommand { get; set; }

        public ICommand SwitchUserTabViewCommand { get; set; }

        public ModTabViewModel()
        {
            this.SwitchShopTabViewCommand = new SwitchShopTabViewCommand();

            this.SwitchUserTabViewCommand = new SwitchUserTabViewCommand();
        }


    }
}