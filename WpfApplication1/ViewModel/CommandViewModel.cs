using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace WpfApplication1.ViewModel
{
    // Sie implementiert das Property "Command" 
    // Der Navigationsbereich, zeigt für jedes CommandViewModel das von MainWindowViewModel verfügbar gemacht, wird einen Link an
    public class CommandViewModel : ViewModelBase
    {



        public CommandViewModel(string displayName, ICommand command) : this (displayName, command, null, null)
        {
         
        }

        public  CommandViewModel(string displayName, ICommand command, string hir1, string hir2)
        {
            if (command == null)
                throw new ArgumentNullException("command");

            DisplayName = displayName;
            this.Command = command;

            Hirarchi1 = hir1;
            Hirarchi2 = hir2;

        }

        public ICommand Command { get; private set; }
        public string Hirarchi1 { get; set; }
        public string Hirarchi2 { get; set; }

    }
}
