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
    public class EntitiesCommand : ICommand
    {
        public bool CanExecute(object parameter)
        {
            //Faltaria hacer verificacione como por ejemplo
            // si esta en la ventana entities retornar false
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            var frame = (Frame)Application.Current.MainWindow.FindName("frame");
            var entitypage = ((MainWindow)Application.Current.MainWindow).HomeEntities;

            frame.Navigate(entitypage);
        }
    }
}
