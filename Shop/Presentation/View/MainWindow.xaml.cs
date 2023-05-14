﻿using Presentation.ViewModel;
using System.Windows;

namespace Presentation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainWindowViewModel();
        }

        //private void startApp(object sender, RoutedEventArgs e)
        //{
            
        //}

        //private void exitApp(object sender, RoutedEventArgs e)
        //{

        //}
    }
}
