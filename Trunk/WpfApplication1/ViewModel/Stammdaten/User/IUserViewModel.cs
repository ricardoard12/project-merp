using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using FrontEnd;
using Views.Stammdaten.User;

namespace WpfApplication1.ViewModel.Stammdaten.User
{
    public interface IUserViewModel
    {
        ObservableCollection<IUserView> GetAllUsers { get; }
        IUserView AddUser { set; }

    }
}
