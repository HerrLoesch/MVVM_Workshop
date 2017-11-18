using System;
using System.Windows.Input;

namespace PublicationManager.MVVM
{
    public class DelegateCommand : ICommand
    {
        private readonly Action executeFunction;

        private readonly Func<bool> canExecuteFunction;

        public bool CanExecute(object parameter)
        {
            if (this.canExecuteFunction != null)
            {
                return this.canExecuteFunction();
            }

            return true;
        }

        public void Execute(object parameter)
        {
            if (this.executeFunction != null)
            {
                this.executeFunction.Invoke();
            }
        }

        public event EventHandler CanExecuteChanged;

        public virtual void CheckCanExecute()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public DelegateCommand(Action executeFunction, Func<bool> canExecuteFunction)
        {
            this.executeFunction = executeFunction;
            this.canExecuteFunction = canExecuteFunction;
        }

        public DelegateCommand(Action executeFunction)
        {
            this.executeFunction = executeFunction;
        }
    }
}
