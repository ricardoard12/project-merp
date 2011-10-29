using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace WpfApplication1.ViewModel {
    // Sie implementiert das Property "Command" 
    // Der Navigationsbereich, zeigt für jedes CommandViewModel das von MainWindowViewModel verfügbar gemacht, wird einen Link an
    class CommandViewModel : ViewModelBase {



        public CommandViewModel(string displayName, ICommand command) {
            if (command == null)
                throw new ArgumentNullException("command");

            DisplayName = displayName;
            this.Command = command;
        }

        public ICommand Command { get; private set; }
    }
}
