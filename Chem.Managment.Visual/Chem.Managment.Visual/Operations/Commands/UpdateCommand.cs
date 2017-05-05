using Chem.DataBase;
using Chem.Managment.Visual.Operations.Services;
using Chem.Managment.Visual.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Chem.Managment.Visual.Migration;


namespace Chem.Managment.Visual.Operations.Commands
{
    public class UpdateCommand : ICommand
    {
        #region Fields

        // Member variables
        private MainWindowViewModel m_ViewModel;

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor.
        /// </summary>
        public UpdateCommand(MainWindowViewModel viewModel)
        {
            m_ViewModel = viewModel;
        }

        #endregion

        #region ICommand Members

        /// <summary>
        /// Whether the DoDemoWorkCommand is enabled.
        /// </summary>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Actions to take when CanExecute() changes.
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// Executes the DoDemoWorkCommand
        /// </summary>
        public void Execute(object parameter)
        {
            // Create OpenFileDialog

            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();



            // Set filter for file extension and default file extension

            dlg.DefaultExt = ".xlsx";

            dlg.Filter = "Text documents (.xlsx)|*.xlsx";



            // Display OpenFileDialog by calling ShowDialog method

            Nullable<bool> result = dlg.ShowDialog();



            // Get the selected file name and display in a TextBox

            if (result == true)
            {

                // Open document

                string filename = dlg.FileName;



                /* A typical task would involve processing a list of files, or similar work.
                 * To simulate this type of task, we will create a simple list of integers,
                 * which we will call the 'workList'. Each background task will traverse this
                 * list in order to perform its assigned work. */

                // Initialize
                var progressDialogViewModel = m_ViewModel.ProgressDialogViewModel;
                progressDialogViewModel.ClearViewModel();

                /* All background tasks can be cancelled by clicking a Cancel button on 
                 * the progress dialog. Clicking the button invokes a Cancel command in 
                 * the ProgressDialogViewModel. The .NET Task Parallel Library uses a 
                 * CancellationTokenSource (CTS) to cancel background tasks. We create 
                 * a CTS here and pass it to the ProgressDialogViewModel, so that the 
                 * Cancel command has access when it needs it. */

                // Set the view model's token source
                progressDialogViewModel.TokenSource = new CancellationTokenSource();

                /* The ProgressDialogViewModel.ProgressMax property holds the maximum
                 * progress value for this particular operation. The progress percentage 
                 * is calculated as Progress/ProgressMax. This operation has two background 
                 * tasks, each of which traverses the work list. The first task takes three 
                 * times as long to traverse the list as the second task, so we set the
                 * ProgressMax property to four times the length of the work list. 
                 * 
                 * The first task will advance the Progress property three clicks for each 
                 * item on the list, and the second task will advance the property one click 
                 * for each item. As a result, when the first task is complete, the Progress 
                 * dialog will show 75% complete, and it will show 100% complete when the 
                 * second task completes. */



                // Announce that work is starting
                m_ViewModel.RaiseWorkStartedEvent();

                // Launch first background task

                var taskOne = Task.Factory.StartNew(() => ExcelDB.MigrateSubstance(filename, progressDialogViewModel));

                taskOne.ContinueWith(t => m_ViewModel.RaiseWorkEndedEvent(),
                                     TaskScheduler.FromCurrentSynchronizationContext());
            }

        }

        #endregion
    }
}
