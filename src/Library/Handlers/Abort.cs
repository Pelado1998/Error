using System;


namespace Bankbot
{
    //Implementacion
    public class Exit : AbstractHandler<IMessage>
    {
        public Exit(ExitCondition condition) : base(condition)
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