using System;
using System.Collections.Generic;

namespace passtask13{
    /// <summary>
    /// A child class of Post, Creates event object that takes it an additional 3 values, but with a total of 5 additonal attributes 
    /// </summary>
    public class PostEvent:Post{
        private List<PostDefault> _commentList;
        private int _year;
        private int _month;
        private int _day;
        private DateTime _eventTime;

        /// <summary>
        /// a pass by value constructor that takes in the days that the event will occur to create the event object
        /// and also a title and a description where the values will be passed over from the parent class 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="message"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        public PostEvent(string name, string message, int year, int month, int day):base(name,message){
            _commentList = new List<PostDefault>();
            _year = year;
            _month = month;
            _day = day;
            _eventTime = new DateTime(_year,_month,_day);
        }

        /// <summary>
        /// A read only property that returns a Datetime datatype, that requires to be converted into string ("dd/MM/yyyy")
        /// </summary>
        /// <value></value>
        public DateTime EventDate{
            get { return _eventTime; }
        }

        /// <summary>
        /// A read only property that returns a Comment List
        /// </summary>
        /// <value></value>
        public List<PostDefault> CommentList{
            get { return _commentList; }
        }

        /// <summary>
        /// Change/editing the event occurance date
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        public void ChangeEventDate(int year, int month, int day){
            _year = year;
            _month = month;
            _day = day;
            _eventTime = new DateTime(_year,_month,_day);
        }

        /// <summary>
        /// Add new comments into the event
        /// </summary>
        /// <param name="comment"></param>
        public void AddComment(PostDefault comment){
            _commentList.Add(comment);
        }

        
    }
}