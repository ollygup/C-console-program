using System;
using System.Collections.Generic;

namespace passtask13
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create a global object that stores all list
            ManageList CreateAllList = new ManageList();
            //Create 5 hobby group
            Hobby Hobby1 = new Hobby("Tabletop Wargamers", 100 ,1000);
            Hobby Hobby2 = new Hobby("Magic the Gathering Community", 50 ,500);
            Hobby Hobby3 = new Hobby("Boardgamers Community", 20 ,200);
            Hobby Hobby4 = new Hobby("Vanguard Community", 50 ,500);
            Hobby Hobby5 = new Hobby("Cosplay Community", 200 ,2000);
            //Create 1 admin
            CAdmin Admin1 = new CAdmin("admin","password");
            //Create 10 members
            CMember Member1 = new CMember("member1","password",true, Hobby1, 2021, 11, 1);
            CMember Member2 = new CMember("member2","password",true, Hobby1, 2021, 10, 10);
            CMember Member3 = new CMember("member3","password",true, Hobby2, 2022, 7, 1);
            CMember Member4 = new CMember("member4","password",false, Hobby2, 2010, 3, 10);  //expired
            CMember Member5 = new CMember("member5","password",false, Hobby3, 2021, 2, 12);  //expired
            CMember Member6 = new CMember("member6","password",true, Hobby3, 2022, 5, 20);
            CMember Member7 = new CMember("member7","password",false, Hobby4, 2021, 1, 22);  //expired
            CMember Member8 = new CMember("member8","password",true, Hobby4, 2021, 12, 10);
            CMember Member9 = new CMember("member9","password",true, Hobby5, 2021, 11, 1);
            CMember Member10 = new CMember("member10","password",true, Hobby5, 2021, 10, 30);
            //Add everything into list
            CreateAllList.AddAdmin(Admin1);
            CreateAllList.AddMembership(Member1);
            CreateAllList.AddMembership(Member2);
            CreateAllList.AddMembership(Member3);
            CreateAllList.AddMembership(Member4);
            CreateAllList.AddMembership(Member5);
            CreateAllList.AddMembership(Member6);
            CreateAllList.AddMembership(Member7);
            CreateAllList.AddMembership(Member8);
            CreateAllList.AddMembership(Member9);
            CreateAllList.AddMembership(Member10);
            CreateAllList.AddHobby(Hobby1);
            CreateAllList.AddHobby(Hobby2);
            CreateAllList.AddHobby(Hobby3);
            CreateAllList.AddHobby(Hobby4);
            CreateAllList.AddHobby(Hobby5);

            Boolean Logout = true; 
            Boolean correctinput =true;
            
            while(Logout){
                CAdmin AdminObject;
                CMember MemberObject;

                
                while (correctinput){
                    Console.WriteLine("===================================");
                    Console.WriteLine("     Welcome to Neko-Neko Nyaa");
                    Console.WriteLine("===================================\n");
                    Console.WriteLine("1. Admin\n2. Member\n3. Quit Program\n");
                    int UserType = int.Parse(Console.ReadLine());      //asking if admin or member

                    if (UserType == 1 || UserType == 2){
                        Console.Write("Username:");             //asking for username
                        string Name = Console.ReadLine();
                        Console.Write("User Password:");        //asking for password
                        string Password = Console.ReadLine();
                        Console.WriteLine();
                        if (UserType == 1){
                            foreach(CAdmin item in CreateAllList.AdminList){
                                if (Name == item.UserName && Password == item.UserPassword){
                                    item.Login = true;
                                    Logout = false;
                                    AdminObject = item;
                                    Boolean connected = true;
                                    while (connected){
                                        //if (UserType == 1 && Logout == false){
                                        Console.WriteLine("Choose a category you would like to execute.");
                                        Console.WriteLine("1.Hobby\n2.Member\n3.Subscription fees\n4.News\n5.Events\n6.Logout\n"); //main menu 
                                        int choice = int.Parse(Console.ReadLine());
                                        Console.WriteLine();
                                        if (choice == 1){
                                            while (true){
                                                Console.WriteLine("===================================");
                                                Console.WriteLine("1.Create new hobby\n2.Edit Hobby\n3.Delete existing Hobby\n4.Back"); //hobby menu
                                                Console.WriteLine("===================================\n");
                                                int hobbyChoice = int.Parse(Console.ReadLine());
                                                Console.WriteLine();
                                                if (hobbyChoice == 1){  //hobby menu choice 1 - create hobby
                                                    Console.Write("New Hobby Name:");
                                                    string newhobby = Console.ReadLine();
                                                    Console.Write("Monthly Subscription Cost:");
                                                    int monthlycost = int.Parse(Console.ReadLine());
                                                    Console.Write("Annual Subscription Cost:");
                                                    int annualcost = int.Parse(Console.ReadLine());
                                                    AdminObject.CreateHobby(CreateAllList,newhobby,monthlycost,annualcost);
                                                    Console.WriteLine("\nNew Hobby - " + newhobby + " has been successfully created\nCurrent hobby group count:" + CreateAllList.NumOfHobby());
                                                }
                                                else if (hobbyChoice == 2){ //hobby menu choice 2 - edit hobby
                                                    for (int i = 0; i < CreateAllList.NumOfHobby(); i++){
                                                        Console.WriteLine((i+1) + ". " + CreateAllList.HobbyList[i].HobbyName);
                                                    }
                                                    while (true){
                                                        Console.Write("Select the NO. of the hobby you would like to edit:");
                                                        int editchoice = int.Parse(Console.ReadLine());
                                                        if (editchoice <= CreateAllList.NumOfHobby()){
                                                            Console.Write("Change Hobby Name to?:");
                                                            string newhobbyname = Console.ReadLine();
                                                            Console.Write("Change Monthly Subscription Cost to?:");
                                                            int newmonthlycost = int.Parse(Console.ReadLine());
                                                            Console.Write("Change Annual Subscription Cost to?:");
                                                            int newannualcost = int.Parse(Console.ReadLine());
                                                            AdminObject.EditHobby(CreateAllList, editchoice-1, newhobbyname, newmonthlycost, newannualcost);
                                                            
                                                            Console.WriteLine("\nHobby name: " + CreateAllList.HobbyList[editchoice-1].HobbyName + "    Monthly fee: " + CreateAllList.HobbyList[editchoice-1].MonthlySubscriptionCost + "    Annual fee: " + CreateAllList.HobbyList[editchoice-1].AnnualSubscriptionCost);
                                                            break;
                                                        }
                                                        else{
                                                            Console.WriteLine("Hobby NO. not found, please try again.");
                                                        }
                                                    }
                                                }
                                                else if (hobbyChoice == 3){   //hobby menu choice 3 - delete hobby
                                                    for (int i = 0; i < CreateAllList.NumOfHobby(); i++){
                                                        Console.WriteLine((i+1) + ". " + CreateAllList.HobbyList[i].HobbyName);
                                                    }
                                                    while (true){
                                                        Console.Write("Select the NO. of the hobby you would like to edit:");
                                                        int editchoice = int.Parse(Console.ReadLine());
                                                        if (editchoice <= CreateAllList.NumOfHobby()){
                                                            CreateAllList.RemoveHobby(CreateAllList.HobbyList[editchoice-1]);
                                                            Console.WriteLine("Hobby group successfully deleted");
                                                            break;
                                                        }
                                                    }
                                                }
                                                else if (hobbyChoice == 4){  //return to main menu
                                                    break;
                                                }
                                                else{
                                                    Console.WriteLine("Choice Not Found.");
                                                }
                                            }
                                        }
            //----------- NEW SECTION -------------------------
                                        else if (choice == 2){   //admin's member menu (edit, create, delete member etc)
                                            while(true){
                                                Console.WriteLine("===================================");
                                                Console.WriteLine("1.Register new Member\n2.Edit Member\n3.Activate/Deactivate Member\n4.View Member Details\n5.View Member renewal list by month\n6.Back");
                                                Console.WriteLine("===================================\n");
                                                int memberChoice = int.Parse(Console.ReadLine());
                                                Console.WriteLine();
                                                if (memberChoice == 1){  //register new member
                                                    Console.Write("Member's name:");
                                                    string membername = Console.ReadLine();
                                                    Console.Write("Member's password:");
                                                    string memberpass = Console.ReadLine();
                                                    Console.Write("Member subscription (true, false):");
                                                    string membersub = Console.ReadLine().ToLower();
                                                    Boolean sub = false;
                                                    if (membersub == "true"){
                                                        sub = true;
                                                    }else{
                                                        sub = false;
                                                    }
                                                    for (int x = 0; x < CreateAllList.NumOfHobby(); x++){
                                                        Console.WriteLine((x+1) + ". " + CreateAllList.HobbyList[x].HobbyName);
                                                    }
                                                    int memberhobby;
                                                    while(true){
                                                        Console.WriteLine("Select the Hobby Group to add the new member into it.");
                                                        memberhobby = int.Parse(Console.ReadLine());
                                                        if (memberhobby <= CreateAllList.NumOfHobby()){
                                                            break;
                                                        }else{
                                                            Console.WriteLine("Wrong Input, please try again.");
                                                        }
                                                    }
                                                    Console.Write("Year of Account Creation (enter in integers, example - 2020):");
                                                    int thisyear = int.Parse(Console.ReadLine());
                                                    Console.Write("Month of Account Creation (enter in integer, example october would be - 10)");
                                                    int thismonth = int.Parse(Console.ReadLine());
                                                    Console.Write("Day of Account Creation (enter in integer, example 20th would be - 20");
                                                    int thisday = int.Parse(Console.ReadLine());
                                                    AdminObject.CreateMembership(CreateAllList,membername, memberpass, sub, CreateAllList.HobbyList[memberhobby-1], thisyear, thismonth, thisday);
                                                }
                                                else if (memberChoice == 2){  //edit existing member
                                                    for (int i = 0; i < CreateAllList.NumOfMember(); i++){
                                                            Console.WriteLine((i+1) + ". " + CreateAllList.MemberList[i].UserName);
                                                    }
                                                    while (true){
                                                        Console.Write("Select the NO. of the member you would like to edit:");
                                                        int editchoice = int.Parse(Console.ReadLine());
                                                        if (editchoice <= CreateAllList.NumOfMember()){
                                                            Console.Write("Change Member Name to?:");
                                                            string newmembername = Console.ReadLine();
                                                            Console.Write("Change Member Password to?:");
                                                            string newmemberpass = Console.ReadLine();
                                                            Console.Write("Activate (type true) or deactivate (type false) subscription:");
                                                            string newmembersub = Console.ReadLine().ToLower();
                                                                Boolean sub = false;
                                                            if (newmembersub == "true"){
                                                                sub = true;
                                                            }else{
                                                                sub = false;
                                                            }
                                                            for (int x = 0; x < CreateAllList.NumOfHobby(); x++){
                                                                Console.WriteLine((x+1) + ". " + CreateAllList.HobbyList[x].HobbyName);
                                                            }
                                                            Console.WriteLine("Change Member's hobby group to? (enter in integers):");
                                                            int newmemberhobby = int.Parse(Console.ReadLine());
                                                            AdminObject.EditMember(CreateAllList, editchoice-1, newmembername, newmemberpass, sub, CreateAllList.HobbyList[newmemberhobby-1]);
                                                                
                                                            Console.WriteLine("\nSuccessful! Member's detail edited.\n");
                                                            break;
                                                        }
                                                        else{
                                                            Console.WriteLine("Hobby NO. not found, please try again.");
                                                        }
                                                    }
                                                }
                                                else if (memberChoice == 3){  //activate or deactivate member
                                                    for (int i = 0; i < CreateAllList.NumOfMember(); i++){
                                                        Console.WriteLine((i+1) + ". " + CreateAllList.MemberList[i].UserName);
                                                    }
                                                    while (true){
                                                        Console.Write("Select the NO. of the member you would like to edit:");
                                                        int editchoice = int.Parse(Console.ReadLine());
                                                        if (editchoice <= CreateAllList.NumOfMember()){
                                                            Console.Write("Activate (type true) or deactivate (type false) subscription:");
                                                            string newmembersub = Console.ReadLine().ToLower();
                                                            Boolean sub = false;
                                                            if (newmembersub == "true"){
                                                                sub = true;
                                                            }else{
                                                                sub = false;
                                                            }
                                                            AdminObject.EditMemberSubscription(CreateAllList.MemberList[editchoice-1],sub);
                                                            Console.WriteLine("\nSuccessful! Member's subscription has been updated.\n");
                                                            break;
                                                        }
                                                        else{
                                                            Console.WriteLine("Member not found, please try again.");
                                                        } 
                                                    }
                                                }
                                                else if (memberChoice == 4){ //view member's detail
                                                    Console.WriteLine("  Member's name  |  Expiry date  |   Payment made\n==================================================");
                                                    for (int i = 0; i < CreateAllList.NumOfMember(); i++){
                                                        Console.WriteLine((i+1) + ". " + CreateAllList.MemberList[i].UserName + "           " + CreateAllList.MemberList[i].ExpiryDate.ToString("dd/MM/yyyy") + "            " + CreateAllList.MemberList[i].Payment);
                                                    }
                                                    Console.WriteLine("\n");
                                                }
                                                else if(memberChoice == 5){
                                                    for (int i = 0; i < CreateAllList.NumOfMember()-1; i++){
                                                        for ( int x = 0; x < CreateAllList.NumOfMember()-1; x++){
                                                            if (CreateAllList.MemberList[x].ExpiryDate > CreateAllList.MemberList[x+1].ExpiryDate){
                                                                CMember temp = CreateAllList.MemberList[x+1];
                                                                CreateAllList.MemberList[x+1] = CreateAllList.MemberList[x]; 
                                                                CreateAllList.MemberList[x] = temp;
                                                            }
                                                        }    
                                                    }
                                                    Console.WriteLine("username  |  Subscription expiry date");
                                                    foreach(CMember m in CreateAllList.MemberList){
                                                        Console.WriteLine(m.UserName + "   " + m.ExpiryDate);
                                                    }
                                                    Console.WriteLine("\n");    
                                                }
                                                else if(memberChoice == 6){  //quit this section
                                                    break;
                                                }
                                                else{
                                                    Console.WriteLine("Choice Not Found, please try again.");
                                                }
                                            }
                                        }
            //---------- NEW SECTION ---------------------------
                                        else if (choice == 3){  //Process members payment
                                            while(true){
                                                Console.WriteLine("===================================");
                                                Console.WriteLine("1.Process Membership subscription fees\n2.Back");
                                                Console.WriteLine("===================================\n");
                                                int feeChoice = int.Parse(Console.ReadLine());
                                                Console.WriteLine();
                                                if (feeChoice == 1){
                                                    AdminObject.ProcessPayment(CreateAllList);
                                                }
                                                else if (feeChoice == 2){
                                                    break;
                                                }
                                                else{
                                                    Console.WriteLine("Choice not found, please try again.");
                                                }
                                            }
                                        }
            //----------- NEW SECTION ---------------------------(Create, edit, delete hobby news/global news)-----------------
                                        else if (choice == 4){ 
                                            while(true){
                                                Console.WriteLine("\n===================================");
                                                Console.WriteLine("1.Create News\n2.Edit News\n3.Delete News\n4.Create Global News\n5.Edit Global News\n6.Delete Global News\n7.Back");
                                                Console.WriteLine("===================================\n");
                                                int newsChoice = int.Parse(Console.ReadLine());
                                                Console.WriteLine();
                                                if (newsChoice == 1){ //create hobby news
                                                    for (int x = 0; x < CreateAllList.NumOfHobby(); x++){
                                                        Console.WriteLine((x+1) + ". " + CreateAllList.HobbyList[x].HobbyName);
                                                    }
                                                    Console.Write("Which hobby group should the news be created?: (select numbers): ");
                                                    int pick = int.Parse(Console.ReadLine());
                                                    Console.Write("News title?: ");
                                                    string title = Console.ReadLine();
                                                    Console.Write("News content/message?");
                                                    string content = Console.ReadLine();
                                                    AdminObject.CreateHobbyNews(CreateAllList.HobbyList[pick-1],title, content);
                                                    Console.WriteLine("\n**News has been created and posted on " + CreateAllList.HobbyList[pick-1].HobbyName + "**\n\n");
                                                    //Console.WriteLine("\n" + CreateAllList.HobbyList[pick-1].HobbyNewsList[0].Name + "   " + CreateAllList.HobbyList[pick-1].HobbyNewsList[0].Message);  
                                                }
                                                else if (newsChoice == 2){ //edit hobby news
                                                    for (int x = 0; x < CreateAllList.NumOfHobby(); x++){
                                                        Console.WriteLine((x+1) + ". " + CreateAllList.HobbyList[x].HobbyName);
                                                    }
                                                    Console.Write("Which hobby group does the news belong to that you would like to edit?: (select numbers): ");
                                                    int hobbypick = int.Parse(Console.ReadLine());
                                                    for (int i = 0; i < CreateAllList.HobbyList[hobbypick-1].NumOfNews(); i++){
                                                        Console.WriteLine((i+1) + ". " + CreateAllList.HobbyList[hobbypick-1].HobbyNewsList[i].Name);
                                                    }
                                                    Console.Write("Which news would you like to edit?: (select numbers): ");
                                                    int newspick = int.Parse(Console.ReadLine());
                                                    Console.Write("News title?: ");
                                                    string title = Console.ReadLine();
                                                    Console.Write("News content/message?");
                                                    string content = Console.ReadLine();
                                                    AdminObject.EditHobbyNews(CreateAllList.HobbyList[hobbypick-1],newspick-1, title, content);
                                                    Console.WriteLine("\n**News has been edited**\n\n");
                                                    //Console.WriteLine("\n" + CreateAllList.HobbyList[hobbypick-1].HobbyNewsList[0].Name + "   " + CreateAllList.HobbyList[hobbypick-1].HobbyNewsList[0].Message);
                                                }
                                                else if (newsChoice == 3){
                                                    for (int x = 0; x < CreateAllList.NumOfHobby(); x++){
                                                        Console.WriteLine((x+1) + ". " + CreateAllList.HobbyList[x].HobbyName);
                                                    }
                                                    Console.Write("Which hobby group does the news belong to that you would like to detele?: (select numbers): ");
                                                    int hobbypick = int.Parse(Console.ReadLine());
                                                    for (int i = 0; i < CreateAllList.HobbyList[hobbypick-1].NumOfNews(); i++){
                                                        Console.WriteLine((i+1) + ". " + CreateAllList.HobbyList[hobbypick-1].HobbyNewsList[i].Name);
                                                    }
                                                    Console.Write("Which news would you like to DELETE?: (select numbers): ");
                                                    int newspick = int.Parse(Console.ReadLine());
                                                    CreateAllList.HobbyList[hobbypick-1].RemoveNews(CreateAllList.HobbyList[hobbypick-1].HobbyNewsList[newspick-1]);
                                                    Console.WriteLine("\n**News has been deleted from" + CreateAllList.HobbyList[hobbypick-1].HobbyName + "**\n\n");
                                                }
                                                else if (newsChoice == 4){ //create global hobby news
                                                    Console.Write("Global News title?: ");
                                                    string title = Console.ReadLine();
                                                    Console.Write("Global News content/message?");
                                                    string content = Console.ReadLine();
                                                    AdminObject.CreateGlobalNews(CreateAllList, title, content);
                                                    Console.WriteLine("\n**Global News has been created**\n\n");
                                                }
                                                else if (newsChoice == 5){ //edit global hobby news
                                                    for (int x = 0; x < CreateAllList.NumOfGlobalNews(); x++){
                                                        Console.WriteLine((x+1) + ". " + CreateAllList.GlobalNewsList[x].Name);
                                                    }
                                                    Console.Write("Which global news would you like to edit?: (select numbers): ");
                                                    int globalnewspick = int.Parse(Console.ReadLine());
                                                    Console.Write("Global News title?: ");
                                                    string title = Console.ReadLine();
                                                    Console.Write("Global News content/message?");
                                                    string content = Console.ReadLine();
                                                    AdminObject.EditGlobalNews(CreateAllList, globalnewspick-1, title, content);
                                                    Console.WriteLine("\n**Global News has been edited**\n\n");
                                                    foreach(Post p in CreateAllList.GlobalNewsList){
                                                        Console.WriteLine(p.Name);
                                                    }
                                                }
                                                else if (newsChoice == 6){
                                                    for (int x = 0; x < CreateAllList.NumOfGlobalNews(); x++){
                                                        Console.WriteLine((x+1) + ". " + CreateAllList.GlobalNewsList[x].Name);
                                                    }
                                                    Console.Write("Which global news would you like to delete?: (select numbers): ");
                                                    int globalnewspick = int.Parse(Console.ReadLine());
                                                    AdminObject.DeleteGlobalNews(CreateAllList,globalnewspick-1);
                                                    Console.WriteLine("\n**Global News has been deleted**\n\n");
                                                }
                                                else if (newsChoice == 7){
                                                    break;
                                                }
                                                else{
                                                    Console.WriteLine("Choice Not Found, please try again.");
                                                }
                                            }   
                                        }
        //--------------- NEW SECTION ----------------------------(create, edit, delete events)
                                        else if (choice == 5){
                                            while(true){
                                                Console.WriteLine("===================================");
                                                Console.WriteLine("\n1.Create Event\n2.Edit Event\n3.Delete Event\n4.Back\n");
                                                Console.WriteLine("===================================");
                                                int eventChoice = int.Parse(Console.ReadLine());
                                                Console.WriteLine();
                                                if (eventChoice == 1){ //create hobby events
                                                    for (int x = 0; x < CreateAllList.NumOfHobby(); x++){
                                                        Console.WriteLine((x+1) + ". " + CreateAllList.HobbyList[x].HobbyName);
                                                    }
                                                    Console.Write("Which hobby group should the event be created?: (select numbers): ");
                                                    int pick = int.Parse(Console.ReadLine());
                                                    Console.Write("Event title?: ");
                                                    string title = Console.ReadLine();
                                                    Console.Write("Event content/description?");
                                                    string content = Console.ReadLine();
                                                    Console.Write("Event year?: ");
                                                    int year = int.Parse(Console.ReadLine());
                                                    Console.Write("Event month?: ");
                                                    int month = int.Parse(Console.ReadLine());
                                                    Console.Write("Event day?: ");
                                                    int day = int.Parse(Console.ReadLine());
                                                    AdminObject.CreateHobbyEvent(CreateAllList.HobbyList[pick-1],title, content, year, month, day);
                                                    Console.WriteLine("\n**Event has been created and posted on " + CreateAllList.HobbyList[pick-1].HobbyName + "**\n\n");
                                                }
                                                else if (eventChoice == 2){ //edit hobby events
                                                    for (int x = 0; x < CreateAllList.NumOfHobby(); x++){
                                                        Console.WriteLine((x+1) + ". " + CreateAllList.HobbyList[x].HobbyName);
                                                    }
                                                    Console.Write("Which hobby group does the event belong to that you would like to edit?: (select numbers): ");
                                                    int hobbypick = int.Parse(Console.ReadLine());
                                                    for (int i = 0; i < CreateAllList.HobbyList[hobbypick-1].NumOfEvent(); i++){
                                                        Console.WriteLine((i+1) + ". " + CreateAllList.HobbyList[hobbypick-1].HobbyEventList[i].Name);
                                                    }
                                                    Console.Write("Which event would you like to edit?: (select numbers): ");
                                                    int eventpick = int.Parse(Console.ReadLine());
                                                    Console.Write("Event title?: ");
                                                    string title = Console.ReadLine();
                                                    Console.Write("Event content/description?");
                                                    string content = Console.ReadLine();
                                                    Console.Write("Event year?: ");
                                                    int year = int.Parse(Console.ReadLine());
                                                    Console.Write("Event month?: ");
                                                    int month = int.Parse(Console.ReadLine());
                                                    Console.Write("Event day?: ");
                                                    int day = int.Parse(Console.ReadLine());
                                                    AdminObject.EditHobbyEvent(CreateAllList.HobbyList[hobbypick-1],eventpick-1, title, content, year, month, day);
                                                    Console.WriteLine("\n**Event has been edited**\n\n");
                                                    
                                                }
                                                else if (eventChoice == 3){
                                                    for (int x = 0; x < CreateAllList.NumOfHobby(); x++){
                                                        Console.WriteLine((x+1) + ". " + CreateAllList.HobbyList[x].HobbyName);
                                                    }
                                                    Console.Write("Which hobby group does the event belong to that you would like to delete?: (select numbers): ");
                                                    int hobbypick = int.Parse(Console.ReadLine());
                                                    for (int i = 0; i < CreateAllList.HobbyList[hobbypick-1].NumOfEvent(); i++){
                                                        Console.WriteLine((i+1) + ". " + CreateAllList.HobbyList[hobbypick-1].HobbyEventList[i].Name);
                                                    }
                                                    Console.Write("Which event would you like to DELETE?: (select numbers): ");
                                                    int eventpick = int.Parse(Console.ReadLine());
                                                    CreateAllList.HobbyList[hobbypick-1].RemoveEvent(CreateAllList.HobbyList[hobbypick-1].HobbyEventList[eventpick-1]);
                                                    Console.WriteLine("\n**Event has been deleted from" + CreateAllList.HobbyList[hobbypick-1].HobbyName + "**\n\n");
                                                }
                                                else if (eventChoice == 4){
                                                    break;
                                                }
                                                else{
                                                    Console.WriteLine("Choice Not Found, please try again.");
                                                }
                                            }   
                                        }
                                        else if (choice == 6){
                                            connected = false;
                                            Console.WriteLine("Successfully logged out.\n");
                                            break;
                                        }
                                    }
                                }
                                else{
                                    Console.WriteLine("User account not found, please try again.\n");
                                }
                            }
                        }
                        
                        else if (UserType == 2){
                            foreach(CMember item in CreateAllList.MemberList){
                                if (Name == item.UserName && Password == item.UserPassword && item.Subscription == true){
                                    item.Login = true;
                                    Logout = false;
                                    MemberObject = item;
                                    Boolean connected = true;
                                    while (connected){
                                        Console.WriteLine("Choose a category you would like to execute.");
                                        Console.WriteLine("1.Hobby\n2.Membership\n3.Back\n");
                                        int choice = int.Parse(Console.ReadLine());
                                        if (choice == 1){
                                            while(true){
                                                Console.WriteLine("\n1.Events\n2.Post Comments\n3.View Comment\n4.Hobby News\n5.Global News\n6.Back\n");
                                                int hobbyChoice = int.Parse(Console.ReadLine());
                                                Console.WriteLine("\n");
                                                if (hobbyChoice == 1){
                                                    MemberObject.ViewEventMonth(MemberObject.HobbyGroup);
                                                }
                                                else if (hobbyChoice == 2){
                                                    for ( int x = 0; x < MemberObject.HobbyGroup.NumOfEvent(); x++){
                                                        Console.WriteLine(x+1 + ". " + MemberObject.HobbyGroup.HobbyEventList[x].Name);
                                                    }
                                                    Console.Write("Which event would you like to post a comment on: ");
                                                    int pick = int.Parse(Console.ReadLine());
                                                    Console.Write("Name/Nickname to post comment: ");
                                                    string nickname = Console.ReadLine();
                                                    Console.Write("Your comment: ");
                                                    string comment = Console.ReadLine();
                                                    Console.WriteLine("\n");
                                                    MemberObject.PostComment(pick-1, nickname, comment); 
                                                }
                                                else if (hobbyChoice == 3){
                                                    for ( int x = 0; x < MemberObject.HobbyGroup.NumOfEvent(); x++){
                                                        Console.WriteLine(x+1 + ". " + MemberObject.HobbyGroup.HobbyEventList[x].Name);
                                                    }
                                                    Console.Write("Which event would you like to read the comments from: ");
                                                    int pick = int.Parse(Console.ReadLine());
                                                    Console.WriteLine("\n");
                                                    MemberObject.ViewComments(pick-1);
                                                }
                                                else if (hobbyChoice == 4){
                                                    foreach (PostDefault news in MemberObject.HobbyGroup.HobbyNewsList){
                                                        Console.WriteLine("\nNews title: " + news.Name);
                                                        Console.WriteLine("News Content: " + news.Message + "\n");
                                                    }
                                                }
                                                else if (hobbyChoice == 5){
                                                    foreach (PostDefault globalnews in CreateAllList.GlobalNewsList){
                                                        Console.WriteLine("\nGlobal News title: " + globalnews.Name);
                                                        Console.WriteLine("Global News Content: " + globalnews.Message + "\n");
                                                    }
                                                }
                                                else if (hobbyChoice == 6){
                                                    break;
                                                }
                                                else{
                                                    Console.WriteLine("Choice not found.\n");
                                                }
                                            }
        //-----------------NEW SECTION ------------------------
                                        }
                                        else if (choice == 2){
                                            while(true){
                                                Console.WriteLine("\n1.Membership Details\n2.Payment\n3.Back\n");
                                                int memberChoice = int.Parse(Console.ReadLine());
                                                if ( memberChoice == 1){
                                                    Console.WriteLine("  Member's name  |  Expiry date  |   Payment made   |  Monthly Fee  |  Annual Fee \n===================================================================================");
                                                    Console.WriteLine(MemberObject.UserName + "           " + MemberObject.ExpiryDate.ToString("dd/MM/yyyy") + "            " + MemberObject.Payment + "            " + MemberObject.HobbyGroup.MonthlySubscriptionCost + "            " + MemberObject.HobbyGroup.AnnualSubscriptionCost);
                                                    Console.WriteLine("\n");
                                                }
                                                else if ( memberChoice == 2){
                                                    Console.WriteLine( "Monthly Subscription Fee: " + MemberObject.HobbyGroup.MonthlySubscriptionCost + "\nAnnual Subscription Fee: " + MemberObject.HobbyGroup.AnnualSubscriptionCost);
                                                    Console.WriteLine("How Much would you like to pay?: ");
                                                    int fee = int.Parse(Console.ReadLine());
                                                    MemberObject.Balance += fee;
                                                    MemberObject.Payment += fee;

                                                    Console.WriteLine("** Payment has been made, admin will process the fee soon, thank you! **");
                                                }
                                                else if (memberChoice == 3){
                                                    break;
                                                }
                                                else{
                                                    Console.WriteLine("Command not found.");
                                                }
                                            }
                                        }
                                        else if (choice == 3){
                                            connected = false;
                                            Console.WriteLine("Successfully logged out.\n");
                                            break;
                                        }
                                        else{
                                            Console.WriteLine("Unknown command");
                                        }
                                    }
                                }
                                else{
                                    //Console.WriteLine("User account not found, please try again.");
                                }
                            }
                        }else{
                            Console.WriteLine("User type not found, please try again.");
                        }
                    }
                    else if (UserType == 3){
                        Console.WriteLine("Program Terminated");
                        correctinput = false;
                        Logout = false;
                        break;
                    }
                    else{
                        Console.WriteLine("Wrong Input, please try again.");
                    }
                }
                
            }

        }
    }
}
