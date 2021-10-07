using System;
using System.Collections.Generic;

namespace passtask13{
    /// <summary>
    /// This is the child class of CAccount that inherits all the method or function it has with additonal
    /// stuff where only the child has itself
    /// </summary>
    public class CAdmin:CAccount{
        
        /// <summary>
        /// This a pass by constructor that obtains the value using the parent class constructor
        /// </summary>
        /// <param name="username"></param>
        /// <param name="userpassword"></param>
        /// <returns></returns>
        public CAdmin(string username, string userpassword):base(username, userpassword){

        }

        /// <summary>
        /// This function is used to create a hobby object using admin privilege
        /// </summary>
        /// <param name="list">A list to store all the hobbies</param>
        /// <param name="createhobbyname">Hobby object name</param>
        /// <param name="createmonthlysubscriptioncost">month subscription cost of the hobby by members</param>
        /// <param name="createannualsubscriptioncost">annual subscription cost of the hobby by members</param>
        /// <returns></returns>
        public Hobby CreateHobby(ManageList list, string createhobbyname, int createmonthlysubscriptioncost, int createannualsubscriptioncost){
            Hobby x = new Hobby(createhobbyname, createmonthlysubscriptioncost, createannualsubscriptioncost); 
            list.AddHobby(x);
            return x;
        }

        /// <summary>
        /// Using admin to edit the hobby name and cost
        /// </summary>
        /// <param name="list">the list that stores admin object</param>
        /// <param name="hobbynum">the index of hobby inside the list</param>
        /// <param name="newhobbyname">hobby name</param>
        /// <param name="newmonthlysubscriptioncost">monthy cost</param>
        /// <param name="newannualsubscriptioncost">annual cost</param>
        public void EditHobby(ManageList list, int hobbynum, string newhobbyname, int newmonthlysubscriptioncost, int newannualsubscriptioncost){
            list.HobbyList[hobbynum].EditHobby(newhobbyname, newmonthlysubscriptioncost, newannualsubscriptioncost);
        }

        /// <summary>
        /// delete a hobby object using admin privilege
        /// </summary>
        /// <param name="hobbygroup">the hobby object</param>
        /// <param name="hobbylist">the list that stores all the hobby object</param>
        public void DeleteHobby(Hobby hobbygroup, ManageList hobbylist){
            hobbylist.RemoveHobby(hobbygroup);
        }

        /// <summary>
        /// Create a new membership
        /// </summary>
        /// <param name="list">The list that stores all the member object</param>
        /// <param name="createusername">user name</param>
        /// <param name="createuserpassword">user password</param>
        /// <param name="subscription">a boolean, true if they are subscribed</param>
        /// <param name="hobbygroup">which hobby group/object they belong to</param>
        /// <returns></returns>
        public CMember CreateMembership(ManageList list, string createusername, string createuserpassword, Boolean subscription, Hobby hobbygroup, int year, int month, int day){
            CMember x = new CMember(createusername, createuserpassword, subscription, hobbygroup, year, month, day); //When create a new object, always add it into the global list
            list.AddMembership(x);
            return x;
        }

        /// <summary>
        /// edit member object using admin object
        /// </summary>
        /// <param name="list">the global list that stores member object</param>
        /// <param name="membernum">the index of member object inside the list</param>
        /// <param name="newusername">name</param>
        /// <param name="newuserpassword">password</param>
        /// <param name="newsubscription">boolean (true/false)</param>
        /// <param name="newhobbygroup">hobby object</param>
        public void EditMember(ManageList list, int membernum, string newusername, string newuserpassword, Boolean newsubscription, Hobby newhobbygroup){
            list.MemberList[membernum].EditMember(newusername, newuserpassword, newsubscription, newhobbygroup);
        }

        /// <summary>
        /// change memeber subscription ( true/false)
        /// </summary>
        /// <param name="member">member object</param>
        /// <param name="newsubscription">true/false</param>
        public void EditMemberSubscription (CMember member, Boolean newsubscription){
            member.Subscription = newsubscription;
        }

        /// <summary>
        /// view member list from a specific hobby group
        /// </summary>
        /// <param name="hobbygroup">a hobby object</param>
        public void ViewMemberList(Hobby hobbygroup){
            foreach(CMember m in hobbygroup.HobbyMemberList){
                Console.WriteLine(m.UserName);
            }
        }


        /// <summary>
        /// Create a news inside a hobby group
        /// </summary>
        /// <param name="hobbygroup">the hobby object where the news should be created</param>
        /// <param name="title">title of the news</param>
        /// <param name="news">content of the news</param>
        /// <returns></returns>
        public PostDefault CreateHobbyNews(Hobby hobbygroup, string title, string news){  //Add hobby news to any hobbygroup
            PostDefault x = new PostDefault(title, news);
            hobbygroup.AddNews(x);
            return x;
        }

        /// <summary>
        /// Edit a news belong to a hobby group
        /// </summary>
        /// <param name="hobbygroup"></param>
        /// <param name="news"></param>
        /// <param name="title"></param>
        /// <param name="message"></param>
        public void EditHobbyNews(Hobby hobbygroup, int news, string title, string message){
            hobbygroup.HobbyNewsList[news].Name = title;
            hobbygroup.HobbyNewsList[news].Message = message;
        }
        
        
        /// <summary>
        /// Create a global news that will be posted on all hobby groups
        /// </summary>
        /// <param name="list"></param>
        /// <param name="title"></param>
        /// <param name="news"></param>
        /// <returns></returns>
        public PostDefault CreateGlobalNews(ManageList list, string title, string news){
            PostDefault x = new PostDefault(title, news);
            list.AddGlobalNewsToHobby(x);
            return x;
        }

        /// <summary>
        /// delete existing global news
        /// </summary>
        /// <param name="list"></param>
        /// <param name="globalpost"></param>
        public void DeleteGlobalNews(ManageList list, int globalpost){
            list.RemoveGlobalNewsFromHobby(list.GlobalNewsList[globalpost]);
        }

        /// <summary>
        /// edit a global news
        /// </summary>
        /// <param name="list"></param>
        /// <param name="news"></param>
        /// <param name="title"></param>
        /// <param name="globalnews"></param>
        public void EditGlobalNews(ManageList list, int news, string title, string globalnews){
            list.GlobalNewsList[news].Name = title;
            list.GlobalNewsList[news].Message = globalnews;
        }
        
        /// <summary>
        /// Create a new hobby event using admin
        /// </summary>
        /// <param name="hobbygroup"></param>
        /// <param name="eventtitle"></param>
        /// <param name="content"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        public PostEvent CreateHobbyEvent(Hobby hobbygroup, string eventtitle, string content, int year, int month, int day){
            PostEvent x = new PostEvent(eventtitle, content, year, month, day);
            hobbygroup.AddEvent(x);
            return x;
        }

        
        /// <summary>
        /// edit hobby event using admin
        /// </summary>
        /// <param name="hobbygroup"></param>
        /// <param name="news"></param>
        /// <param name="eventtitle"></param>
        /// <param name="content"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        public void EditHobbyEvent(Hobby hobbygroup, int news, string eventtitle, string content, int year, int month, int day){
            hobbygroup.HobbyEventList[news].Name = eventtitle;
            hobbygroup.HobbyEventList[news].Message = content;
            hobbygroup.HobbyEventList[news].ChangeEventDate(year,month,day);
        }

        /// <summary>
        /// it will process all the payments made by members and update their subscription status
        /// </summary>
        /// <param name="CreateAllList"></param>
        public void ProcessPayment(ManageList CreateAllList){
            Console.WriteLine("  Member's name  |  Expiry date  |   Lifetime payment\n==================================================");
            for (int i = 0; i < CreateAllList.NumOfMember(); i++){
                Console.WriteLine((i+1) + ". " + CreateAllList.MemberList[i].UserName + "           " + CreateAllList.MemberList[i].ExpiryDate.ToString("dd/MM/yyyy") + "            " + CreateAllList.MemberList[i].Payment);
            } 
            Console.WriteLine("\n**Processing All Member's Payment**\n");
                                                    
            for (int x = 0; x < 20; x++){
                for (int i = 0; i < CreateAllList.NumOfMember(); i++){
                    if (CreateAllList.MemberList[i].Balance >= CreateAllList.MemberList[i].HobbyGroup.AnnualSubscriptionCost){
                        CreateAllList.MemberList[i].ExpiryDateCompare(CreateAllList.MemberList[i].HobbyGroup, CreateAllList.MemberList[i].HobbyGroup.AnnualSubscriptionCost);                                        
                    }
                    else if (CreateAllList.MemberList[i].Balance >= CreateAllList.MemberList[i].HobbyGroup.MonthlySubscriptionCost){
                        CreateAllList.MemberList[i].ExpiryDateCompare(CreateAllList.MemberList[i].HobbyGroup, CreateAllList.MemberList[i].HobbyGroup.MonthlySubscriptionCost);
                    }
                }
            }
            Console.WriteLine("  Member's name  |  Expiry date  |   Balance   |  Lifetime payment |\n=======================================================================================================");
            for (int i = 0; i < CreateAllList.NumOfMember(); i++){
                Console.WriteLine((i+1) + ". " + CreateAllList.MemberList[i].UserName + "           " + CreateAllList.MemberList[i].ExpiryDate.ToString("dd/MM/yyyy") + "          " + CreateAllList.MemberList[i].Balance + "              " +
                "                 " + CreateAllList.MemberList[i].Payment);
            }
            Console.WriteLine("\n");
        }
    }

}
