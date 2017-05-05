using Chem.Managment.Visual.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Chem.Managment.Visual.Services
{
    public static class ViewServices
    {
        #region Fields

        // Member variables
        private static ProgressDialog m_ProgressDialog;

        #endregion

        #region Service Methods

        /// <summary>
        /// Hides the Progress dialog.
        /// </summary>
        internal static void CloseProgressDialog()
        {
            m_ProgressDialog.Close();
        }

        /// <summary>
        /// Shows the Progress dialog.
        /// </summary>
        internal static void ShowProgressDialog(Window mainWindow, ProgressDialogViewModel viewModel)
        {
            m_ProgressDialog = new ProgressDialog();
            m_ProgressDialog.Owner = mainWindow;
            m_ProgressDialog.DataContext = viewModel;
            m_ProgressDialog.Show();
        }

        #endregion
    }
}
