namespace Bankbot
{
    public class ConsoleBot : IChannel
    {
        private AbstractHandler<IMessage> Handler;
        private static ConsoleBot instance;
        public static ConsoleBot Instance
        {
            get
            {
                if (instance == null) instance = new ConsoleBot();

                return instance;
            }
        }
        private ConsoleBot()
        { }
        public void Start()
        {
            this.StartUp();
            System.Console.WriteLine("Para salir escriba \"Exit\"");
            while (true)
            {
                string text = System.Console.ReadLine().ToString();
                if (text == "Exit") return;
                BotMessage message = new BotMessage("UNIQUE_CONSOLE", text);
                HandleMessage(message);
            }
        }


        public void StartUp()
        {
            Handler = StartupConfig.HandlerConfig();
        }
        public void HandleMessage(IMessage message)
        {
            var data = Session.Instance.GetChat(message.Id);
            Session.Instance.SetChannel(message.Id, ConsoleBot.Instance);

            Handler.Handler(message);
        }
        public void SendMessage(string id, string message)
        {
            System.Console.WriteLine(message);
        }
    }
}

