using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using LowadiBot.Infrastructure.Commands.Base;

namespace LowadiBot.Infrastructure.Commands.Windows
{
    internal class FormWindowsState : Command
    {
        override public bool CanExecute(object parameter) => true;

        override public void Execute(object parameter)
        {
            Application.Current.MainWindow.WindowState ^= WindowState.Maximized;
            Application.Current.MainWindow.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
        }
    }
}
