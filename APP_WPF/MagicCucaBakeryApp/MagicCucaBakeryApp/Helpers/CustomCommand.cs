using System;
using System.Windows.Input;

namespace MagicCucaBakeryApp.Helpers
{
    internal class CustomCommand : ICommand
    {
        private Action targetExecuteMethod;
        private Func<bool> targetCanExecuteMethod;

        public event EventHandler CanExecuteChanged;

        public CustomCommand(Action executeMethod)
        {
            targetExecuteMethod = executeMethod;
        }

        public CustomCommand(Action executeMethod, Func<bool> canExecuteMethod)
        {
            targetExecuteMethod = executeMethod;
            targetCanExecuteMethod = canExecuteMethod;
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged(this, EventArgs.Empty);
        }

        public bool CanExecute(object parameter)
        {
            if (targetCanExecuteMethod != null)
            {
                return targetCanExecuteMethod();
            }
            if (targetExecuteMethod != null)
            {
                return true;
            }
            return false;
        }

        public void Execute(object parameter)
        {
            targetExecuteMethod?.Invoke();
        }
    }
}