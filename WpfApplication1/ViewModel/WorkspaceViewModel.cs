using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WpfApplication1.ViewModel {
    class WorkspaceViewModel : ViewModelBase{
        
        //Geht ab wenn der Workspace vom UI weg soll
        public event EventHandler RequestClose;

        void OnRequestClose() {
            EventHandler handler = this.RequestClose;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }

    }
}
