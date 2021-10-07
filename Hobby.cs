using System;
using System.Collections.Generic;

namespace passtask13{
    /// <summary>
    /// This class is used to create hobby objects where members can join 
    /// </summary>
    public class Hobby{
        private string _hobbyName;
        private int _monthlySubscriptionCost;
        private int _annualSubscriptionCost;
        private List<PostDefault> _hobbyNewsList;
        private List<CMember> _hobbyMemberList;
        private List<PostEvent> _hobbyEventList; // requires to store time as well
        
        /// <summary>
        /// This is a pass by value constructor that takes 3 values to create a hobby object
        /// </summary>
        /// <param name="hobbyname"></param>
        /// <param name="monthlysubscriptioncost"></param>
        /// <param name="annualsubscriptioncost"></param>
        public Hobby(string hobbyname, int monthlysubscriptioncost, int annualsubscriptioncost){
            _hobbyName = hobbyname;
            _monthlySubscriptionCost = monthlysubscriptioncost;
            _annualSubscriptionCost = annualsubscriptioncost;
            _hobbyNewsList = new List<PostDefault>();
            _hobbyMemberList = new List<CMember>();
            _hobbyEventList = new List<PostEvent>();
        }

        /// <summary>
        /// property for HobbyName
        /// </summary>
        /// <value></value>
        public string HobbyName{
            get { return _hobbyName; }
            set { _hobbyName = value; }
        }
        
        /// <summary>
        /// Property for monthy subscription cost of a hobby 
        /// </summary>
        /// <value></value>
        public int MonthlySubscriptionCost{
            get { return _monthlySubscriptionCost; }
            set { _monthlySubscriptionCost = value; }
        }
        
        /// <summary>
        /// Property for annual subscription cost of a hobby
        /// </summary>
        /// <value></value>
        public int AnnualSubscriptionCost{
            get { return _annualSubscriptionCost; }
            set { _annualSubscriptionCost = value; }
        }

        /// <summary>
        /// A read only property for HobbyNewsList
        /// </summary>
        /// <value></value>
        public List<PostDefault> HobbyNewsList{
            get { return _hobbyNewsList; }
        }


        /// <summary>
        /// a method that returns the total news that exist inside a hobby 
        /// </summary>
        /// <returns></returns>
        public int NumOfNews(){
            return _hobbyNewsList.Count;
        }
    

        /// <summary>
        /// A read only property for HobbyMemberList
        /// </summary>
        /// <value></value>
        public List<CMember> HobbyMemberList{
            get { return _hobbyMemberList; }
        }

        /// <summary>
        /// A read only property for HobbyEventList
        /// </summary>
        /// <value></value>
        public List<PostEvent> HobbyEventList{
            get { return _hobbyEventList; }
        }

        /// <summary>
        /// a method that returns the total number of event that exist inside a hobby 
        /// </summary>
        /// <returns></returns>
        public int NumOfEvent(){
            return _hobbyEventList.Count;
        }

        /// <summary>
        /// Add news into a hobby
        /// </summary>
        /// <param name="news"></param>
        public void AddNews(PostDefault news){
            _hobbyNewsList.Add(news);
        }

        /// <summary>
        /// remove news from a hobby
        /// </summary>
        /// <param name="news"></param>
        public void RemoveNews(PostDefault news){
            _hobbyNewsList.Remove(news);
        }
        
        /// <summary>
        /// Add Comment into an event created inside a hobby 
        /// </summary>
        /// <param name="eventnum"></param>
        /// <param name="comment"></param>
        public void AddComment(int eventnum, PostDefault comment){
            _hobbyEventList[eventnum].AddComment(comment);
        }
        

        /// <summary>
        /// Add a new event into a hobby
        /// </summary>
        /// <param name="postevent"></param>
        public void AddEvent(PostEvent postevent){
            _hobbyEventList.Add(postevent);
        }
        
        /// <summary>
        /// Remove an event from a hobby
        /// </summary>
        /// <param name="postevent"></param>
        public void RemoveEvent(PostEvent postevent){
            _hobbyEventList.Remove(postevent);
        }

        /// <summary>
        /// Edit the content of the hobby
        /// </summary>
        /// <param name="newhobbyname"></param>
        /// <param name="newmonthlysubscriptioncost"></param>
        /// <param name="newannualsubscriptioncost"></param>
        public void EditHobby(string newhobbyname, int newmonthlysubscriptioncost, int newannualsubscriptioncost){
            _hobbyName = newhobbyname;
            _monthlySubscriptionCost = newmonthlysubscriptioncost;
            _annualSubscriptionCost = newannualsubscriptioncost;
        } 

   }




}