namespace Bankbot
{
    public class TelegramMessage: IMessage
    {
        public string id {get;set;}
        public string message{get;set;}

        public TelegramMessage(string id, string message)
        {
            this.id = id;
            this.message = message;
        }
    }
}