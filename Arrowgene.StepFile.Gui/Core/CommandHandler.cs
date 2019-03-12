using System;
using System.Windows.Input;

namespace Arrowgene.StepFile.Core
{
    public class CommandHandler : ICommand
    {
        private Action _action;
        private Func<bool> _canExecuteFunc;
        private bool _canExecute;

        public CommandHandler(Action action, Func<bool> canExecute)
        {
            _action = action;
            _canExecuteFunc = canExecute;
            _canExecute = true;
        }
        public CommandHandler(Action action, bool canExecute)
        {
            _action = action;
            _canExecute = canExecute;
            _canExecuteFunc = null;
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }

        public bool CanExecute(object parameter)
        {
            if (_canExecuteFunc != null)
                return _canExecuteFunc();
            return _canExecute;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            _action();
        }
    }
}
