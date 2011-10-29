using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Controls.Commands {
    public class ActionCommand : ICommand {

        public event EventHandler CanExecuteChanged;
        private readonly Action<object> _executeDelegate;
        private readonly Func<object, bool> _canExecuteDelegate;

        public ActionCommand(Action<object> executeDelegate, Func<object, bool> canExecuteDelegate) {
            if (executeDelegate == null) {
                throw new ArgumentNullException("Execute cannot be null");
            }
            _executeDelegate = executeDelegate;
            _canExecuteDelegate = canExecuteDelegate;
        }
        

        //Löst das CanExecuteChange-Event aus
        public void Invalide() {
            if (CanExecuteChanged != null) {
                CanExecuteChanged(this, new EventArgs());
            }
        }

        public bool CanExecute(object parameter) {
            if (_canExecuteDelegate == null)
                return true;
            return _canExecuteDelegate(parameter);
            
        }

        

        public void Execute(object parameter) {
            _executeDelegate(parameter);
        }

    }
}
