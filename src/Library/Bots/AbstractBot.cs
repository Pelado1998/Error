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
        public void SetChannel(string id, IChannel channel)
        {
            Session.Instance.SetChannel(id, channel);
        }
        public abstract void SendMessage(string id, string message);
        public abstract void SendFile(string id, string message);


    }
}