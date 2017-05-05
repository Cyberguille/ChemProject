using Chem.Managment.Visual.Operations.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Chem.Managment.Visual.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        #region Events

        public event EventHandler WorkStarted;
        public event EventHandler WorkEnded;

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor.
        /// </summary>
        public MainWindowViewModel()
        {
            this.Initialize();
        }

        #endregion

        #region Child View Models

        /// <summary>
        /// Progress dialog view model.
        /// </summary>
        public ProgressDialogViewModel ProgressDialogViewModel { get; set; }

        #endregion

        #region Command Properties

        /// <summary>
        /// Executes the demo operation.
        /// </summary>
        public ICommand DoUpdate { get; set; }


        public ICommand ShowEntitiesPage { get; set; }

        public ICommand ShowSubstancePage { get; set; }
        #endregion

        #region Data Properties

        /* No data properties in this demo */

        #endregion

        #region Event Invokers

        /// <summary>
        /// Raises the WorkStarting event.
        /// </summary>
        internal void RaiseWorkStartedEvent()
        {
            // Exit if no subscribers
            if (WorkStarted == null) return;

            // Raise event
            WorkStarted(this, new EventArgs());
        }

        /// <summary>
        /// Raises the WorkEnding event.
        /// </summary>
        internal void RaiseWorkEndedEvent()
        {
            // Exit if no subscribers
            if (WorkEnded == null) return;

            // Raise event
            WorkEnded(this, new EventArgs());
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Initializes the view model.
        /// </summary>
        private void Initialize()
        {
            // Initialize command properties
            DoUpdate = new UpdateCommand(this);

            ShowEntitiesPage = new EntitiesCommand();

            ShowSubstancePage = new SubstanceCommand();
            // Initialize child view models
            this.ProgressDialogViewModel = new ProgressDialogViewModel(this);
        }

        #endregion
    }
}
