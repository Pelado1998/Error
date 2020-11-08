namespace Bankbot
{
    public class Dispatcher : AbstractHandler<IMessage>
    {
        public Dispatcher(DispatcherCondition condition) : base(condition)
        {
        }

        protected override void handleRequest(IMessage request)
        {
            AllChats.Instance.ChatsDictionary[request.id].DataDictionary["LastCommnad"] = request.message;   
        }
    }
}