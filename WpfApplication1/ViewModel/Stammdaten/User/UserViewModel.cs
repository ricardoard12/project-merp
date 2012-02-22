using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using FrontEnd.DataAccess.Stammdaten.User;
using Views.Stammdaten.User;
using FrontEnd.Model.Stammdaten;
using WpfApplication1.ViewModel.Stammdaten.User;

namespace FrontEnd.ViewModel.Stammdaten.User {
    public class UserViewModel : WorkspaceViewModel, IUserViewModel
    {
        private UserRepository _userRepository;
        private RelayCommand _saveUser;
        private ObservableCollection<IUserView> _users;

        public UserViewModel() {
            _userRepository = new UserRepository();
        }

        private RelayCommand SaveUser {
            get { return _saveUser ?? (_saveUser = new RelayCommand(OnSaveUser)); }
        }

        private void OnSaveUser(object param) {
            if (param == null) throw new ArgumentNullException("param");
        }

        public ObservableCollection<IUserView> GetAllUsers {
            get {
                if ( _users == null || _users.Count == 0)
                    _users = new ObservableCollection<IUserView>(_userRepository.GetAllUsers);
                return _users;

            }
        }

        public IUserView AddUser {
            set { _userRepository.AddUser = value; }
        }
    }
}
