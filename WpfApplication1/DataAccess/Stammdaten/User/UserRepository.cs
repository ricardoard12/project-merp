using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using BL.Service.Stammdaten.User;
using Controls;
using Views.Stammdaten.User;
using WpfApplication1.Data.Channel;
using  BL.Service;

namespace WpfApplication1.DataAccess.Stammdaten.User {
    public class UserRepository
    {
        private delegate TResult FuncUser<out TResult>();

        private FuncUser<List<UserView>> UserFunction; 
       
        private ConnectionFactory<IUserService> _usrServiceFactory;
        private IUserService _usrServiceConnection;
        private List<UserView> _userList;


        public  UserRepository() {
            _usrServiceFactory = new ConnectionFactory<IUserService>("net.tcp://localhost:2526/Service/Stammdaten/User");
            _usrServiceConnection = _usrServiceFactory.GetConnectionToService();
    _userList = new List<UserView>();
        }

        // Funktioniert noch nicht. Bin gerade am Versuch Async umzusetzen. 
        public List<UserView> GetAllUsers() {
             UserFunction = () => _userList = _usrServiceConnection.AllUsers().Rows;

            AsyncCallback GetUserEndedAsyncEnd = (result) => MessageBox.Show(result.ToString());

            UserFunction.BeginInvoke(GetUserEndedAsyncEnd, null);
            return _userList;

        }

        public UserView AddUser {
            set { _usrServiceConnection.AddUser(value); }
        }

        


        public void OnGetAllUsers() {
             
        }

    }
}
