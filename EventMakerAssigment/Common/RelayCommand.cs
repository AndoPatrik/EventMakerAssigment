using System;
using System.Windows.Input;

namespace EventMakerAssigment.Common
{
    public class RelayCommand : ICommand
    {
        #region InstanceFields

        private readonly Action _execute;
        private readonly Func<bool> _canExecute;
       

        public event EventHandler CanExecuteChanged;

        #endregion

        #region Constructor(s)

        public RelayCommand(Action execute)
            : this(execute, null)
        {
        }

        public RelayCommand(Action execute, Func<bool> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");
            _execute = execute;
            _canExecute = canExecute;
        }

        public RelayCommand(Action<object> doSearch)
        {
        }

        #endregion

        #region Method(s)

        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute();
        }
        public void Execute(object parameter)
        {
            _execute();
        }

        public void RaiseCanExecuteChanged()
        {
            var handler = CanExecuteChanged;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        #endregion
    }
}
