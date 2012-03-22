using System.Collections.ObjectModel;
using System.Collections.Specialized;
using Views.Stammdaten.User;
using WpfApplication1.ViewModel.Stammdaten.User;

namespace FrontEnd.ViewModel.Stammdaten.User {
    public class AllUsersViewModel : WorkspaceViewModel, IAllUsersViewModel 
    {
        private readonly UserViewModel _userModel;
        
        public AllUsersViewModel() {
            _userModel = new UserViewModel();
            _userModel.GetAllUsers.CollectionChanged += GetAllUsers_CollectionChanged;
        }

        private ObservableCollection<IUserView> _users;
 

        public ObservableCollection<IUserView> Users {
            get {
                if (_users == null || _users.Count == 0)
                    _users = new ObservableCollection<IUserView>(_userModel.GetAllUsers);
                return _users;
            }
        }

      
       private void GetAllUsers_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e) {
           _users = Users;
       }


       
    }
}
