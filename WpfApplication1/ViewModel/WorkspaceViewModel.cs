using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using WpfApplication1;

namespace FrontEnd.ViewModel {
    public class WorkspaceViewModel : ViewModelBase, IWorkspaceViewModel {

        RelayCommand _closeCommand;
        //Geht ab wenn der Workspace vom UI weg soll

        public ICommand CloseCommand {
            get { return _closeCommand ?? (_closeCommand = new RelayCommand(param => this.OnRequestClose())); }
        }

        public event EventHandler RequestClose;


        void OnRequestClose() {
            EventHandler handler = this.RequestClose;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }

    }
}
