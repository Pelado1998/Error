using System;


namespace Bankbot
{
    //Implementacion
    public class Abort : AbstractHandler<IMessage>
    {
        public Abort(AbortCondition condition) : base(condition)
        {
        }

        protected override void handleRequest(IMessage request)
        {
            var data = Session.Instance.GetChat(request.Id);
            data.Temp.Clear();
            data.Command = string.Empty;
            data.State = State.Dispatcher;

            data.Channel.SendMessage(request.Id, "Operación cancelada.");
        }
    }
}