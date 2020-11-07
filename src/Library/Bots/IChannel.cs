namespace Bankbot
{
    public interface IChannel
    {
        void Start();
        void HandleMessage(long id, string message);
        void SendMessage(long id, string message);
        void StartUp();
    }
}