﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Presentation.ViewModel.Command
{
    public class SearchDatabaseGamesCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public SearchDatabaseGamesCommand()
        {

        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
           
        }
    }
}
