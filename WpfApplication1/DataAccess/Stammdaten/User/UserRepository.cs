using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BL.Service.Stammdaten.User;
using Controls;
using Views.Stammdaten.User;
using WpfApplication1.Data.Channel;
using  BL.Service;

namespace WpfApplication1.DataAccess.Stammdaten.User {
    public class UserRepository
    {
        private ConnectionFactory<IUserService> _usrServiceFactory;
        private IUserService _usrServiceConnection;

        public  UserRepository() {
            _usrServiceFactory = new ConnectionFactory<IUserService>("net.tcp://localhost:2526/Service/Stammdaten/User");
            _usrServiceConnection = _usrServiceFactory.GetConnectionToService();
        }

        public List<UserView> GetAllUsers() {
          
                return _usrServiceConnection.AllUsers().Rows;
            
        }

        public UserView AddUser {
            set { _usrServiceConnection.AddUser(value); }
        }

        


        public void OnGetAllUsers() {
             
        }

    }
}
