using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Chem.Managment.Visual.Operations.Commands
{
    public class SubstanceCommand:ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            var frame = (Frame)Application.Current.MainWindow.FindName("frame");
            var substance = ((MainWindow)Application.Current.MainWindow).HomeSubstance;
            frame.Navigate(substance);
        }
    }
}
