using System;
using System.Collections.Generic;
using System.Text;

namespace Bankbot
{
    public class AllCommands
    {
        public List<String> CommandsList { get; set; }
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
            this.CommandsList = new List<String>();
            this.CommandsList.Add("\\Login");               
            this.CommandsList.Add("\\Conversion");        
            this.CommandsList.Add("\\CreateUser");                
            this.CommandsList.Add("\\Logout");          
            this.CommandsList.Add("\\DeleteUser");     
            this.CommandsList.Add("\\CreateAccount");      
            this.CommandsList.Add("\\DeleteAccount");          
            this.CommandsList.Add("\\MakeTransaction");
        }
        public bool CommandExist(string command)
        {
            return instance.CommandsList.Contains(command);
        }
        public static String CommandsString()
        {
             StringBuilder currencies = new StringBuilder();
             foreach (String command in instance.CommandsList)
             {
                 currencies.Append($"{instance.CommandsList.IndexOf(command) + 1} - {command}\n");
             }
             return currencies.ToString();
        }
    }
}
