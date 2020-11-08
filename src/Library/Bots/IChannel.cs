namespace Bankbot
{
    public interface IChannel
    {
        void Start();
        void HandleMessage(string id);
        void SendMessage(string id, string message);
        void StartUp();
    }
}