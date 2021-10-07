using System;
using System.Collections.Generic;

namespace passtask13{
    /// <summary>
    /// This is a one time creation object that has 4 lists that should only exist once whenever the program is ran
    /// it has a member list, admin list, hobby list, global news list
    /// </summary>
    public class ManageList{
        private List<CMember> _memberList;
        private List<CAdmin> _adminList;
        private List<Hobby> _hobbyList;
        private List<PostDefault> _globalNewsList;

        /// <summary>
        /// This is a default constructor that has no parameters, the purpose if to create 4 lists that stores objects created from the program
        /// </summary>
        public ManageList(){
            _memberList = new List<CMember>();
            _adminList = new List<CAdmin>();
            _hobbyList = new List<Hobby>();
            _globalNewsList = new List<PostDefault>();
        }

        /// <summary>
        /// A read only property for MemberList
        /// </summary>
        /// <value></value>
        public List<CMember> MemberList{
            get { return _memberList; }
        } 

        /// <summary>
        /// Returns the total member exists in this entire association
        /// </summary>
        /// <returns></returns>
        public int NumOfMember(){
            return _memberList.Count;
        }

        /// <summary>
        /// a read only property for AdminList
        /// </summary>
        /// <value></value>
        public List<CAdmin> AdminList{
            get { return _adminList; }
        }

        /// <summary>
        /// Returns the total admin exists in the entire association
        /// </summary>
        /// <returns></returns>
        public int NumOfAdmin(){
            return _adminList.Count;
        }
        
        /// <summary>
        /// a read only property for HobbyList
        /// </summary>
        /// <value></value>
        public List<Hobby> HobbyList{
            get { return _hobbyList; }
        }

        /// <summary>
        /// total hobby exists in the entire association
        /// </summary>
        /// <returns></returns>
        public int NumOfHobby(){
            return _hobbyList.Count;
        }
        
        /// <summary>
        /// A read only property for GlobalNewsList
        /// </summary>
        /// <value></value>
        public List<PostDefault> GlobalNewsList{
            get { return _globalNewsList; }
        }

        /// <summary>
        /// returns total number of global news 
        /// </summary>
        /// <returns></returns>
        public int NumOfGlobalNews(){
            return _globalNewsList.Count;
        }
        
        /// <summary>
        /// add admin object into the admin list
        /// </summary>
        /// <param name="admin"></param>
        public void AddAdmin(CAdmin admin){
            _adminList.Add(admin);
        }

        /// <summary>
        /// Remove admin object from the admin list
        /// </summary>
        /// <param name="admin"></param>
        public void RemoveAdmin(CAdmin admin){
            _adminList.Remove(admin);
        }

        /// <summary>
        /// Add member object into the member list
        /// </summary>
        /// <param name="member"></param>
        public void AddMembership(CMember member){
            _memberList.Add(member);
        }

        /// <summary>
        /// Remove member object from the member list
        /// </summary>
        /// <param name="member"></param>
        public void RemoveMembership(CMember member){
            _memberList.Remove(member);
        }

        /// <summary>
        /// Add new hobby into the hobby list
        /// </summary>
        /// <param name="hobby"></param>
        public void AddHobby(Hobby hobby){
            _hobbyList.Add(hobby);
        }

        /// <summary>
        /// Remove hobby from the hobby list
        /// </summary>
        /// <param name="hobby"></param>
        public void RemoveHobby(Hobby hobby){
            _hobbyList.Remove(hobby);
        }

        /// <summary>
        /// Add global news into the global news list
        /// </summary>
        /// <param name="globalnews"></param>
        public void AddGlobalNewsToHobby(PostDefault globalnews){ 
            _globalNewsList.Add(globalnews);
        }

        /// <summary>
        /// remove global news from the global news list
        /// </summary>
        /// <param name="globalnews"></param>
        public void RemoveGlobalNewsFromHobby(PostDefault globalnews){ 
            _globalNewsList.Remove(globalnews);
        }
        

       
    }
}

