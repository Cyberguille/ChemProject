using Chem.Managment.Visual.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace Chem.Managment.Visual.Operations.Services
{
    public static class ServiceTwo
    {
        /* This service is nearly identical to ServiceOne. The only difference in the
         * two classes is that ServiceOne takes three times as long to perform its
         * work as this class. */

        /// <summary>
        /// Performs a service provided by this class
        /// </summary>
        /// <param name="workList">A list of work items (typically, file paths) to be processed.</param>
        /// <param name="viewModel">The Progress dialog view model for this application.</param>
        public static void DoWork(int[] workList, ProgressDialogViewModel viewModel)
        {
            /* We get a token source from the CancellationTokenSource and 
             * wrap it in a Parallel Options object so we can pass it to the 
             * Parallel.ForEach() method that will traverse the file list. */

            // Get a cancellation token
            var loopOptions = new ParallelOptions();
            loopOptions.CancellationToken = viewModel.TokenSource.Token;

            /* If the user cancels this task while in progress, the cancellation token passed
             * in will cause an OperationCanceledException to be thrown. We trap the exception
             * and set the Progress dialog view model to display a cancellation message. */

            // Process work items in parallel
            try
            {
                Parallel.ForEach(workList, loopOptions, t => ProcessWorkItem(viewModel));
            }
            catch (OperationCanceledException)
            {
                var ShowCancellationMessage = new Action(viewModel.ShowCancellationMessage);
                Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal, ShowCancellationMessage);
            }
        }

        /// <summary>
        /// Processes an item in the work list passed into this service.
        /// </summary>
        private static void ProcessWorkItem(ProgressDialogViewModel viewModel)
        {
            /* We don't perform any real work here. Instead, 
             * we simply kill time for 100 milliseconds. */

            // Simulate a time-consuming task
            //Thread.Sleep(100);

            /* Since this code is being executed on a backgound thread, we use the 
             * application Dispatcher to call a view model method on the main (UI) 
             * thread. Note that we increment the progress counter by one click,
             * since each work item takes one-third as long to process as each
             * ServiceTwo work item. */

            // Increment progress counter
            var IncrementProgressCounter = new Action<int>(viewModel.IncrementProgressCounter);
            Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal, IncrementProgressCounter, 1);
        }
    }
}
