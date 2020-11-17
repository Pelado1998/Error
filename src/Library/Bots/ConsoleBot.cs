namespace Bankbot
{
    public class ConsoleBot : AbstractBot
    {
        private static ConsoleBot instance;
        public static ConsoleBot Instance
        {
            get
            {
                if (instance == null) instance = new ConsoleBot();

                return instance;
            }
        }
        private ConsoleBot() : base()
        { }
        public override void Start()
        {
            System.Console.WriteLine("Para salir escriba \"Exit\"");
            while (true)
            {
                string text = System.Console.ReadLine().ToString();
                if (text == "Exit") return;
                Session.Instance.SetChannel("UNIQUE_CONSOLE", this);
                BotMessage message = new BotMessage("UNIQUE_CONSOLE", text);
                HandleMessage(message);
            }
        }

        public override void SendMessage(string id, string message)
        {
            System.Console.WriteLine(message);
        }
    }
}

