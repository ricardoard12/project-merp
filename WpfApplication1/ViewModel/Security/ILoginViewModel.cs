using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace WpfApplication1.ViewModel.Security
{
    public interface ILoginViewModel
    {

        void OnLoginExecute(object password);

        string Username { get; set; }

        bool CanLoginExecute();

        ICommand Login { get; }
    }
    
}
