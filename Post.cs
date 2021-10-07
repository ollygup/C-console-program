using System;
using System.Collections.Generic;

namespace passtask13{
    /// <summary>
    /// This is an abstract class (parent class) called post, where its child classes creates post objects like comment, news, global news
    /// </summary>
    public abstract class Post{
        private string _name;
        private string _message;

        /// <summary>
        /// This is a pass by constructor of an abstract class where it helps the child classes to obtain 2 common values
        /// </summary>
        /// <param name="name"></param>
        /// <param name="message"></param>
        public Post(string name, string message){
            _name = name;
            _message = message;
        }

        /// <summary>
        /// property for Name (can also be a title/heading)
        /// </summary>
        /// <value></value>
        public string Name{
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// property for Message (also known for content/description)
        /// </summary>
        /// <value></value>
        public string Message{
            get { return _message; }
            set { _message = value; }
        }

       
    }

}