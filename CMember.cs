using System;
using System.Collections.Generic;

namespace passtask13{

    /// <summary>
    /// This is a child class of Account, named as member with an addition of 7 attributes
    /// </summary>    
    public class CMember:CAccount{
        private Boolean _subscription; //subscription true by default? not needed in constructor?
        private Hobby _hobbyGroup;
        private int _payment;
        private int _balance;
        private int _year;
        private int _month;
        private int _day;
        private DateTime _expiryDate;

        /// <summary>
        /// This is a pass by constructor of the child class, CMember
        /// </summary>
        /// <param name="createUserName">a string</param>
        /// <param name="createUserPassword">a string</param>
        /// <param name="subscription">boolean</param>
        /// <param name="hobbyGroup">hobby object</param>
        /// <param name="year">integer</param>
        /// <param name="month">integer</param>
        /// <param name="day">integer</param>
        /// <returns></returns>
        public CMember(string createUserName, string createUserPassword, Boolean subscription, Hobby hobbyGroup, int year, int month, int day):base(createUserName, createUserPassword){
            _subscription = subscription;
            _hobbyGroup = hobbyGroup;
            _year = year;
            _month = month;
            _day = day;
            _payment = 1000;
            _balance = 1000;
            _expiryDate = new DateTime(_year, _month, _day); //first day create account, expiry date that day?
        }

        /// <summary>
        /// property for hobbygroup
        /// </summary>
        /// <value></value>
        public Hobby HobbyGroup{
            get { return _hobbyGroup; }
            set { _hobbyGroup = value; }  //allow them to change hobbygroup?
        }

        /// <summary>
        /// property for Subscription
        /// </summary>
        /// <value></value>
        public Boolean Subscription{
            get { return _subscription; }
            set { _subscription = value; }
        }
        
        /// <summary>
        /// property for ExpiryDate
        /// </summary>
        /// <value></value>
        public DateTime ExpiryDate{
            get { return _expiryDate; }
            set { _expiryDate = value; }                  
        }

        /// <summary>
        /// property for Payment
        /// </summary>
        /// <value></value>
        public int Payment{
            get { return _payment; }
            set { _payment = value; }
        }

        /// <summary>
        /// property for Balance
        /// </summary>
        /// <value></value>
        public int Balance{
            get { return _balance; }
            set { _balance = value; }
        }


        /// <summary>
        /// A method that compares if the subscription is expired, and update their subscription if they have money in their balance, 
        /// update their expiry date depending on the balance ( payment  that is yet to be processed )
        /// </summary>
        /// <param name="hobbygroup"></param>
        /// <param name="paymentchoice"></param>
        public void ExpiryDateCompare(Hobby hobbygroup, int paymentchoice){
            int result = DateTime.Compare(DateTime.Today, _expiryDate.AddDays(60));
            if (paymentchoice >= hobbygroup.AnnualSubscriptionCost){
                _expiryDate = _expiryDate.AddDays(365);
                _balance -= hobbygroup.AnnualSubscriptionCost;
                if (result < 0){
                    _subscription = true;
                }else{
                    _subscription = false;
                }
            }else if (paymentchoice >= hobbygroup.MonthlySubscriptionCost){
                _expiryDate = _expiryDate.AddDays(30);
                _subscription = true;
                _balance -= hobbygroup.MonthlySubscriptionCost;
                if (result < 0){
                    _subscription = true;
                }else{
                    _subscription = false;
                }
            }
        }


        /// <summary>
        /// A function that creates a new comment post and add it into a hobby, and return the comment (PostDefault) object 
        /// </summary>
        /// <param name="eventnum"></param>
        /// <param name="name"></param>
        /// <param name="comment"></param>
        /// <returns></returns>
        public PostDefault PostComment(int eventnum, string name,string comment){
            PostDefault x = new PostDefault(name, comment);
            _hobbyGroup.AddComment(eventnum, x);
            return x;
        }

        /// <summary>
        /// a function that returns all the comments from its event (PostEvent) object
        /// </summary>
        /// <param name="eventnum"></param>
        public void ViewComments(int eventnum){
            foreach (PostDefault p in _hobbyGroup.HobbyEventList[eventnum].CommentList){
                Console.WriteLine("username :" + p.Name);
                Console.WriteLine("comment :" + p.Message);
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Edit/change member's object information 
        /// </summary>
        /// <param name="newusername"></param>
        /// <param name="newuserpassword"></param>
        /// <param name="newsubscription"></param>
        /// <param name="newhobbygroup"></param>
        public void EditMember(string newusername, string newuserpassword, Boolean newsubscription, Hobby newhobbygroup){
            UserName = newusername;
            UserPassword = newuserpassword;
            Subscription = newsubscription;
            HobbyGroup = newhobbygroup;
        }

        /// <summary>
        /// A function that allows member to view events occurance by month from their hobby group
        /// </summary>
        /// <param name="hobbygroup"></param>
        public void ViewEventMonth(Hobby hobbygroup){
            for (int x = 0; x < hobbygroup.NumOfEvent()-1; x++){
                for (int y = 0; y < hobbygroup.NumOfEvent()-1; y++){
                    if (hobbygroup.HobbyEventList[y].EventDate > hobbygroup.HobbyEventList[y+1].EventDate){
                        PostEvent temp = hobbygroup.HobbyEventList[y+1];
                        hobbygroup.HobbyEventList[y+1] = hobbygroup.HobbyEventList[y];
                        hobbygroup.HobbyEventList[y] = temp;
                    }
                }
            }
            Console.WriteLine("Event name           Event Date");
            Console.WriteLine("==================================");
            foreach(PostEvent m in hobbygroup.HobbyEventList){
                Console.WriteLine(m.Name + "        " + m.EventDate.ToString("dd/MM/yyyy"));
            }
            Console.WriteLine("\n"); 
        }
    }

}