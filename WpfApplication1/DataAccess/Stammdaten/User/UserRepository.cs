using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.ServiceModel;
using BL.Service.Stammdaten.User;
using FrontEnd.Data.Channel;
using Views;
using Views.Security.Connection;
using Views.Security.ErrorException;
using Views.Stammdaten.User;

namespace FrontEnd.DataAccess.Stammdaten.User {
    public class UserRepository
    {
       
        /*
        private FuncUser<List<IUserView>> UserFunction; 
        */     
        private IConnection<IUserService> _usrServiceConnection;
        private IUserService _usrService;
  

       public IConnection<IUserService> Connection {
            get {
                if (_usrServiceConnection == null) {
                    _usrServiceConnection =
                    ConnectionFactory<IUserService>.CreateConnection("UserService", "net.tcp://localhost:2526/Service/UserService");
                }

                if (_usrServiceConnection.ChannelFactory.State != CommunicationState.Opened)
                    _usrServiceConnection.ChannelFactory.Open();
                return _usrServiceConnection;
            }
        }

        public IUserService Service {
            get { return _usrService ?? (_usrService = Connection.ChannelFactory.CreateChannel()); }
        }

        // Funktioniert noch nicht. Bin gerade am Versuch Async umzusetzen. 
        public List<UserView> GetAllUsers {
            get { return Service.AllUsers().Rows; }
        }
            /*    UserFunction = () => _userList = _usrServiceConnection.AllUsers().Rows;

            AsyncCallback getUserEndedAsyncEnd = (result) => {
                                                     if (result != null && !result.IsCompleted)
                                                         throw new Exception("getUserEndedAsyncEnd" + result.ToString());
                                                     
                                                 };

           UserFunction.BeginInvoke(getUserEndedAsyncEnd, null);
            
            return _userList;*/

        

        public IUserView AddUser {
            set { Service.AddUser(value); }
        }


        public Boolean TestConnection {
            get {
                try {
                    return Service != null && Service.TestConnection();
                } catch (FaultException<LoginError> e) {
                    Debug.Print(e.StackTrace);
                    return false;
                }
            }
        }

        public void OnGetAllUsers() {
             
        }














    }
}
