using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel.Security;
using System.Text;
using System.Windows;
using BL.Service.Stammdaten.User;
using Controls;
using Views.Security.Connection;
using Views.Stammdaten.User;
using WpfApplication1.Data.Channel;
using  BL.Service;

namespace WpfApplication1.DataAccess.Stammdaten.User {
    public class UserRepository
    {
       
        /*
        private FuncUser<List<IUserView>> UserFunction; 
        */     
        private IConnection<IUserService> _usrServiceConnection;
        private IUserService _usrService;
        private List<IUserView> _userList;


        public  UserRepository() {
            _usrServiceConnection = GetConnection();
            if (_usrServiceConnection.ChannelFactory.Credentials != null) {
                    _usrServiceConnection.ChannelFactory.Credentials.UserName.UserName = Session.Username;
                    _usrServiceConnection.ChannelFactory.Credentials.UserName.Password = Session.Password;
                }
            
            if (_usrService == null)
                _usrService = _usrServiceConnection.CreateService;
            
            _userList = new List<IUserView>();
        }

        private IConnection<IUserService> GetConnection() {
            return _usrServiceConnection ??
                   (_usrServiceConnection =
                    ConnectionFactory<IUserService>.CreateConnection("UserService", "net.tcp://localhost:2526/Service/Stammdaten/User"));
        }

        // Funktioniert noch nicht. Bin gerade am Versuch Async umzusetzen. 
        public List<IUserView> GetAllUsers() {

            return _usrService.AllUsers().Rows;
            /*    UserFunction = () => _userList = _usrServiceConnection.AllUsers().Rows;

            AsyncCallback getUserEndedAsyncEnd = (result) => {
                                                     if (result != null && !result.IsCompleted)
                                                         throw new Exception("getUserEndedAsyncEnd" + result.ToString());
                                                     
                                                 };

           UserFunction.BeginInvoke(getUserEndedAsyncEnd, null);
            
            return _userList;*/

        }

        public IUserView AddUser {
            set { _usrService.AddUser(value); }
        }

        


        public void OnGetAllUsers() {
             
        }














    }
}
