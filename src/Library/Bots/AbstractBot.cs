namespace Bankbot
{
    public abstract class AbstractBot : IChannel
    {
        private AbstractHandler<IMessage> Handler;
        protected AbstractBot()
        {
            this.Handler = StartupConfig.HandlerConfig();
        }
        public abstract void Start();
        public void HandleMessage(IMessage message)
        {
            Handler.Handler(message);
        }
        public abstract void SendMessage(string id, string message);
    }
}