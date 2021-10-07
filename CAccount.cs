using System;
using System.Collections.Generic;

namespace passtask13{
    /// <summary>
    /// This is a parent class of CAdmin and CMember class
    /// </summary>
    public abstract class CAccount{  //abstract class (Parent of CreateMember and CreateAdmin)
        private string _userName;
        private string _userPassword;
        private Boolean _login;
        /// <summary>
        /// This is a pass by value constructor that helps its child classes to obtain the values 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="userpassword"></param>
        public CAccount(string username, string userpassword){
            _userName = username;
            _userPassword = userpassword;
            _login = false;
        }

        /// <summary>
        /// property for username of the admin or member object
        /// </summary>
        /// <value></value>
        public string UserName{
            get { return _userName; }
            set { _userName = value; }
        }

        /// <summary>
        /// property for userpassword of the admin or member object
        /// </summary>
        /// <value></value>
        public string UserPassword{
            get { return _userPassword; }
            set { _userPassword = value; }
        }

        /// <summary>
        /// property for a login boolean to identify if an account is login, or not
        /// </summary>
        /// <value></value>
        public Boolean Login{
            get { return _login; }
            set { _login = value; }
        }


    }

}