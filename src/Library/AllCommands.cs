using System;
using System.Collections.Generic;
using System.Text;

namespace Bankbot
{
    public class AllCommands
    {
        public List<string> CommandsList { get; set; }
        private static AllCommands instance;
        
        public static AllCommands Instance
        {
            get
            {
                if (instance == null) instance = new AllCommands();
                return instance;
            }
        }
        private AllCommands()
        {
            this.CommandsList = new List<string>();
            this.CommandsList.Add("/Abort"); 
            this.CommandsList.Add("/Login");               
            this.CommandsList.Add("/Convertion");        
            this.CommandsList.Add("/CreateUser");                
            this.CommandsList.Add("/Logout");          
            this.CommandsList.Add("/DeleteUser");     
            this.CommandsList.Add("/CreateAccount");      
            this.CommandsList.Add("/DeleteAccount");          
            this.CommandsList.Add("/Transaction");
            this.CommandsList.Add("/Commands");    
            //this.CommandsList.Add("/Init");         El usuario no deberia de poder editar este comando
        }
        public static string Commandsstring(IMessage message)
        {
            string commandList = string.Empty;
            if ((User)AllChats.Instance.ChatsDictionary[message.id].DataDictionary["User"] == User.Empty )
            {
                foreach (string command in UnlogedCommandsList())
                {
                    commandList+=command+"\n";
                }
            }
            else if (((User)AllChats.Instance.ChatsDictionary[message.id].DataDictionary["User"]).Accounts.Count==0)
            {
                foreach (string command in HasNoAccountsCommandsList())
                {
                    commandList+=command+"\n";
                }
            }
            else
            {
                foreach (string command in HasAccountCommandsList())
                {
                    commandList+=command+"\n";
                }
            }
            return commandList;
        }
        private static List<string> UnlogedCommandsList()
        {
            List<string> unlogedList = new List<string>();
            unlogedList.Add("/Login");
            unlogedList.Add("/Convertion");
            unlogedList.Add("/CreateUser");
            return unlogedList;
        }
        private static List<string> HasNoAccountsCommandsList()
        {
            List<string> hasNoAccountsList = new List<string>();
            hasNoAccountsList.Add("/Logout");
            hasNoAccountsList.Add("/DeleteUser");
            hasNoAccountsList.Add("/CreateAccount");
            hasNoAccountsList.Add("/Convertion");
            hasNoAccountsList.Add("/CreateUser");
            return hasNoAccountsList;
        }
        private static List<string> HasAccountCommandsList()
        {
            List<string> hasAccountsList = new List<string>();
            hasAccountsList.Add("/Logout");
            hasAccountsList.Add("/DeleteUser");
            hasAccountsList.Add("/CreateAccount");
            hasAccountsList.Add("/Convertion");
            hasAccountsList.Add("/CreateUser");
            hasAccountsList.Add("/DeleteAccount");
            hasAccountsList.Add("/Transaction");
            return hasAccountsList;
        }

        public bool CommandExist(string command)
        {
            return instance.CommandsList.Contains(command);
        }
    }
}
