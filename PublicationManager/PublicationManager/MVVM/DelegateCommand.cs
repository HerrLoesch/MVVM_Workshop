using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PublicationManager.MVVM
{
    public class DelegateCommand : ICommand
    {
        private Action<object> executeAction;

        private Func<object, bool> canExecuteFunc;

        public DelegateCommand(Action<object> executeAction, Func<object, bool> canExecuteFunc)
        {
            this.executeAction = executeAction;
            this.canExecuteFunc = canExecuteFunc;
        }

        public bool CanExecute(object parameter)
        {
            return canExecuteFunc(parameter);
        }

        public void Execute(object parameter)
        {
            executeAction(parameter);
        }

        public event EventHandler CanExecuteChanged;

        public void RaiseExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
