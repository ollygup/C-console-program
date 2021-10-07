using System;
using System.Collections.Generic;

namespace passtask13{
    /// <summary>
    /// This is a child class of Post, it creates object that requires only 2 values (news, global news, comment)
    /// </summary>
    public class PostDefault:Post{
        /// <summary>
        /// a pass by value constructor where the values are obtained using the parent class's constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public PostDefault(string name, string message):base(name,message){

        }

       

    }
}