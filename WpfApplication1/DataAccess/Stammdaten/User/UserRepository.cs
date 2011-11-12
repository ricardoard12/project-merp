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
       
        /*
        private FuncUser<List<IUserView>> UserFunction; 
        */     
        private ConnectionFactory<IUserService> _usrServiceFactory;
        private IUserService _usrServiceConnection;
        private List<IUserView> _userList;


        public  UserRepository() {
            _usrServiceFactory = new ConnectionFactory<IUserService>("net.tcp://localhost:2526/Service/Stammdaten/User");
            _usrServiceConnection = _usrServiceFactory.GetConnectionToService;
    _userList = new List<IUserView>();
        }

        // Funktioniert noch nicht. Bin gerade am Versuch Async umzusetzen. 
        public List<IUserView> GetAllUsers() {

            return _usrServiceConnection.AllUsers().Rows;
            /*    UserFunction = () => _userList = _usrServiceConnection.AllUsers().Rows;

            AsyncCallback getUserEndedAsyncEnd = (result) => {
                                                     if (result != null && !result.IsCompleted)
                                                         throw new Exception("getUserEndedAsyncEnd" + result.ToString());
                                                     
                                                 };

           UserFunction.BeginInvoke(getUserEndedAsyncEnd, null);
            
            return _userList;*/

        }

        public IUserView AddUser {
            set { _usrServiceConnection.AddUser(value); }
        }

        


        public void OnGetAllUsers() {
             
        }














    }
}
