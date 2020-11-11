namespace Bankbot
{
    public interface IMessage
    {
        string Text { get; set; }
        string Id { get; set; }
    }
}