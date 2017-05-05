using Chem.Managment.Visual.Services;
using Chem.Managment.Visual.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Chem.Managment.Visual
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            AppDomain.CurrentDomain.SetData("DataDirectory",
    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            InitializeComponent();
            HomeSubstance = new HomeSubstance();
            HomeEntities = new HomeEntities();
          DocumentViewer = new DocumentViewer();
            var frame = (Frame)Application.Current.MainWindow.FindName("frame");
            frame.Navigate(HomeSubstance);
        }

        #region Event Handlers

        /// <summary>
        /// Subscribes to View Model events when data context is set.
        /// </summary>
        /// <remarks>
        /// This method subscribes to the view model's WorkStarting and
        /// WorkEnding events to control display of the Progress dialog
        /// provided by the application.
        /// </remarks>
        

        /// <summary>
        /// Closes the Progress dialog.
        /// </summary>
        private void OnWorkEnding(object sender, EventArgs e)
        {
            ViewServices.CloseProgressDialog();
        }

        /// <summary>
        /// Displays the Progress dialog.
        /// </summary>
        private void OnWorkStarting(object sender, EventArgs e)
        {
            var mainWindowViewModel = (MainWindowViewModel)this.DataContext;
            var progressDialogViewModel = mainWindowViewModel.ProgressDialogViewModel;
            ViewServices.ShowProgressDialog(Application.Current.MainWindow, progressDialogViewModel);
        }

        #endregion

        private void OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            var viewModel = (MainWindowViewModel)e.NewValue;
            viewModel.WorkStarted += OnWorkStarting;
            viewModel.WorkEnded += OnWorkEnding;
        }

        public HomeSubstance HomeSubstance { get; set; }

        public HomeEntities HomeEntities { get; set; }

        public DocumentViewer DocumentViewer { get; set; }
    }
}
