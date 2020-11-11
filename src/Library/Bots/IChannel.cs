namespace Bankbot
{
    public interface IChannel
    {
        void Start();
        void HandleMessage(IMessage message);
        void SendMessage(string id, string message);
        void StartUp();
    }
}