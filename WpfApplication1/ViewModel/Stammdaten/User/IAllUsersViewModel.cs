using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Views.Stammdaten.User;

namespace WpfApplication1.ViewModel.Stammdaten.User
{
    public interface IAllUsersViewModel : IWorkspaceViewModel
    {
        ObservableCollection<IUserView> Users { get; }
    }
}
