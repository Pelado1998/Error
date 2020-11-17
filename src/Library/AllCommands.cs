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
            this.CommandsList = new List<string>()
            {
                "/Abort",
                "/Login",
                "/Convert",
                "/CreateUser",
                "/Logout",
                "/DeleteUser",
                "/CreateAccount",
                "/DeleteAccount",
                "/Transaction",
                "/Commands"
            };
        }
        public string CommandList(string id)
        {
            var data = Session.Instance.GetChat(id);

            string commandList = string.Empty;

            if (data.User == null)
            {
                foreach (string command in UnlogedCommandsList())
                {
                    commandList += command + "\n";
                }
                return commandList;
            }
            else if (data.User.Accounts.Count == 0)
            {
                foreach (string command in HasNoAccountsCommandsList())
                {
                    commandList += command + "\n";
                }
                return commandList;
            }

            foreach (string command in HasAccountCommandsList())
            {
                commandList += command + "\n";
            }

            return commandList;
        }
        private static List<string> UnlogedCommandsList()
        {
            List<string> unlogedList = new List<string>();
            unlogedList.Add("/Login");
            unlogedList.Add("/CreateUser");
            unlogedList.Add("/Convertion");
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
