using System;
using System.Windows.Input;

namespace LibraryTest.ViewModels
{
    public class Command : ICommand
    {
        private readonly Action<object> _action;
        private readonly Func<bool> _func;

        public Command(Action<object> action, Func<bool> func)
        {
            _action = action;
            _func = func;
        }

        public void RaiseCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
                CanExecuteChanged(this, new EventArgs());
        }

        #region ICommand Members

        public bool CanExecute(object parameter)
        {
            if (_func != null)
                return _func();
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            _action(parameter);
        }

        #endregion
    }
}
