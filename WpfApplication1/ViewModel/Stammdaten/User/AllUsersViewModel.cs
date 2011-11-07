using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Views.Stammdaten.User;

namespace WpfApplication1.ViewModel.Stammdaten.User {
    class AllUsersViewModel : WorkspaceViewModel
    {
        private readonly UserViewModel _userModel = new UserViewModel();

        private ObservableCollection<UserView> _users;

        public ObservableCollection<UserView> Users {
            get {
                if (_users == null || _users.Count == 0)
                    _users = new ObservableCollection<UserView>(_userModel.GetAllUsers);
                return _users;
            }
        } 

    }
}
