using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Presentation.ViewModel
{
    public class HomeViewModel : IViewModel
    {
        public ICommand StartAppCommand { get; set; }

        public HomeViewModel()
        {
            this.StartAppCommand = new UpdateViewModelCommand(this);
        }
    }
}
