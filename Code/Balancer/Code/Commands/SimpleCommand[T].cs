using System;
using System.Windows.Input;

namespace Balancer.Commands
{
    public class SimpleCommand<T> : ICommand
    {
        public Func<T, Boolean> CanExecuteDelegate { get; set; }
        public Action<T> ExecuteDelegate { get; set; }

        public SimpleCommand()
        {

        }

        public SimpleCommand(Action<T> action) : this()
        {
            this.ExecuteDelegate = action;
        }

        public SimpleCommand(Func<T, Boolean> canExecuteAction, Action<T> action) : this(action)
        {
            this.CanExecuteDelegate = canExecuteAction;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        //public virtual void OnCanExecuteChanged()
        //{
        //    var canExecuteChanged = this.CanExecuteChanged;

        //    if (canExecuteChanged != default)
        //    {
        //        canExecuteChanged(this, EventArgs.Empty);
        //    }
        //}

        public virtual bool CanExecute(object parameter)
        {
            if (CanExecuteDelegate != default)
            {
                if (parameter is T castedParameter)
                {
                    return CanExecuteDelegate(castedParameter);
                }

                return false;
            }

            return true;
        }

        public virtual void Execute(object parameter)
        {
            if (parameter is T castedParameter)
            {
                this.Execute(castedParameter);
            }
        }

        public virtual void Execute(T parameter)
        {
            this.ExecuteDelegate?.Invoke(parameter);
        }
    }
}
