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
            try {
                return _usrServiceConnection.AllUsers().Rows;
            }
            catch (Exception e) {
                MerpMessageBox.Show(e.Message, e.InnerException.ToString(), e.StackTrace, MerpMessageBoxButtons.Ok, MerpMessageBoxImage.Error);
            }

            return null;
        }

        public UserView AddUser {
            set { _usrServiceConnection.AddUser(value); }
        }

        


        public void OnGetAllUsers() {
             
        }

    }
}
