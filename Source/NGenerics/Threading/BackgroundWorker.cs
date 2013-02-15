/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html. 
*/

using System;
using System.ComponentModel;
using System.Threading;

namespace NGenerics.Threading
{
    /// <summary>
    /// Generic Implementation for BackgroundWorker. Executes an operation on a separate thread.
    /// </summary>
    /// <remarks>
    /// This is a temporary solution until one is included in the .net framework. See http://connect.microsoft.com/VisualStudio/feedback/ViewFeedback.aspx?FeedbackID=93696.
    /// </remarks>
    /// <typeparam name="TInput">The type of the argument that will be passed to the background operation.</typeparam>
    /// <typeparam name="TOutput">The type of the return value from the background operation.</typeparam>
    /// <typeparam name="TProgress">The type of state that will be passed back to notify the calling thread of a change in progress.</typeparam>
    public class BackgroundWorker<TInput, TOutput, TProgress>
    {

        #region Globals

        /// <summary>
        /// Gets or sets the async operation.
        /// </summary>
        /// <value>The async operation.</value>
        protected AsyncOperation AsyncOperation { get; private set; }

        private readonly SendOrPostCallback operationCompleted;
        private readonly Action<TInput> threadStart;

        #endregion

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="BackgroundWorker{TInput,TOutput,TProgress}"/> class.
        /// </summary>
        public BackgroundWorker()
        {
            ThrowExceptionOnCompleted = true;
            threadStart = WorkerThreadStart;
            operationCompleted = AsyncOperationCompleted;
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Requests cancellation of a pending background operation.
        /// </summary>
        /// <exception cref="InvalidOperationException"><see cref="WorkerSupportsCancellation"/> is <see langword="false"/>.</exception>
        public void CancelAsync()
        {
            if (!WorkerSupportsCancellation)
            {
                throw new InvalidOperationException("BackgroundWorker_WorkerDoesntSupportCancellation");
            }
            CancellationPending = true;
        }

        /// <summary>
        /// Calls the <see cref="ProgressChanged"/> delegate.
        /// </summary>
        /// <param name="percentProgress">The percentage, from 0 to 100, of the background operation that is complete.</param>
        /// <exception cref="InvalidOperationException">The <see cref="WorkerReportsProgress"/> property is set to false.</exception>
        public void ReportProgress(int percentProgress)
        {
            ReportProgress(percentProgress, default(TProgress));
        }

        /// <summary>
        /// Calls the <see cref="ProgressChanged"/> delegate.
        /// </summary>
        /// <param name="percentProgress">The percentage, from 0 to 100, of the background operation that is complete.</param>
        /// <param name="userState">The state to pass to <see cref="ProgressChanged"/>.</param>
        /// <exception cref="InvalidOperationException">The <see cref="WorkerReportsProgress"/> property is set to false.</exception>
        public void ReportProgress(int percentProgress, TProgress userState)
        {
            if (!WorkerReportsProgress)
            {
                throw new InvalidOperationException("BackgroundWorker_WorkerDoesntReportProgress");
            }
            var eventArgs = new ProgressChangedEventArgs<TProgress>(percentProgress, userState);
            if (AsyncOperation == null)
            {
                OnProgressChanged(eventArgs);
            }
            else
            {
                AsyncOperation.Post(state => OnProgressChanged((ProgressChangedEventArgs<TProgress>)state), eventArgs);
            }
        }


        /// <summary>
        /// Blocks the calling <see cref="Thread"/> until <see cref="IsBusy"/> is false.
        /// </summary>
        public void SleepWhileBusy()
        {
            while (IsBusy)
            {
                Thread.Sleep(10);
            }
        }

        /// <summary>
        /// Executes an <see cref="Action{T}"/> on the calling thread.
        /// </summary>
        /// <typeparam name="T">The type of the argument.</typeparam>
        /// <param name="action">The <see cref="Action{T}"/> to execute.</param>
        /// <param name="arg">Thee argument to pass to <paramref name="action"/></param>
        public void ExecuteOnCallingThread<T>(Action<T> action, T arg)
        {
            if (AsyncOperation == null)
            {
                action(arg);
            }
            else
            {
                AsyncOperation.Post(state => action((T)state), arg);
            }
        }


        /// <summary>
        /// Starts execution of a background operation. 
        /// </summary>
        /// <exception cref="InvalidOperationException"><see cref="IsBusy"/> is <see langword="true"/>.</exception>
        public void RunWorkerAsync()
        {
            RunWorkerAsync(default(TInput));
        }

        /// <summary>
        /// Starts execution of a background operation. 
        /// </summary>
        /// <param name="argument">The argument to pass to <see cref="DoWork"/>.</param>
        /// <exception cref="InvalidOperationException"><see cref="IsBusy"/> is <see langword="true"/>.</exception>
        public virtual void RunWorkerAsync(TInput argument)
        {
            if (IsBusy)
            {
                throw new InvalidOperationException("BackgroundWorker_WorkerAlreadyRunning");
            }
            IsBusy = true;
            CancellationPending = false;
            AsyncOperation = AsyncOperationManager.CreateOperation(null);
            threadStart.BeginInvoke(argument, null, null);
        }

        /// <summary>
        /// Gets a value indicating whether the application has requested cancellation of a background operation.
        /// </summary>
        /// <returns><see langword="true"/> if the application has requested cancellation of a background operation; otherwise, <see langword="false"/>. The default is <see langword="false"/>.</returns>
        public bool CancellationPending { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the <see cref="BackgroundWorker{TInput,TOutput,TProgress}"/> is running an asynchronous operation.
        /// </summary>
        /// <returns><see langword="true"/>, if the <see cref="BackgroundWorker{TInput,TOutput,TProgress}"/> is running an asynchronous operation; otherwise, <see langword="false"/>.</returns>
        public bool IsBusy { get; private set; }

        /// <summary>
        /// Gets or sets a value indicating whether the <see cref="BackgroundWorker{TInput,TOutput,TProgress}"/> can report progress updates.
        /// </summary>
        /// <return><see langword="true"/> if the <see cref="BackgroundWorker{TInput,TOutput,TProgress}"/> supports progress updates; otherwise <see langword="false"/>. The default is <see langword="false"/>.</return>
        public bool WorkerReportsProgress { get; set; }

        /// <summary>
        /// Gets or sets whether to throw the <see cref="Exception"/> on <see cref="OnRunWorkerCompleted"/> if one exists in <see cref="AsyncCompletedEventArgs{TState}.Error"/>.
        /// </summary>
        /// <return><see langword="true"/> if the <see cref="BackgroundWorker{TInput,TOutput,TProgress}"/> throws the <see cref="Exception"/> on <see cref="OnRunWorkerCompleted"/> if one exists in <see cref="AsyncCompletedEventArgs{TState}.Error"/>; otherwise <see langword="false"/>. The default is <see langword="true"/>.</return>
        public bool ThrowExceptionOnCompleted { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the <see cref="BackgroundWorker{TInput,TOutput,TProgress}"/> supports asynchronous cancellation.
        /// </summary>
        /// <return>
        /// <see langword="true"/> if the <see cref="BackgroundWorker{TInput,TOutput,TProgress}"/> supports cancellation; otherwise <see langword="false"/>. The default is <see langword="false"/>.
        /// </return>
        public bool WorkerSupportsCancellation { get; set; }

        /// <summary>
        /// The <see cref="Func{T,TResult}"/> to execute on the background <see cref="Thread"/>.
        /// </summary>
        /// <remarks>
        /// Executed on a background <see cref="Thread"/>. 
        /// The first parameter will be the <see cref="BackgroundWorker{TInput,TOutput,TProgress}"/> that is executing the delegate.
        /// </remarks>
        public Action<object, DoWorkEventArgs<TInput, TOutput>> DoWork { get; set; }

        /// <summary>
        /// Notifies the calling <see cref="Thread"/> of a progress change on the background <see cref="Thread"/>.
        /// </summary>
        /// <remarks>
        /// Called on the same thread that <see cref="RunWorkerAsync()"/> was called on.
        /// The first parameter will be the <see cref="BackgroundWorker{TInput,TOutput,TProgress}"/> that is executing the delegate.
        /// </remarks>
        public Action<object, ProgressChangedEventArgs<TProgress>> ProgressChanged { get; set; }

        /// <summary>
        /// Notifies the calling <see cref="Thread"/> that the background operation has completed, has been canceled, or has raised an exception.
        /// </summary>
        /// <remarks>
        /// Called on the same thread that <see cref="RunWorkerAsync()"/> was called on.
        /// The first parameter will be the <see cref="BackgroundWorker{TInput,TOutput,TProgress}"/> that is executing the delegate.
        /// </remarks>
        public Action<object, RunWorkerCompletedEventArgs<TOutput>> RunWorkerCompleted { get; set; }

        #endregion

        #region Protected Members

        /// <summary>
        /// Calls the <see cref="DoWork"/> delegate. 
        /// </summary>
        /// <param name="eventArgs">An EventArgs that contains the event data.</param>
        /// <exception cref="InvalidOperationException"><see cref="DoWork"/> is null.</exception>
        protected virtual void OnDoWork(DoWorkEventArgs<TInput, TOutput> eventArgs)
        {
            if (DoWork == null)
            {
                throw new InvalidOperationException("BackgroundWorker_DoWorkNoDefined");
            }
            DoWork(this, eventArgs);
        }


        /// <summary>
        /// Calls the <see cref="ProgressChanged"/> delegate. 
        /// </summary>
        /// <param name="eventArgs">An EventArgs that contains the event data.</param>
        protected virtual void OnProgressChanged(ProgressChangedEventArgs<TProgress> eventArgs)
        {
            if (ProgressChanged != null)
            {
                ProgressChanged(this, eventArgs);
            }
        }


        /// <summary>
        /// Calls the <see cref="ProgressChanged"/> delegate. 
        /// </summary>
        /// <param name="eventArgs">An EventArgs that contains the event data.</param>
        protected virtual void OnRunWorkerCompleted(RunWorkerCompletedEventArgs<TOutput> eventArgs)
        {
            if (ThrowExceptionOnCompleted && (eventArgs.Error != null))
            {
                throw eventArgs.Error;
            }
            if (RunWorkerCompleted != null)
            {
                RunWorkerCompleted(this, eventArgs);
            }
        }

        #endregion

        #region Private Members

        /// <summary>
        /// Event handler for when the operation complets.
        /// </summary>
        /// <param name="arg">The argument.</param>
        private void AsyncOperationCompleted(object arg)
        {
            IsBusy = false;
            CancellationPending = false;
            OnRunWorkerCompleted((RunWorkerCompletedEventArgs<TOutput>)arg);
        }

        private void WorkerThreadStart(TInput input)
        {
            var result = default(TOutput);
            Exception error = null;
            var cancelled = false;
            try
            {
                var eventArgs = new DoWorkEventArgs<TInput, TOutput>(input);
                OnDoWork(eventArgs);
                if (eventArgs.Cancel)
                {
                    cancelled = true;
                }
                else
                {
                    result = eventArgs.Result;
                }
            }
            catch (Exception exception)
            {
                error = exception;
            }

            var arg = new RunWorkerCompletedEventArgs<TOutput>(result, error, cancelled);

            AsyncOperation.PostOperationCompleted(operationCompleted, arg);
        }

        #endregion
    }
}