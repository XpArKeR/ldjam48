using System;
using System.Windows.Input;

namespace Balancer.Commands
{
    public class SimpleCommand : ICommand
    {
        public Func<Boolean> CanExecuteDelegate { get; set; }
        public Action ExecuteDelegate { get; set; }

        public SimpleCommand()
        {
        }

        public SimpleCommand(Action action) : this()
        {
            this.ExecuteDelegate = action;
        }

        public SimpleCommand(Func<Boolean> canExecuteAction, Action action) : this(action)
        {
            this.CanExecuteDelegate = canExecuteAction;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public virtual bool CanExecute(object parameter)
        {
            if (CanExecuteDelegate != default)
            {
                return CanExecuteDelegate();
            }

            return true;
        }

        public virtual void Execute(object parameter)
        {
            ExecuteDelegate?.Invoke();
        }
    }
}
