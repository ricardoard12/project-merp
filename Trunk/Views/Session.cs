using bbv.Common.EventBroker;

namespace Views
{
    public static class Session
    {
        private static EventBroker _eventBroker;

        private static string _username;
        private static string _password;

        public static string Username {
            get { return _username; }
            set { _username = value; }
        }

        public static string Password {
            get { return _password; }
            set { _password = value; }
        }

        public static EventBroker EventBroker() {
            return _eventBroker ?? (_eventBroker = new EventBroker());
        }
    }
}

