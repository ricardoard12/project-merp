using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Views.Stammdaten.User;
using WpfApplication1.DataAccess.Stammdaten.User;
using WpfApplication1.Model.Stammdaten;

namespace WpfApplication1.ViewModel.Stammdaten.User {
    class UserViewModel
    {
        private UserRepository _userRepository;
        private RelayCommand _saveUser;
        private ObservableCollection<UserView> _users;

        RelayCommand SaveUser {
            get { return _saveUser ?? (_saveUser = new RelayCommand(OnSaveUser)); }
        }

        private void OnSaveUser(object param) {
            if (param == null) throw new ArgumentNullException("param");
        }

        public ObservableCollection<UserView> GetAllUsers {
            get { return _users ?? (_users = new ObservableCollection<UserView>(_userRepository.GetAllUsers())); }
        }

        public UserView AddUser {
            set { _userRepository.AddUser = value; }
        }
    }
}
